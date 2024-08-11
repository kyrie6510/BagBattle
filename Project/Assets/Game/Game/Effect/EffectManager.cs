namespace Game
{
    public class EffectManager : Singleton<EffectManager>
    {
        public void CreatEffect(int effectId,int actorId,int entityId,int buffLocalId)
        {
            var effectConfig = ConfigManager.Instance.GetEffectConfig(effectId);
            var buff = Contexts.sharedInstance.buff.GetEntityWithLocalId(buffLocalId);
            //处理添加buff类型
            if (effectConfig.EffectType == (int)EffectType.AddBuff)
            {
                if (effectConfig.EffectTarget == (int) ListenTarget.MyActor)
                {
                    var actor = Contexts.sharedInstance.actor.GetEntityWithId(actorId);
                    actor.AddBuff(effectConfig.EffectClass,effectConfig.EffectValue);
                }
            }
              
            //改变属性
            if (effectConfig.EffectType == (int)EffectType.Attribute)
            {
                if (effectConfig.EffectTarget == (int) ListenTarget.Self)
                {
                    //额外伤害
                    if (effectConfig.EffectClass == 2)
                    {
                        if (buff.hasBuffAdditionAttack)
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
            
            


        }
    }
}