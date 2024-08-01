using Entitas;

namespace Game.Combat
{
    public class CombatRangedSystem : CombatBaseExecuteSystem
    
    
    {
        public CombatRangedSystem() : base(CombatMatcher.CombatRangedWeapon)
        {
            
            
        }
        
        protected override void Update(CombatEntity e)
        {
            base.Update(e);
        }
    }
}