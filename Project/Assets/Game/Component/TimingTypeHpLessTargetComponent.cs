using Entitas;
using Entitas.CodeGeneration.Attributes;
using FixMath.NET;

namespace Game
{
    /// <summary>
    /// 类型 6 生命值低于Value时
    /// </summary>
    [Actor,Event(EventTarget.Self)]
    public class TimingTypeHpLessTargetComponent : IComponent
    {
        public Fix64 Value;
    }
}