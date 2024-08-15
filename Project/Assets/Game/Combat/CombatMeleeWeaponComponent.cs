using Entitas;

namespace Game
{
    [Combat]
    public class CombatMeleeWeapon : IComponent
    {
        public int AttackerLocalId;
        public int AttackerActorId;
        public int Step; // 0开始阶段 1攻击命中判定阶段 2.伤害计算阶段
       
    }
}