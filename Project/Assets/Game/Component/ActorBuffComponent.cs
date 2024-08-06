using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Game
{
    [Actor,Event(EventTarget.Self)]
    public class ActorBuffComponent : IComponent
    {
        
        /// <summary>
        /// buff id 数量
        /// </summary>
        public Dictionary<int, int> Value;
    }
}