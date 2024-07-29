using Entitas;

namespace Game
{
    /// <summary>
    /// 获得n层b时
    /// </summary>
    [Actor]
    public class TimingTypeGetBuffComponent : IComponent
    {
        /// <summary>
        /// 类型 5.获得n层b时 
        /// </summary>
        public int BuffId;
        public int TargetBuffNum;
    }
}