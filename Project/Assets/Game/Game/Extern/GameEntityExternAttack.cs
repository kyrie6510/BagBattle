using FixMath.NET;
using Game;
using Game.Game;


public partial class GameEntity
{
    
    
    public void DoAttack()
    {

        var combat = Contexts.sharedInstance.combat.CreateEntity();
        var config =  ConfigManager.Instance.GetPropConfig((short) configId.Value);
        if (config.PropType == (int) PropType.MeleeWeapon)
        {
            combat.AddCombatMeleeWeapon(this.localId.value,this.actorId.Value,0);
        }
        else
        {
            combat.AddCombatRangedWeapon(this.localId.value,this.actorId.Value,0);
        }
    }


    
    
    public bool JudgeCanHit()
    {
        if (!hasAtkRate) return false;
        var value = UtilityRandom.Random.Next(0, 100);
        
        //EventManager.Instance.TriggerEvent(new BattleLog(actorId.Value,$"local:{localId.value} 概率判断：{value}"));
        
        //buff
        var additionRate = 0;
        var actor = GetActor();
        if (actor.hasActorBuff)
        {
            actor.actorBuff.Value.TryGetValue((int) BuffType.Blind_8, out var blindNUm);
            actor.actorBuff.Value.TryGetValue((int) BuffType.Luck_3, out var luckValue);

            additionRate = (luckValue - blindNUm) * 5;
        }
        
        return value <= atkRate.Value * ( 100 + additionRate)/100;
    }


    public ActorEntity GetActor()
    {
        return Contexts.sharedInstance.actor.GetEntityWithId(actorId.Value);
    }

 
}