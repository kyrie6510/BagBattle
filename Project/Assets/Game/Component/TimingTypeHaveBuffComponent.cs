using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Game
{
    /// <summary>
    /// 类型 7.拥有n层b时  
    /// </summary>
    [Buff]
    public class TimingTypeHaveBuffComponent : IComponent
    {
        
        /// <summary>
        /// 
        /// </summary>
        public int BuffId;
        public int BuffNum;

    }
}