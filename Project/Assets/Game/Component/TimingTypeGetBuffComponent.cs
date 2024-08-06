using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Game
{
    /// <summary>
    /// 获得n层b时
    /// </summary>
    [Buff]
    public class TimingTypeGetBuffComponent : IComponent
    {
        /// <summary>
        /// 类型 5.获得n层b时  key buffId vale num 
        /// </summary>
        public Dictionary<int,int>  Value;
    }
}