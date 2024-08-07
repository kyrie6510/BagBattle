using System.Collections.Generic;
using Entitas;

namespace Game
{
    [Buff]
    public class BuffEffectIdComponent: IComponent
    {
        public List<int> Value;
    }
}