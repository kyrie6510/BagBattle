using Game;
using Game.Game;
using Unity.VisualScripting;

public partial class GameEntity
{
    public void DoAction()
    {
        EventManager.Instance.TriggerEvent(new OnLog($"冷却完成{localId.value}"));

        if (CanAttack())
        {
           var Id = actorId.Value == 0? 1: 0;
           var actor = Contexts.sharedInstance.actor.GetEntityWithId(Id);
           var v = UtilityRandom.random.Next((int)attack.Value[0], (int)attack.Value[1] + 1);
           actor.ReplaceHp(actor.hp.MaxValue,actor.hp.Value- v);
        }
        
    }

    public bool CanAttack()
    {
        return attack.Value[0] != 0 || attack.Value[1] != 0;
    }
    
}