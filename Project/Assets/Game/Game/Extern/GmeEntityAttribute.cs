
using FixMath.NET;
using Game;
using Game.Game;

public sealed  partial class GameEntity
{
        
    
    public Fix64 GetAtkValue()
    {
        if (!hasAttack) return 0;
        var value = UtilityRandom.Random.Next((int)attack.Value[0], (int)attack.Value[1]);
        
        var buffs = Contexts.sharedInstance.buff.GetEntitiesWithAttachId(localId.value);
        foreach (var buff in buffs)
        {
            if (buff.hasBuffAdditionAttack)
            {
                value += (int)buff.buffAdditionAttack.Value;
            }

            else if (buff.hasBuffAdditionAttackOnce)
            {
                value += (int) buff.buffAdditionAttackOnce.Value;
                if (!buff.isDestroy)
                {
                    buff.isDestroy = true;
                }
            }
            
        }

        //充能buff
        var actor = GetActor();
        actor.actorBuff.Value.TryGetValue((int) BuffType.Empower_1, out var powerValue);
        value += powerValue;
        
        return value;
    }

    public Fix64 GetCoolDownTimeValue()
    {
        if (!hasCoolDownTime)
        {
            return Fix64.MaxValue;
        }

       

        Fix64 buffValue = 0;
        var targetBuff =  Contexts.sharedInstance.buff.GetEntityWithBuffAddCoolDown(localId.value);
        if (targetBuff != null)
        {
            buffValue = targetBuff.buffAddCoolDown.Value;
        }

        //buff 是每个百分值2 
        var percent = 100 + GetActor().GetBuffCoolDownAddition() - buffValue;
        if (percent <= 0) return 0;
        
        
        
        return coolDownTime.Value *  percent/100;
        
        
    }
    
        
        
        
}