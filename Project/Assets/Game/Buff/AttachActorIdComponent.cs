using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Game.Buff
{
    [Buff]
    public class AttachActorIdComponent: IComponent
    {
       
        public int Value; 
    }
}