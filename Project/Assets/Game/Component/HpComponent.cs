using Entitas;
using Entitas.CodeGeneration.Attributes;
using FixMath.NET;

namespace Game
{
    [Actor,Event(EventTarget.Self)]
    public class HpComponent : IComponent
    {
        public Fix64 MaxValue;
        public Fix64 Value;
    }
}