using Entitas;
using FixMath.NET;

namespace Game
{
    [Actor]
    public class HpComponent : IComponent
    {
        public Fix64 MaxValue;
        public Fix64 Value;
    }
}