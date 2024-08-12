using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Game.Buff
{
    [Buff]
    public class AttachActorIdComponent: IComponent
    {
        [PrimaryEntityIndex]
        public int Value; 
    }
}