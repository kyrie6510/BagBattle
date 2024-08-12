using Entitas;
using FixMath.NET;

namespace Game.Buff
{
    [Buff]
    public class BuffPoisonComponent : IComponent
    {
        
        /// <summary>
        /// 当前数量
        /// </summary>
        public int Num;
        /// <summary>
        /// 上次触发时机
        /// </summary>
        public Fix64 LastSpan;
        
        /// <summary>
        /// 每几秒
        /// </summary>
        public Fix64 PerActiveTime;
    }
}