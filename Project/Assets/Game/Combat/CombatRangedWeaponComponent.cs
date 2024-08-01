using Entitas;

namespace Game
{
    [Combat]
    public class CombatRangedWeaponComponent: IComponent
    {
        public int AttackerLocalId;
        public int AttackerActorId;
        public int Step;
    }
}