using System.Net;
using Entitas;
using FixMath.NET;

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
            
            var attacker = GetMyActor(c.combatMeleeWeapon.AttackerActorId);
            
            //判定阶段
            if (cmpt.Step == 1)
            {
                //耐力耗尽
                if (attacker.stamina.Value <= e.staminaCost.Value)
                {
                    c.Destroy();
                    e.ReplaceTimingTypeAtk(0);
                    EventManager.Instance.TriggerEvent(new BattleLog(attacker.id.Value,"耐力耗尽"));
                    return;
                }

                //耐力消耗
                var staminaCompt = attacker.stamina;
                attacker.ReplaceStamina(staminaCompt.MaxValue,staminaCompt.Value - e.staminaCost.Value,staminaCompt.LastCoverSpan);
                
                //命中率判定
                //命中也不能直接计算伤害,因为其他模块需要产生对应的效果
                if (!e.JudgeCanHit())
                {
                    
                    EventManager.Instance.TriggerEvent(new BattleLog(attacker.id.Value,$"actor:{attacker.id.Value} local:{cmpt.AttackerLocalId} 未命中"));
                    e.ReplaceTimingTypeAtk((int)ListenType.AtkMis);
                    cmpt.Step = 2;
                    return;
                }
                else
                {
                    e.ReplaceTimingTypeAtk((int)ListenType.Atked);
                    
                    //伤害计算
                    //伤害获取
                    var damageValue = e.GetDamage();
                
                    var target = GetOtherActor(c.combatMeleeWeapon.AttackerActorId);
                    //otherActor.OnGetMeleeDamage(attacker.id.Value, e.localId.value,damage);
                
                    //目标判断
                    var buffMap = target.actorBuff.Value;
        
                    //护甲buff抵消判断
                    int defendValue = 0;
                    if (buffMap.ContainsKey((int) BuffType.Block_11))
                    {
                        defendValue = buffMap[(int) BuffType.Block_11];
                    }

                    bool isHurt = defendValue - damageValue < 0;

                    //受伤
                    if (isHurt)
                    {
                        //尖刺反伤
                        if (buffMap.ContainsKey((int) BuffType.Spikes_6))
                        {
                            attacker.OnGetBuffSpikesDamage(buffMap[(int) BuffType.Spikes_6]);
                        }
            
                        // TODO 盾牌防御判断
                        target.GetHurt(damageValue);
                    }
                    //防御
                    else
                    {
                        //盾牌消耗
                        buffMap[(int) BuffType.Block_11] -= (int)Fix64.Floor(damageValue);
                    }

                    cmpt.Step = 2;
                    return;
                }
                
            }

            
            //销毁
            if (cmpt.Step == 2)
            {
                e.ReplaceTimingTypeAtk(0);
                c.Destroy();
            }
        }
    }
}