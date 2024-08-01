using Game.Generated;

namespace Game.Combat
{
    public class CombatSystem : Feature
    {
        public CombatSystem(): base("combat")
        {
            Add(new CombatMeleeSystem());
            Add(new CombatRangedSystem());
        }
    }
}