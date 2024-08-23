using System.Collections.Generic;
using Entitas;

namespace Game
{
    [Game]
    public class BagComponent : IComponent
    {
        /// <summary>
        /// 包内物品的localId
        /// </summary>
        public HashSet<int> Value;
    }
}