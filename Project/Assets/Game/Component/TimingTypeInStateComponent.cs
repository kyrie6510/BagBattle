using Entitas;
using Entitas.CodeGeneration.Attributes;
using FixMath.NET;

namespace Game
{
    /// <summary>
    /// 11.进入xx状态
    /// </summary>
    [Actor,Event(EventTarget.Self)]
    public class TimingTypeInStateComponent : IComponent
    {
        public int StateType;
        public Fix64 InStateTimeSpan;
    }
}