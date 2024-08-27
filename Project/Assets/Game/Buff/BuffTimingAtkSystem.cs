using Entitas;
using Game.Game;

namespace Game
{
    public class BuffTimingAtkSystem : BuffBaseExecuteSystem
    {
        public BuffTimingAtkSystem() : base(BuffMatcher.TimingTypeAtk)
        {
        }



        public bool JudgeProbably(int probably)
        {
            //概率
            //概率判断
            if (probably != 100)
            {
                var value = UtilityRandom.Random.Next(0, 100);
                if (value > probably)
                {
                    return false;
                }
            }

            return true;
        }
        
        protected override void Update(BuffEntity buff)
        {
            var config = ConfigManager.Instance.GetTimConfig(buff.timingConfigId.Value);
            
            var attachEntity = Contexts.sharedInstance.game.GetEntityWithLocalId(buff.attachId.Value);
            var actor =  Contexts.sharedInstance.actor.GetEntityWithId(attachEntity.actorId.Value);

            
            //自身攻击时机监听
            if (buff.buffTimingListenTarget.ListTargetType == (int) ListenTarget.Self)
            {
                if (buff.timingTypeAtk.Value != attachEntity.timingTypeAtk.Value)
                {
                    return;
                }

                if (!JudgeProbably(config.ListenValue(0)))
                {
                    EventManager.Instance.TriggerEvent(new BattleLog(attachEntity.actorId.Value, $"时机:{config.Name},概率判断失败"));
                    return;
                }
                
                //触发效果
                foreach (var effectId in buff.buffEffectId.Value)
                {
                    EffectManager.Instance.CreatEffect(effectId, attachEntity.actorId.Value, attachEntity.localId.value);
                }
            }

         
            //未命中    
            else if (buff.buffTimingListenTarget.ListTargetType == (int) ListenTarget.OtherActorWeapon)
            {
                var other = actor.GetOtherActor();
                var targetList = Contexts.sharedInstance.game.GetEntitiesWithActorId((short) other.id.Value);

                foreach (var targetWeapon in targetList)
                {
                    if (!targetWeapon.hasTimingTypeAtk) continue;
                    if (targetWeapon.timingTypeAtk.Value == buff.timingTypeAtk.Value)
                    {
                        
                        if (!JudgeProbably(config.ListenValue(0)))
                        {
                            EventManager.Instance.TriggerEvent(new BattleLog(attachEntity.actorId.Value, $"时机:{config.Name},概率判断失败 "));
                            continue;
                        }
                        
                        //触发效果
                        foreach (var effectId in buff.buffEffectId.Value)
                        {
                            EffectManager.Instance.CreatEffect(effectId, attachEntity.actorId.Value, attachEntity.localId.value);
                        }
                    }
                }
            }
            
            
            //盾牌防御
            else if (buff.buffTimingListenTarget.ListTargetType == (int) ListenTarget.OtherActorMeleeWeapon)
            {
                var other = actor.GetOtherActor();
                var targetList = Contexts.sharedInstance.game.GetEntitiesWithActorId((short) other.id.Value);

                foreach (var targetWeapon in targetList)
                {

                    var targetConfig = ConfigManager.Instance.GetPropConfig(targetWeapon.configId.Value);
                        
                    if (!targetWeapon.hasTimingTypeAtk) continue;
                    if(targetConfig.PropType != (int)PropType.MeleeWeapon) continue;
                    
                    if (targetWeapon.timingTypeAtk.Value == buff.timingTypeAtk.Value)
                    {
                        //触发效果
                        foreach (var effectId in buff.buffEffectId.Value)
                        {
                            var effectConfig = ConfigManager.Instance.GetEffectConfig(effectId);
                            
                            if (effectConfig.EffectType == (int) EffectType.Defend)
                            {
                                if (!JudgeProbably(config.ListenValue(0)))
                                {
                                    EventManager.Instance.TriggerEvent(new BattleLog(attachEntity.actorId.Value, $"时机:{config.Name},概率判断失败"));
                                    continue;
                                }
                                
                                EffectManager.Instance.CreatMeleeWeaponDefendEffect(effectId,targetWeapon.localId.value);
                            }
                            else
                            {
                                EffectManager.Instance.CreatEffect(effectId, attachEntity.actorId.Value, attachEntity.localId.value);
                            }
                        }
                    }
                }
            }
        }
    }
}