using System.Collections.Generic;

namespace Game
{
    [AttributeEffect(EffectType.PropAttribute, (int) EffectClassPropAttribute.AdditionAtk, "攻击+x")]
    public class EffectPropAttributeAdditionAtk : IEffect
    {
        public void Do(int effectId, int creatActorId, int attachEntityId)
        {
            var effectConfig = ConfigManager.Instance.GetEffectConfig(effectId);
            var attachEntity = Contexts.sharedInstance.game.GetEntityWithLocalId(attachEntityId);


            if (effectConfig.EffectTarget == (int) ListenTarget.Self)
            {
                AddAddition(effectConfig.EffectValue,attachEntityId);
            }

            if (effectConfig.EffectTarget == (int) ListenTarget.Star)
            {
                if (!attachEntity.hasStarTarget)
                {
                    EventManager.Instance.TriggerEvent(new OnLog("Error Error Error"));
                    return;
                }
                else
                {
                    foreach (var starId in attachEntity.starTarget.Value)
                    {
                        AddAddition(effectConfig.EffectValue,starId);
                    }
                }
            }
        }


        private void AddAddition(int addValue, int attachEntityId)
        {
            //找有没有附着在改道具上的buff
            var buffs = Contexts.sharedInstance.buff.GetEntitiesWithAttachId(attachEntityId);

            BuffEntity targetBuff = null;
            foreach (var buff in buffs)
            {
                if (buff.hasBuffAdditionAttack)
                {
                    targetBuff = buff;
                }
            }

            if (targetBuff == null)
            {
                targetBuff = FactoryEntity.CreatBuffEntity();
                targetBuff.AddAttachId(attachEntityId);
                targetBuff.AddBuffAdditionAttack(0, attachEntityId);
            }
            else
            {
                targetBuff.ReplaceBuffAdditionAttack(targetBuff.buffAdditionAttack.Value + addValue, attachEntityId);
            }
        }
    }

    /// <summary>
    /// 目前有 扫把
    /// </summary>
    [AttributeEffect(EffectType.PropAttribute, (int) EffectClassPropAttribute.NextAdditionAtk, "下次攻击伤害")]
    public class EffectPropAttributeNextAdditionAtk : IEffect
    {
        public void Do(int effectId, int creatActorId, int attachEntityId)
        {
            var effectConfig = ConfigManager.Instance.GetEffectConfig(effectId);

            var nextAdditionBuff = FactoryEntity.CreatBuffEntity();
            nextAdditionBuff.AddAttachId(attachEntityId);
            nextAdditionBuff.AddBuffAdditionAttackOnce(effectConfig.EffectValue);
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    [AttributeEffect(EffectType.PropAttribute, (int) EffectClassPropAttribute.CoolDown, "触发速度")]
    public class EffectPropAttributeCoolDown : IEffect
    {
        public void Do(int effectId, int creatActorId, int attachEntityId)
        {
            var effectConfig = ConfigManager.Instance.GetEffectConfig(effectId);

            if (effectConfig.EffectTarget == (int) ListenTarget.Bag)
            {
                
            }
            
            // var nextAdditionBuff = FactoryEntity.CreatBuffEntity();
            // nextAdditionBuff.AddAttachId(attachEntityId);
            // nextAdditionBuff.AddBuffAdditionAttackOnce(effectConfig.EffectValue);
        }
        
        
        private void AddAddition(int addValue, int attachEntityId)
        {
            //找有没有附着在改道具上的buff
            var buffs = Contexts.sharedInstance.buff.GetEntitiesWithAttachId(attachEntityId);

            BuffEntity targetBuff = null;
            foreach (var buff in buffs)
            {
                if (buff.hasBuffAddCoolDown)
                {
                    targetBuff = buff;
                }
            }

            if (targetBuff == null)
            {
                targetBuff = FactoryEntity.CreatBuffEntity();
                targetBuff.AddAttachId(attachEntityId);
                targetBuff.AddBuffAddCoolDown(addValue);
            }
            else
            {
                targetBuff.ReplaceBuffAddCoolDown(targetBuff.buffAddCoolDown.Value + addValue);
            }
        }
    }
    
}