namespace Game
{
    public class EffectManager : Singleton<EffectManager>
    {
        public void CreatEffect(int effectId,int actorId,int entityId)
        {
            var effectConfig = ConfigManager.Instance.GetEffectConfig(effectId);
            
            //处理添加buff类型
            if (effectConfig.EffectType == (int)EffectType.AddBuff)
            {
                if (effectConfig.EffectTarget == (int) ListenTarget.MyActor)
                {
                    var actor = Contexts.sharedInstance.actor.GetEntityWithId(actorId);
                    actor.AddBuff(effectConfig.EffectClass,effectConfig.EffectValue);
                }
            }


        }
    }
}