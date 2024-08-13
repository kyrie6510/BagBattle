using System.Collections.Generic;
using Entitas;


namespace Game.Buff
{
    public class BuffPoisonSystem : BuffBaseExecuteSystem
    {
        
       
       

        public BuffPoisonSystem(): base(BuffMatcher.BuffPoison)
        {
          
        }

        


        protected override void Update(BuffEntity buff)
        {
            //触发
            var perActiveTime = buff.buffPoison.PerActiveTime;
            var lastSpan = buff.buffPoison.LastSpan;
            var num = buff.buffPoison.Num;
            if (Time.TimeFromStart - lastSpan>=perActiveTime)
            {
                var otherActor = GetOtherActor(buff.attachActorId.Value);
                otherActor.OnGetBuffSpikesDamage(num);
                buff.ReplaceBuffPoison(num,perActiveTime+ lastSpan,perActiveTime);
            }
            
            
        }
    }
}