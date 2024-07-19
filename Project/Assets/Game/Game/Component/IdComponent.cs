using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Game
{
    [Actor]
    public class IdComponent : IComponent
    {
        [PrimaryEntityIndex]
        public int Value;
    }
}