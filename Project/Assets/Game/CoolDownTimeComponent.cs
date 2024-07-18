using Entitas;
using FixMath.NET;

namespace Game
{
    
    [Game]
    public class CoolDownTimeComponent : IComponent
    {
        public Fix64 TimeSpan;
    }
}