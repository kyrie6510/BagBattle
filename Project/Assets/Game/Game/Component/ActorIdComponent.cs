using Entitas;
using Entitas.CodeGeneration.Attributes;


namespace Game
{
    [Game]
    public class ActorIdComponent: IComponent
    {
        [EntityIndex] public short Value;
    }
} 