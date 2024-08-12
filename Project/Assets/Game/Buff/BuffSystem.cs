

namespace Game.Buff
{
    public class BuffSystem : Feature
    {
        public BuffSystem()
        {
            Add(new BuffTimingAtkSystem());    
            Add(new BuffTimingEverHaveBuffSystem());
            Add(new BuffPoisonSystem());
        }
        
        
    }
}