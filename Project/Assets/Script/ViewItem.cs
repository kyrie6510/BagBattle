using System.Collections;
using System.Collections.Generic;
using Script;
using Script.Event;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ViewItem : MonoBehaviour ,IPointerDownHandler 
{
    [SerializeField] 
    public int ConfigId;
    public int LocalId;
    
    //public ConfigItem ConfigItem;
    public Image _imgItem;
   
    public Rigidbody2D _rig;

    
    // Start is called before the first frame update
    void Awake()
    {
        
       // this.ConfigItem = ConfigManager.Instance.GetConfigItem(ConfigId);
        _imgItem = GetComponent<Image>();
        _rig = GetComponent<Rigidbody2D>();
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        EventManager.Instance.TriggerEvent(new OnItemSelectEvent(){ LocalId =   this.LocalId});
        
        //InputManager.Instance.SetCurSelectItem(this);
    }

    
    public void SetRigState(bool isUseGravity)
    {
        if (isUseGravity) _rig.bodyType = RigidbodyType2D.Dynamic;
        else _rig.bodyType = RigidbodyType2D.Static;
    }
   
}
