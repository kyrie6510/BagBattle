using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Game
{
    [Game,Buff]
    public class TimingTypeAtkComponent : IComponent
    {
        /// <summary>
        /// 0.初始化 1.攻击时  2.未命中时  3.命中时 (类型 1 2 3)
        /// </summary>
        public int Value;
    }
}