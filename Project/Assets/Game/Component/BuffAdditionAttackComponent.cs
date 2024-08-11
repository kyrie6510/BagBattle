using Entitas;
using FixMath.NET;

namespace Game
{
    /// <summary>
    /// buff 效果增加攻击力
    /// </summary>
    [Buff]
    public class BuffAdditionAttackComponent : IComponent
    {
        public Fix64 Value;
        public int GameEntityLocalId;
    }
}