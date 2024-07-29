using Entitas;
using FixMath.NET;

namespace Game
{
    /// <summary>
    /// 11.进入xx状态
    /// </summary>
    [Actor]
    public class TimingTypeInStateComponent : IComponent
    {
        public int StateType;
        public Fix64 InStateTimeSpan;
    }
}