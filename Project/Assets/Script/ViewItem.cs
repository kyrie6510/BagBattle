using System;
using Entitas.Unity;
using Game;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ViewItem : MonoBehaviour ,IPointerDownHandler 
{
    [SerializeField] 
    public int ConfigId;
    public int LocalId;
    
 
    public Image _imgItem;
    public Rigidbody2D _rig;

    
    // Start is called before the first frame update
    void Awake()
    {
        _imgItem = GetComponent<Image>();
        _rig = GetComponent<Rigidbody2D>();
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        EventManager.Instance.TriggerEvent(new OnItemSelectEvent(){ LocalId =   this.LocalId});
    }

    
    public void SetRigState(bool isUseGravity)
    {
        if (isUseGravity) _rig.bodyType = RigidbodyType2D.Dynamic;
        else _rig.bodyType = RigidbodyType2D.Static;
    }


    public void SetGameEntity(GameEntity entity)
    {
        gameObject.Link(entity);
    }

    public void DoDestroy()
    {
        gameObject.GetEntityLink()?.Unlink();
        Destroy(gameObject);
    }

    
}
