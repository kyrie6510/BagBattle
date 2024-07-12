using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Script;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    // public int CurSelectLocalId;
    // public int CurItemId;
    private UIItem _curSelectItem;
    private ConfigItem _curSelectConfig;

    private GameObject _bagObj;
    private GameObject _mousePoint;

    private int _height = 610;
    private int _witdth = 780;
    private int _cellSize = 80;
    private int _offsetEdge = 10;
    private int _offsetGrid = 5;
    private int _newCellSize = 0;

    public override void Awake()
    {
        base.Awake();
        _bagObj = GameObject.Find("Bag");
        _mousePoint = GameObject.Find("MousePoint");
        
        _newCellSize =_cellSize + _offsetGrid;
    }

    public override void Update()
    {
        base.Update();
        
        if (_curSelectItem == null)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            var z = _curSelectItem.transform.rotation.eulerAngles.z;
            z -= 90;
            _curSelectItem.transform.rotation = UnityEngine.Quaternion.Euler(0, 0, z);
            
            _curSelectItem.IsRoatete = !_curSelectItem.IsRoatete;
            _curSelectItem.RotateValue += 90;
            if (_curSelectItem.RotateValue == 360) _curSelectItem.RotateValue = 0;
            
            UpdateMousePointSize();
            
        }
        
        this._curSelectItem.transform.position = Input.mousePosition;
        DealItemAndMousePos();
        
        if (Input.GetMouseButtonUp(0))
        {
            DealItemAndMousePos(true);
            GridManager.Instance.OnDrop();
            
            ClearMousePointSize();
            
            _curSelectItem = null;
            _curSelectConfig = null;
        }
    }


    private Vector2 CountEndPos(Vector2 localPoint)
    {
        

        var sizeDeltaEdge = _offsetEdge - _offsetGrid / 2.0f;
            

        var x = Mathf.Floor((localPoint.x - sizeDeltaEdge) / _newCellSize);
        var y = -Mathf.Ceil((localPoint.y + sizeDeltaEdge) / _newCellSize);

        
        
         var gird = GridManager.Instance.GetGrid((int) x, (int) y);
         //var test = gird.transform.localPosition;

        var gridLocalPos = new Vector2(_newCellSize * (x + 0.5f) + sizeDeltaEdge, -_newCellSize * (y + 0.5f) - sizeDeltaEdge);   
            

        var offsetX = localPoint.x - gridLocalPos.x;
        var offsetY = localPoint.y - gridLocalPos.y;

        var dirX = offsetX > 0 ? 1 : offsetX == 0 ? 0 : -1;
        var dirY = offsetY > 0 ? 1 : offsetY == 0 ? 0 : -1;
        
        // 偶数要偏移奇数不用
        var centerV2 = new Vector2(_curSelectConfig.Width % 2 == 0 ? 1 : 0,
            _curSelectConfig.Height % 2 == 0 ? 1 : 0);
        if (_curSelectItem.IsRoatete)
        {
            centerV2 = new Vector2(centerV2.y, centerV2.x);
        }

        var endPos = new Vector2(gridLocalPos.x + dirX * _newCellSize * 0.5f * centerV2.x,
            gridLocalPos.y + dirY * _newCellSize * 0.5f * centerV2.y);

        return endPos;
    }
    
    /// <summary>
    /// 位置矫正
    /// </summary>
    /// <param name="isDrop"></param>
    private void DealItemAndMousePos(bool isDrop =false)
    {

        //坐标换算为localPos
        var inputPos = Input.mousePosition;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(_bagObj.transform.GetComponent<RectTransform>(),
            inputPos, null, out var localPoint);
        
        var endPos = CountEndPos(localPoint);
        _mousePoint.transform.localPosition = endPos;
        
        if (isDrop)
        {
            _curSelectItem.transform.localPosition = endPos;
        }
      
        
        //在背包里
         if (localPoint.x >= 0 && localPoint.x <= _witdth && localPoint.y <= 0 && localPoint.y >= -_height)
         {
             UpdateMousePointSize();
         }
        else
        {
            ClearMousePointSize();
            GridManager.Instance.TouchClear();
            Debug.Log($"在背包外");
        }
    }
    
    private void ClearMousePointSize()
    {
        _mousePoint.GetComponent<RectTransform>().sizeDelta =  Vector2.zero;
        _mousePoint.GetComponent<BoxCollider2D>().size = Vector2.zero;
    }

    private void UpdateMousePointSize()
    {
        var size =  new Vector2(_curSelectConfig.Width * _newCellSize,
            _curSelectConfig.Height * _newCellSize);
        
        if (_curSelectItem.IsRoatete)
        {
            size = new Vector2(size.y, size.x);
        }
        _mousePoint.GetComponent<RectTransform>().sizeDelta =  size;
        _mousePoint.GetComponent<BoxCollider2D>().size = size;
    }
    
    
    public void SetCurSelectItem(UIItem item)
    {
        _curSelectItem = item;
        _curSelectConfig = ConfigManager.Instance.GetConfigItem(item.ConfigId);
        
        item.transform.SetParent(_bagObj.transform);
        _mousePoint.transform.position = Input.mousePosition;
        UpdateMousePointSize();
        
        _curSelectItem.SetRigState(false);
        
        _curSelectItem.transform.rotation = UnityEngine.Quaternion.Euler(0, 0, -_curSelectItem.RotateValue);
        
        GridManager.Instance.TouchClear();
        
    }

    public int GetCurSelectItemGridCont()
    {
        if (_curSelectItem != null)
        {
            return _curSelectConfig.Height * _curSelectConfig.Width;    
        }

        return int.MaxValue;
    }


    public ConfigItem GetCurSelectItemConfig()
    {
        return _curSelectConfig;
    }
    public UIItem GetCurSelectItem()
    {
        return _curSelectItem;
    }
   
}