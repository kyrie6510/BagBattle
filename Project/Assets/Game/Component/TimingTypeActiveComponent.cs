using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Game
{
    [Game,Buff,Event(EventTarget.Self)]
    public class TimingTypeActiveComponent : IComponent
    {
        /// <summary>
        /// 0: 未激活 1:激活 (类型4)
        /// </summary>
        public int Value;
    }
}