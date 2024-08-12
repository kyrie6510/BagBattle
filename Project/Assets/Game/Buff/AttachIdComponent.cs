using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Game
{
    /// <summary>
    /// 附着在道具上的道具Id
    /// </summary>
    [Buff]
    public class AttachIdComponent : IComponent
    {
        [EntityIndex]
        public int Value;
    }
}