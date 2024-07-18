using Entitas;
using FixMath.NET;

namespace Game
{
    [Actor,Game]
    public class ActorIdComponent: IComponent
    {
        public Fix64 Value;
    }
}