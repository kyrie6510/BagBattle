﻿



using FixMath.NET;
using Game;

public sealed partial class ActorEntity 
{
    
   
     
    
    /// <summary>
    /// 当近战伤害
    /// </summary>
    /// <param name="damageValue"></param>
    public void OnGetMeleeDamage(int actorId,int entityId,Fix64 damageValue)
    {
        var attacker = Contexts.sharedInstance.actor.GetEntityWithId(actorId);

        var buffMap = actorBuff.Value;
        
        //护甲buff抵消判断
        int defendValue = 0;
        if (buffMap.ContainsKey((int) BuffType.Block_11))
        {
            defendValue = buffMap[(int) BuffType.Block_11];
        }

        bool isHurt = defendValue - damageValue < 0;

        //受伤
        if (isHurt)
        {
            //尖刺反伤
            if (buffMap.ContainsKey((int) BuffType.Spikes_6))
            {
                attacker.OnGetBuffSpikesDamage(buffMap[(int) BuffType.Spikes_6]);
            }
            
            //临时护盾判断()
            EventManager.Instance.TriggerEvent(new BattleLog(id.Value,$"受伤害{damageValue}"));
            GetHurt(damageValue);
        }
        //防御
        else
        {
            //盾牌消耗
            buffMap[(int) BuffType.Block_11] -= (int)Fix64.Floor(damageValue);
            ReplaceActorBuff(buffMap);
        }
        
      
        
   
    }

    /// <summary>
    /// 当受到尖刺伤害
    /// </summary>
    public void OnGetBuffSpikesDamage(Fix64 value)
    {
        
        EventManager.Instance.TriggerEvent(new BattleLog(id.Value,$"受到尖刺伤害{value}"));
        
        GetHurt(value);
    }
    
    /// <summary>
    /// 当受毒伤害
    /// </summary>
    public void OnGetBuffPoisonDamage(Fix64 value)
    {
        EventManager.Instance.TriggerEvent(new BattleLog(id.Value,$"受到毒伤害{value}"));
        GetHurt(value);
    }
    
    /// <summary>
    /// 吸血恢复
    /// </summary>
    public void OnGetVampirismRecover(Fix64 value)
    {
        EventManager.Instance.TriggerEvent(new BattleLog(id.Value,$"吸血恢复{value}"));
        GetRecover(value);
    }
    
    
    /// <summary>
    /// buff恢复
    /// </summary>
    public void OnGetBuffRecover(Fix64 value)
    {
        EventManager.Instance.TriggerEvent(new BattleLog(id.Value,$"恢复{value}"));
        GetRecover(value);
    }
    
    /// <summary>
    /// 加血
    /// </summary>
    /// <param name="damageValue"></param>
    public void GetRecover(Fix64 value)
    {
        var result = hp.Value + value;
        result = result >= hp.MaxValue ? hp.MaxValue : result;
        
        ReplaceHp(hp.MaxValue, result);
    }
    
    
    /// <summary>
    /// 直接伤害
    /// </summary>
    /// <param name="damageValue"></param>
    public void GetHurt(Fix64 damageValue)
    {
        ReplaceHp(hp.MaxValue, hp.Value - damageValue);
    }

    /// <summary>
    /// 冷却buff加成百分比
    /// </summary>
    /// <returns></returns>
    public Fix64 GetBuffCoolDownAddition()
    {
        actorBuff.Value.TryGetValue((int) BuffType.Cold_9, out var coldValue);
        actorBuff.Value.TryGetValue((int) BuffType.Heat_2, out var heatValue);
        
        return   (coldValue - heatValue) * 2;
    }
    
}

