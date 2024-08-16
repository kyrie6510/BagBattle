using System.Collections.Generic;
using Game.Game;


namespace Game
{
    public class EffectManager : Singleton<EffectManager>
    {
        private List<int> _attributeList = new List<int>();

        
        
        public void CreatEffect(int effectId,int actorId,int entityId)
        {
            var effectConfig = ConfigManager.Instance.GetEffectConfig(effectId);

            //概率判断
            if (effectConfig.EffectProbably != 100)
            {
                var value = UtilityRandom.Random.Next(0, 100);
                if (value > effectConfig.EffectProbably)
                {
                    EventManager.Instance.TriggerEvent(new BattleLog(actorId,$"{effectId}概率判断失败"));
                }
            }
            
            EventManager.Instance.TriggerEvent(new BattleLog(actorId, $"actor:{actorId} {effectConfig.Name}"));

            IEffect effect = null;
            //处理添加buff类型
            if (effectConfig.EffectType == (int)EffectType.AddBuff)
            {
                effect = new EffectAddBuff();
            }
              
            //改变属性
            if (effectConfig.EffectType == (int)EffectType.PropAttribute)
            {
                //额外伤害
                if (effectConfig.EffectClass == (int)EffectClassPropAttribute.AdditionAtk) effect = new EffectPropAttributeAdditionAtk();
                
                //下次攻击伤害
                if (effectConfig.EffectClass == (int)EffectClassPropAttribute.NextAdditionAtk) effect = new EffectPropAttributeNextAdditionAtk();
              
            }
            //玩家属性
            if (effectConfig.EffectType == (int) EffectType.PlayerAttribute)
            {
                if (effectConfig.EffectClass == (int) EffectClassPlayerAttribute.Hp) effect = new EffectPlayerAttributeHp();
                    
                if (effectConfig.EffectClass == (int) EffectClassPlayerAttribute.Stamina)   effect = new EffectPlayerAttributeStamina();
            }
            
            effect.Do(effectId,actorId,entityId);
            
        }

        public void CreatMeleeWeaponDefendEffect(int effectId, int attackerWeaponId)
        {
            var effectConfig = ConfigManager.Instance.GetEffectConfig(effectId);
            var ens = Contexts.sharedInstance.combat.GetGroup(CombatMatcher.CombatMeleeWeapon);
            foreach (var combat in ens)
            {
                if (!combat.hasCombatReduceDamage)
                {
                    combat.AddCombatReduceDamage(effectConfig.EffectValue);
                }
                else
                {
                    combat.ReplaceCombatReduceDamage(effectConfig.EffectValue+ combat.combatReduceDamage.Value);
                }
            }
        }
        
       
        
    }
    
}