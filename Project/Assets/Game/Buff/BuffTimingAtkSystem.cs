using Entitas;

namespace Game
{
    public class BuffTimingAtkSystem : BuffBaseExecuteSystem
    {
        public BuffTimingAtkSystem() : base(BuffMatcher.TimingTypeAtk)
        {
        }


        protected override void Update(BuffEntity buff)
        {
            var config = ConfigManager.Instance.GetTimConfig(buff.timingConfigId.Value);

            var attachEntity = Contexts.sharedInstance.game.GetEntityWithLocalId(buff.attachId.Value);
          
            // if (attachEntity.timingTypeAtk.Value != buff.timingTypeAtk.Value)
            // {
            //     return;
            // }
            
           
            //攻击命中
            if (buff.buffTimingListenTarget.ListTargetType == (int) ListenTarget.Self)
            {
                //触发效果
                foreach (var effectId in buff.buffEffectId.Value)
                {
                    var effectConfig = ConfigManager.Instance.GetEffectConfig(effectId);
                    EventManager.Instance.TriggerEvent(new BattleLog(attachEntity.actorId.Value, $"actor:{attachEntity.actorId.Value} {effectConfig.Name}"));
                    EffectManager.Instance.CreatEffect(effectId, attachEntity.actorId.Value, attachEntity.localId.value, buff.localId.value);
                }
                
            }

         
            //未命中    
            else if (buff.buffTimingListenTarget.ListTargetType == (int) ListenTarget.OtherActorWeapon)
            {
                var other = GetOtherActor(buff.attachActorId.Value);
                var targetList = Contexts.sharedInstance.game.GetEntitiesWithActorId((short) other.id.Value);

                foreach (var targetWeapon in targetList)
                {
                    if (!targetWeapon.hasTimingTypeAtk) continue;
                    if (targetWeapon.timingTypeAtk.Value == buff.timingTypeAtk.Value)
                    {
                        //触发效果
                        foreach (var effectId in buff.buffEffectId.Value)
                        {
                            var effectConfig = ConfigManager.Instance.GetEffectConfig(effectId);
                            EventManager.Instance.TriggerEvent(new BattleLog(attachEntity.actorId.Value, $"actor:{attachEntity.actorId.Value} {effectConfig.Name}"));
                            EffectManager.Instance.CreatEffect(effectId, attachEntity.actorId.Value, attachEntity.localId.value, buff.localId.value);
                        }
                    }
                }
            }
            
            
            //盾牌防御
            else if (buff.buffTimingListenTarget.ListTargetType == (int) ListenTarget.OtherActorMeleeWeapon)
            {
                var other = GetOtherActor(buff.attachActorId.Value);
                var targetList = Contexts.sharedInstance.game.GetEntitiesWithActorId((short) other.id.Value);

                foreach (var targetWeapon in targetList)
                {

                    var targetConfig = ConfigManager.Instance.GetPropConfig(targetWeapon.localId.value);
                        
                    if (!targetWeapon.hasTimingTypeAtk) continue;
                    if(targetConfig.PropType != (int)PropType.MeleeWeapon) continue;
                    
                    if (targetWeapon.timingTypeAtk.Value == buff.timingTypeAtk.Value)
                    {
                        //触发效果
                        foreach (var effectId in buff.buffEffectId.Value)
                        {
                            var effectConfig = ConfigManager.Instance.GetEffectConfig(effectId);

                            EventManager.Instance.TriggerEvent(new BattleLog(attachEntity.actorId.Value, $"actor:{attachEntity.actorId.Value} {effectConfig.Name}"));
                            if (effectConfig.EffectType == (int) EffectType.Defend)
                            {
                                EffectManager.Instance.CreatMeleeWeaponDefendEffect(effectId,targetWeapon.localId.value);
                            }
                            else
                            {
                                EffectManager.Instance.CreatEffect(effectId, attachEntity.actorId.Value, attachEntity.localId.value, buff.localId.value);
                            }
                            
                           
                        }
                    }
                }
            }
        }
    }
}