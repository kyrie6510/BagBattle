using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Game
{
    /// <summary>
    /// 8.战斗开始 
    /// </summary>
    [Buff,Event(EventTarget.Self)
    ]
    public class TimingTypeGameStartComponent: IComponent
    {

    }
}