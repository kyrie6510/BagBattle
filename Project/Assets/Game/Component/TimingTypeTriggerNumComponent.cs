using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Game
{
    /// <summary>
    /// 9.战斗触发n次 
    /// </summary>
    [Game,Event(EventTarget.Self)]
    public class TimingTypeTriggerNumComponent : IComponent
    {
        public int Value;
    }
}