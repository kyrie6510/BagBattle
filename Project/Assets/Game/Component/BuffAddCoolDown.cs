using Entitas;
using Entitas.CodeGeneration.Attributes;
using FixMath.NET;

namespace Game
{
    [Buff]
    public class BuffAddCoolDown : IComponent
    {
        //百分比
        // value = 5 加快5%
        public Fix64 Value;


        [PrimaryEntityIndex]
        public int AttackLocalId;
    }
}