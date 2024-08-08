﻿
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

            var e = Contexts.sharedInstance.game.GetEntityWithLocalId(buff.attachId.Value);
            if (e.hasTimingTypeAtk)
            {
                if (e.timingTypeAtk.Value == buff.timingTypeAtk.Value)
                {
                    //触发效果
                    foreach (var effectId in buff.buffEffectId.Value)
                    {
                        var effectConfig = ConfigManager.Instance.GetEffectConfig(effectId);
                        EventManager.Instance.TriggerEvent(new OnLog($"{effectConfig.Name}"));
                        if (effectConfig.EffectType == (int)EffectType.AddBuff)
                        {
                            if (effectConfig.EffectTarget == (int) ListenTarget.MyActor)
                            {
                                var actor = Contexts.sharedInstance.actor.GetEntityWithId(e.actorId.Value);
                                actor.AddBuff(effectConfig.EffectClass,effectConfig.EffectValue);
                            }
                        }
                    }
                }
            }
        }
    }
}