using Entitas;
using FixMath.NET;

namespace Game
{
    [Game]
    public class AttackComponent: IComponent
    {
        //伤害
        public Fix64[] Value;
    }
}