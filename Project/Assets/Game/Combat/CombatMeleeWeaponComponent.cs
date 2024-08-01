using Entitas;

namespace Game
{
    [Combat]
    public class CombatMeleeWeapon : IComponent
    {
        public int AttackerLocalId;
        public int AttackerActorId;
        public int Step;
    }
}