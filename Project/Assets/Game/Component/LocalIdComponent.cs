using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Game
{
    [Game, Combat]
    public class LocalIdComponent:IComponent
    {
        [PrimaryEntityIndex] public int value;
    }
}

