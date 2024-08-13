using Game.Game;

namespace Game
{
    public class EffectManager : Singleton<EffectManager>
    {
        public void CreatEffect(int effectId,int actorId,int entityId,int buffLocalId)
        {
            var effectConfig = ConfigManager.Instance.GetEffectConfig(effectId);

               if (effectConfig.EffectProbably != 100)
            {
                var value = UtilityRandom.Random.Next(0, 100);
                if (value > effectConfig.EffectProbably)
                {
                    EventManager.Instance.TriggerEvent(new BattleLog(actorId,$"{effectId}概率判断失败"));
                }
            }
            
            
            
            var buff = Contexts.sharedInstance.buff.GetEntityWithLocalId(buffLocalId);
            var actor = Contexts.sharedInstance.actor.GetEntityWithId(actorId);
            //处理添加buff类型
            if (effectConfig.EffectType == (int)EffectType.AddBuff)
            {
                if (effectConfig.EffectTarget == (int) ListenTarget.MyActor)
                {
                    actor.AddBuff(effectConfig.EffectClass,effectConfig.EffectValue);
                }
                
                if (effectConfig.EffectTarget == (int) ListenTarget.OtherActor)
                {
                    var otherActor = actor.GetOtherActor();
                    otherActor.AddBuff(effectConfig.EffectClass,effectConfig.EffectValue);
                }
            }
              
            //改变属性
            if (effectConfig.EffectType == (int)EffectType.Attribute)
            {
                if (effectConfig.EffectTarget == (int) ListenTarget.Self)
                {
                    //额外伤害
                    if (effectConfig.EffectClass == 1)
                    {
                        if (!buff.hasBuffAdditionAttack)
                        {
                            buff.AddBuffAdditionAttack(effectConfig.EffectValue,entityId);
                        }
                        else
                        {
                            buff.ReplaceBuffAdditionAttack(buff.buffAdditionAttack.Value+ effectConfig.EffectValue,entityId);
                        }
                    }
                    
                    
                }
            }

            //玩家属性
            if (effectConfig.EffectType == (int) EffectType.PlayerAttribute)
            {
                
                if (effectConfig.EffectTarget == (int) ListenTarget.MyActor)
                {
                    //生命值
                    if (effectConfig.EffectClass == 1)
                    {
                        var maxHp = actor.hp.MaxValue;
                        
                        var hpValue = actor.hp.Value;
                        hpValue = hpValue < 0 ? 0 : hpValue;
                        hpValue = hpValue > maxHp ? maxHp : hpValue;
                        
                        actor.ReplaceHp(maxHp,hpValue +effectConfig.EffectValue);
                    }
                    //耐力
                    else if (effectConfig.EffectClass == 2)
                    {
                        var maxValue = actor.stamina.MaxValue;
                        var staminaValue = actor.stamina.Value+ effectConfig.EffectValue;
                        
                        staminaValue = staminaValue < 0 ? 0 : staminaValue;
                        staminaValue = staminaValue > maxValue ? maxValue : staminaValue;
                        
                        actor.ReplaceStamina(maxValue,staminaValue,actor.stamina.LastCoverSpan);
                    }
                }

            }
            
            


        }
    }
}