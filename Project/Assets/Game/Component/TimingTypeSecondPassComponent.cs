using Entitas;
using FixMath.NET;

namespace Game
{
    
    /// <summary>
    /// 10.每n秒
    /// </summary>
    [Game]
    public class TimingTypeSecondPassComponent : IComponent
    {
        public Fix64 Value;
        public Fix64 LastTimeSpan;
    }
}