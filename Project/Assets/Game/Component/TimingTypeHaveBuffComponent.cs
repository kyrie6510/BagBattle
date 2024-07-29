using Entitas;

namespace Game
{
    /// <summary>
    /// 类型 7.拥有n层b时  
    /// </summary>
    [Actor]
    public class TimingTypeHaveBuffComponent : IComponent
    {
     
        public int BuffId;
        public int TargetBuffNum;
    }
}