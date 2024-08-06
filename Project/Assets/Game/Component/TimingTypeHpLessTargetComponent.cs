using Entitas;
using Entitas.CodeGeneration.Attributes;
using FixMath.NET;

namespace Game
{
    /// <summary>
    /// 类型 6 生命值低于Value时
    /// </summary>
    [Buff]
    public class TimingTypeHpLessTargetComponent : IComponent
    {
        public Fix64 Value;
    }
}