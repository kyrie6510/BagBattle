using Script;
using Script.Event;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
     private int _curSelectItemId;
    // public int CurItemId;
    
    
    private UIItem _curSelectItemUI;
    private UIDataItem _curSelectItemData;
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
        
        
        EventManager.Instance.AddListener<OnItemSelectEvent>(OnItemSelectFunction);
    }

    

    public override void Update()
    {
        base.Update();
        
        if (_curSelectItemData == null)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            var z = _curSelectItemUI.transform.rotation.eulerAngles.z;
            z -= 90;
            _curSelectItemUI.transform.rotation = UnityEngine.Quaternion.Euler(0, 0, z);
            
            _curSelectItemData.IsRoatete = !_curSelectItemData.IsRoatete;
            _curSelectItemData.RotateValue += 90;
            if (_curSelectItemData.RotateValue == 360) _curSelectItemData.RotateValue = 0;
            
            UpdateMousePointSize();
            GridManager.Instance.TouchClear();
        }
        
        this._curSelectItemUI.transform.position = Input.mousePosition;
        DealItemAndMousePos();
        
        if (Input.GetMouseButtonUp(0))
        {
            DealItemAndMousePos(true);
            GridManager.Instance.OnDrop();
            
            ClearMousePointSize();
            
            _curSelectItemUI = null;
            _curSelectConfig = null;
            _curSelectItemData = null;
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
        if (_curSelectItemData.IsRoatete)
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
            _curSelectItemUI.transform.localPosition = endPos;
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
        
        if (_curSelectItemData.IsRoatete)
        {
            size = new Vector2(size.y, size.x);
        }
        _mousePoint.GetComponent<RectTransform>().sizeDelta =  size;
        _mousePoint.GetComponent<BoxCollider2D>().size = size;
    }
    
    
    private void OnItemSelectFunction(OnItemSelectEvent e)
    {
        _curSelectItemId = e.LocalId;
        
        _curSelectItemUI = ItemManager.Instance.GetItemUI(_curSelectItemId);
        _curSelectItemData = ItemManager.Instance.GetItemData(_curSelectItemId);
        _curSelectConfig = ConfigManager.Instance.GetConfigItem(_curSelectItemData.ConfigId);
        
        _curSelectItemUI.transform.SetParent(_bagObj.transform);
        _mousePoint.transform.position = Input.mousePosition;
        UpdateMousePointSize();
        
        _curSelectItemUI.SetRigState(false);
        
        _curSelectItemUI.transform.rotation = UnityEngine.Quaternion.Euler(0, 0, - _curSelectItemData.RotateValue);
        
        GridManager.Instance.TouchClear();
    }
    

    public int GetCurSelectItemGridCont()
    {
        if (_curSelectItemUI != null)
        {
            return _curSelectConfig.Height * _curSelectConfig.Width;    
        }

        return int.MaxValue;
    }


    public int GetCurSelectItemId()
    {
        return _curSelectItemId;
    }
    public UIItem GetCurSelectItem()
    {
        return _curSelectItemUI;
    }
   
}