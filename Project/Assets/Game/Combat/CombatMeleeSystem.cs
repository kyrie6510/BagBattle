using System.Net;
using Entitas;

namespace Game
{
    public class CombatMeleeSystem : CombatBaseExecuteSystem 
    {
        public CombatMeleeSystem() : base(CombatMatcher.CombatMeleeWeapon)
        {
            
        }

        protected override void Update(CombatEntity c)
        {
            var cmpt = c.combatMeleeWeapon;
            
            var e = Contexts.sharedInstance.game.GetEntityWithLocalId(cmpt.AttackerLocalId);
            
            if (cmpt.Step == 0)
            {
                cmpt.Step = 1;
                e.ReplaceTimingTypeAtk((int)ListenType.Atking);
                return;
            }

            //判定阶段
            if (cmpt.Step == 1)
            {
                var myActor = GetMyActor(c.combatMeleeWeapon.AttackerActorId);
                
                //耐力耗尽
                if (myActor.stamina.Value <= e.staminaCost.Value)
                {
                    c.Destroy();
                    e.ReplaceTimingTypeAtk(0);
                    EventManager.Instance.TriggerEvent(new OnLog("耐力耗尽"));
                    return;
                }

                //耐力消耗
                var staminaCompt = myActor.stamina;
                myActor.ReplaceStamina(staminaCompt.MaxValue,staminaCompt.Value - e.staminaCost.Value,staminaCompt.LastCoverSpan);
                
                //命中率判定
                if (!e.GetIsCanHit())
                {
                    c.Destroy();
                    e.ReplaceTimingTypeAtk((int)ListenType.AtkMis);
                    return;
                }
            
            
                //伤害获取
                var damage = e.GetDamage();
                var otherActor = GetOtherActor(c.combatMeleeWeapon.AttackerActorId);
                otherActor.GetDamage(damage);
                
                e.ReplaceTimingTypeAtk((int)ListenType.Atked);
                
            }
            
            
            
            
         
            
          
            
            

        }
    }
}