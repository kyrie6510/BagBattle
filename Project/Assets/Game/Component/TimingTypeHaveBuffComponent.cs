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
        ///  key buffId vale num 
        /// </summary>
        public Dictionary<int,int>  Value;
    }
}