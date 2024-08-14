using Entitas;
using UnityEngine.UIElements;

namespace Game.Buff
{
    public class BuffDestroySystem : BuffBaseExecuteSystem
    {
        public BuffDestroySystem() : base(BuffMatcher.Destroy)
        {
            
        }

        protected override void Update(BuffEntity buff)
        {
            buff.Destroy();
        }
    }
}