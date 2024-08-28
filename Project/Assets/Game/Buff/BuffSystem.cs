

namespace Game.Buff
{
    public class BuffSystem : Feature
    {
        public BuffSystem()
        {
            Add(new BuffBattleStartSystem() );
            
            Add(new BuffTimingSecondPassSystem());
            Add(new BuffTimingAtkSystem());    
            Add(new BuffTimingEverHaveBuffSystem());
            Add(new BuffPoisonSystem());
            Add(new BuffRegenerationSystem());

            Add(new BuffDestroySystem());

        }
        
        
    }
}