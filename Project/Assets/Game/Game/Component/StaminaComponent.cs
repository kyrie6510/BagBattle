using Entitas;
using FixMath.NET;

namespace Game
{
    [Actor]
    public class StaminaComponent : IComponent
    {
        public Fix64 MaxValue;
        public Fix64 Value;
    }
}