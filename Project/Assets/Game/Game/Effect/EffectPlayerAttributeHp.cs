namespace Game
{
    [AttributeEffect(EffectType.PlayerAttribute,(int) EffectClassPlayerAttribute.Hp,"血量")]
    public class EffectPlayerAttributeHp : IEffect
    {
        public void Do(int effectId, int creatActorId, int attachEntityId)
        {
            var effectConfig = ConfigManager.Instance.GetEffectConfig(effectId);
            
            var creatActor = Contexts.sharedInstance.actor.GetEntityWithId(creatActorId);

            var targetActor = effectConfig.EffectTarget == (int) ListenTarget.MyActor
                ? creatActor
                : creatActor.GetOtherActor();
            
          
            var maxHp = targetActor.hp.MaxValue;
                        
            var hpValue = targetActor.hp.Value;
            hpValue = hpValue < 0 ? 0 : hpValue;
            hpValue = hpValue > maxHp ? maxHp : hpValue;
                        
            targetActor.ReplaceHp(maxHp,hpValue +effectConfig.EffectValue);
        }
    }
    
    
    [AttributeEffect(EffectType.PlayerAttribute,(int) EffectClassPlayerAttribute.Stamina,"体力")]
    public class EffectPlayerAttributeStamina : IEffect
    {
        public void Do(int effectId, int creatActorId, int attachEntityId)
        {
            var effectConfig = ConfigManager.Instance.GetEffectConfig(effectId);
            
            var creatActor = Contexts.sharedInstance.actor.GetEntityWithId(creatActorId);

            var targetActor = effectConfig.EffectTarget == (int) ListenTarget.MyActor
                ? creatActor
                : creatActor.GetOtherActor();
            
          
            var maxValue = targetActor.stamina.MaxValue;
            var staminaValue = targetActor.stamina.Value+ effectConfig.EffectValue;
                        
            staminaValue = staminaValue < 0 ? 0 : staminaValue;
            staminaValue = staminaValue > maxValue ? maxValue : staminaValue;
                        
            targetActor.ReplaceStamina(maxValue,staminaValue,targetActor.stamina.LastCoverSpan);
        }
    }
}