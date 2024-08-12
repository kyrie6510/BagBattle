using Entitas;

namespace Game.Buff
{
    public class BuffTimingSecondPassSystem : BuffBaseExecuteSystem
    {
        public BuffTimingSecondPassSystem() : base(BuffMatcher.TimingTypeSecondPass)
        {
                
        }

        
        
        
        protected override void Update(BuffEntity buff)
        {
            var config = ConfigManager.Instance.GetTimConfig(buff.timingConfigId.Value);

            var e = Contexts.sharedInstance.game.GetEntityWithLocalId(buff.attachId.Value);

            if (buff.hasTimingTypeSecondPass)
            {
                var second = buff.timingTypeSecondPass.Value;
                var lastSpan = buff.timingTypeSecondPass.LastTimeSpan;
                
                if (Time.TimeFromStart - lastSpan >= second)
                {
                    //触发效果
                    foreach (var effectId in buff.buffEffectId.Value)
                    {
                        var effectConfig = ConfigManager.Instance.GetEffectConfig(effectId);
                        
                        EventManager.Instance.TriggerEvent(new BattleLog(e.actorId.Value, $"actor:{e.actorId.Value} {effectConfig.Name}"));
                        EffectManager.Instance.CreatEffect(effectId, e.actorId.Value, e.localId.value, buff.localId.value);
                    }

                    buff.ReplaceTimingTypeSecondPass(second, lastSpan + second);

                }
                
                
            }
            
        }
    }
}