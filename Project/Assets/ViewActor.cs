
using System;
using System.Collections.Generic;
using Entitas.Unity;
using FixMath.NET;
using UnityEngine;
using UnityEngine.UI;

public class ViewActor : MonoBehaviour , IHpListener , IStaminaListener , IActorBuffListener
{
    public Text TxtHp;
    public Text TxtStamina;

    public Image[] ImgBuffList;
    public Text[] TxtBuffList;

    private void Awake()
    {
        foreach (var image in ImgBuffList)
        {
            image.gameObject.SetActive(false);
        }
    }


    public void SetActorEntity(ActorEntity actor)
    {
        gameObject.Link(actor);
        
        // var eventListeners = gameObject.GetComponents<IGameEntiyEventListener>();
        // foreach (var listener in eventListeners)
        //     listener.RegisterListeners(e);
        
        // var eventListeners = gameObject.GetComponents<IGameEntiyEventListener>();
        // foreach (var listener in eventListeners)
        //     listener.RegisterListeners(e);
        
        actor.AddHpListener(this);
        actor.AddStaminaListener(this);
        actor.AddActorBuffListener(this);
        
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHp(ActorEntity entity, Fix64 maxValue, Fix64 value)
    {
        TxtHp.text = $"{value}/{maxValue}";
    }

  

    public void OnStamina(ActorEntity entity, Fix64 maxValue, Fix64 value, Fix64 lastCoverSpan)
    {
        TxtStamina.text = $"{Fix64.Round(value)}/{maxValue}";
    }

    public void OnActorBuff(ActorEntity entity, Dictionary<int, int> map)
    {
        foreach (var key in map.Keys)
        {
            if (map[key] > 0)
            {
                this.ImgBuffList[key-1].gameObject.SetActive(true);
                this.TxtBuffList[key-1].text = $"{map[key]}";
            }
        }
    }
}
