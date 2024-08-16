namespace Game
{
    [AttributeEffect(EffectType.AddBuff,0,"")]
    public class EffectAddBuff : IEffect
    {
        public void Do(int effectId, int creatActorId, int attachEntityId)
        {
            var effectConfig = ConfigManager.Instance.GetEffectConfig(effectId);
            var actor = Contexts.sharedInstance.actor.GetEntityWithId(creatActorId);
            
            
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
    }
}