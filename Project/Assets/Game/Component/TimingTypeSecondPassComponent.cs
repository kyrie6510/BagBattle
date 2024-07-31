using Entitas;
using Entitas.CodeGeneration.Attributes;
using FixMath.NET;

namespace Game
{
    
    /// <summary>
    /// 10.每n秒
    /// </summary>
    [Game,Event(EventTarget.Self)]
    public class TimingTypeSecondPassComponent : IComponent
    {
        public Fix64 Value;
        public Fix64 LastTimeSpan;
    }
}