using System.Collections.Generic;
using Entitas;

namespace Game
{
    [Game]
    public class StarTargetComponent: IComponent
    {
        public HashSet<int> Value;
    }
}