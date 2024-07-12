using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIItem : MonoBehaviour ,IPointerDownHandler 
{
    [SerializeField] public int ConfigId;
    public int LocalId;
    
    public ConfigItem ConfigItem;
    public Image _imgItem;
    public bool IsRoatete = false;
    public int RotateValue = 0;
    public Rigidbody2D _rig;

    private HashSet<int> _starItemIdMap = new HashSet<int>();
    
    // Start is called before the first frame update
    void Awake()
    {
        
        this.ConfigItem = ConfigManager.Instance.GetConfigItem(ConfigId);
        _imgItem = GetComponent<Image>();
        _rig = GetComponent<Rigidbody2D>();
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        InputManager.Instance.SetCurSelectItem(this);
    }

    public void AddStarTargetItem(UIItem item)
    {
        _starItemIdMap.Add(item.LocalId);
    }
    
    public void ClearStarTargetItem(UIItem item)
    {
        _starItemIdMap.Remove(item.LocalId);
    }
    

    public void SetRigState(bool isUseGravity)
    {
        if (isUseGravity) _rig.bodyType = RigidbodyType2D.Dynamic;
        else _rig.bodyType = RigidbodyType2D.Static;
    }
   
}
