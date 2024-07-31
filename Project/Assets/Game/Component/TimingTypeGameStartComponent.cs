using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Game
{
    /// <summary>
    /// 8.战斗开始 
    /// </summary>
    [Game,Event(EventTarget.Self)
    ]
    public class TimingTypeGameStartComponent: IComponent
    {

    }
}