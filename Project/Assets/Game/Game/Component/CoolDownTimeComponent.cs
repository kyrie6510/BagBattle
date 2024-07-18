using Entitas;
using FixMath.NET;

namespace Game
{
    
    [Game]
    public class CoolDownTimeComponent : IComponent
    {
        //上次回复冷却时间
        public Fix64 TimeSpan;
        
        public Fix64 Value;
    }
}