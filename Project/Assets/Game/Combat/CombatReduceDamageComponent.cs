using Entitas;
using FixMath.NET;

namespace Game.Combat
{
    [Combat]
    public class CombatReduceDamageComponent: IComponent
    {
        public Fix64 Value;
    }
}