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

    private PropType _propType;
 
    public Image _imgItem;
    public Rigidbody2D _rig;

    
    // Start is called before the first frame update
    void Awake()
    {
        _imgItem = GetComponent<Image>();
        _rig = GetComponent<Rigidbody2D>();

        _imgItem.alphaHitTestMinimumThreshold = 0;
    }

    public void SetInfo(int configId, int localID)
    {
        this.ConfigId = configId;
        this.LocalId = localID;

        var config = ConfigManager.Instance.GetPropConfig(ConfigId);
        var boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.size = new Vector2(config.UIWidth * 80 , config.UIHeight * 80);

        _propType = (PropType)config.PropType;
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        if (_propType != PropType.GemStone)
        {
            EventManager.Instance.TriggerEvent(new OnItemSelectEvent(){ LocalId =   this.LocalId});    
        }

        else
        {
            EventManager.Instance.TriggerEvent(new OnGemStoneSelectEvent(){ LocalId =  this.LocalId});   
        }
        
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
