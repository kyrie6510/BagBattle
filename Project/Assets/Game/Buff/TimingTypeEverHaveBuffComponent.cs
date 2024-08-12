using Entitas;

namespace Game.Combat
{
    
    
    /// <summary>
    /// 类型13 每拥有一层b
    /// </summary>
    [Buff]
    public class TimingTypeEverHaveBuffComponent: IComponent
    {
        public int BuffId;

        /// <summary>
        /// 上次生效时数量
        /// </summary>
        public int LastActiveNum;
    }
}