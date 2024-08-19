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

        //原游戏:击中对手->(攻击计算结束)
        //盾牌的监听时机为对手武器攻击时,而不是命中后

        // 攻击流程
        // 1.产生combat
        // 2.combat:体力判定 
        // 3.命中率判定->成功进入4 ->失败设置状态为未命中
        // 4.combat:攻击状态为(攻击时)
        // 5.buff:监听攻击时-> 加攻击, 盾牌防御
        // 6.combat:计算最终伤害(命中后)
        // 7.buff:监听攻击后->产生效果等

        protected override void Update(CombatEntity c)
        {
            var cmpt = c.combatMeleeWeapon;

            var e = Contexts.sharedInstance.game.GetEntityWithLocalId(cmpt.AttackerLocalId);

            var attacker = GetMyActor(c.combatMeleeWeapon.AttackerActorId);

            //检测
            if (cmpt.Step == 0)
            {
                //耐力耗尽
                if (attacker.stamina.Value <= e.staminaCost.Value)
                {
                    c.Destroy();
                    e.ReplaceTimingTypeAtk(0);
                    EventManager.Instance.TriggerEvent(new BattleLog(attacker.id.Value, "耐力耗尽"));
                    return;
                }

                //耐力消耗
                var staminaCompt = attacker.stamina;
                attacker.ReplaceStamina(staminaCompt.MaxValue, staminaCompt.Value - e.staminaCost.Value,
                    staminaCompt.LastCoverSpan);


                //命中率判定
                //命中也不能直接计算伤害,因为其他模块需要产生对应的效果
                if (!e.JudgeCanHit())
                {
                    EventManager.Instance.TriggerEvent(new BattleLog(attacker.id.Value,
                        $"actor:{attacker.id.Value} local:{cmpt.AttackerLocalId} 未命中"));
                    e.ReplaceTimingTypeAtk((int) ListenType.AtkMis);
                    cmpt.Step = 2;
                    return;
                }

                e.ReplaceTimingTypeAtk((int) ListenType.Atking);
                cmpt.Step = 1;
                return;
            }

            //先盾牌防御,在减去护甲

            //判定阶段
            if (cmpt.Step == 1)
            {
                
                //伤害获取
                var damageValue = e.GetAtkValue();
                
                //减免(盾牌)
                if (c.hasCombatReduceDamage)
                {
                    damageValue -= c.combatReduceDamage.Value;
                }
                
                
                var target = GetOtherActor(c.combatMeleeWeapon.AttackerActorId);
                //目标判断
                var targetBuffMap = target.actorBuff.Value;
                
                
                //护甲buff抵消判断
                int defendValue = 0;
                if (targetBuffMap.ContainsKey((int) BuffType.Block_11))
                {
                    defendValue = targetBuffMap[(int) BuffType.Block_11];
                }

                bool isHurt = defendValue - damageValue < 0;

                
                //受伤
                if (isHurt)
                {
                    //尖刺反伤
                    if (targetBuffMap.ContainsKey((int) BuffType.Spikes_6))
                    {
                        attacker.OnGetBuffSpikesDamage(targetBuffMap[(int) BuffType.Spikes_6]);
                    }
                    
                    //受伤
                    target.GetHurt(damageValue);
                    
                    //造成伤害就吸血
                    var attackerBuffMap = attacker.actorBuff.Value;
                    attackerBuffMap.TryGetValue((int) BuffType.Vampirism_7, out var recoverValue);
                    if (recoverValue > 0)
                    {
                        attacker.OnGetVampirismRecover(recoverValue); 
                    }
                }
                //防御
                else
                {
                    //盾牌消耗
                    if (targetBuffMap.ContainsKey((int) BuffType.Block_11))
                    {
                        targetBuffMap[(int) BuffType.Block_11] -= (int) Fix64.Floor(damageValue);    
                    }
                }
                
                
                
                
                e.ReplaceTimingTypeAtk((int) ListenType.Atked);

                
                
                cmpt.Step = 2;
                return;
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