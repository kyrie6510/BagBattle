using Entitas;

namespace Game.Buff
{
    public class BuffTimingEverHaveBuffSystem : BuffBaseExecuteSystem
    {
        public BuffTimingEverHaveBuffSystem() : base(BuffMatcher.TimingTypeEverHaveBuff)
        {
            
        }

        protected override void Update(BuffEntity buff)
        {
            var config = ConfigManager.Instance.GetTimConfig(buff.timingConfigId.Value);

            var e = Contexts.sharedInstance.game.GetEntityWithLocalId(buff.attachId.Value);
            var actor = Contexts.sharedInstance.actor.GetEntityWithId(e.actorId.Value);
            if (actor.hasActorBuff)
            {
                var buffId = buff.timingTypeEverHaveBuff.BuffId;
                if (!actor.actorBuff.Value.ContainsKey(buffId))
                {
                    return;
                }

                int activeTimes = actor.actorBuff.Value[buffId] - buff.timingTypeEverHaveBuff.LastActiveNum;

                for (int i = 0; i < activeTimes; i++)
                {
                    //触发效果
                    foreach (var effectId in buff.buffEffectId.Value)
                    {
                        EffectManager.Instance.CreatEffect(effectId,actor.id.Value, e.localId.value,buff.localId.value);
                    }
                }
                
                buff.ReplaceTimingTypeEverHaveBuff(buffId,actor.actorBuff.Value[buffId]);
                
           
                
              
                
               
                
            }
        }
        
    }
}