using Entitas;
using FixMath.NET;

namespace Game
{
    /// <summary>
    /// buff 效果增加攻击力
    /// </summary>
    [Buff]
    public class BuffAdditionAttackOnceComponent : IComponent
    {
        public Fix64 Value;
    }
}