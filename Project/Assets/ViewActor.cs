
using Entitas.Unity;
using FixMath.NET;
using UnityEngine;
using UnityEngine.UI;

public class ViewActor : MonoBehaviour , IHpListener , IStaminaListener
{
    public Text TxtHp;
    public Text TxtStamina;

    public void SetActorEntity(ActorEntity actor)
    {
        gameObject.Link(actor);
        actor.AddHpListener(this);
        actor.AddStaminaListener(this);

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

    public void OnStamina(ActorEntity entity, Fix64 maxValue, Fix64 value)
    {
        TxtStamina.text = $"{value}/{maxValue}";
    }
}
