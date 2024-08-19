namespace Game.Buff
{
    public class BuffRegenerationSystem: BuffBaseExecuteSystem
    {
        
       
       

        public BuffRegenerationSystem(): base(BuffMatcher.BuffRegeneration)
        {
          
        }

        


        protected override void Update(BuffEntity buff)
        {
            //触发
            var perActiveTime = buff.buffRegeneration.PerActiveTime;
            var lastSpan = buff.buffRegeneration.LastSpan;
            var num = buff.buffRegeneration.Num;
            if (Time.TimeFromStart - lastSpan>=perActiveTime)
            {
                var otherActor = GetOtherActor(buff.attachActorId.Value);
                otherActor.OnGetBuffRecover(num);
                buff.ReplaceBuffRegeneration(num,perActiveTime+ lastSpan,perActiveTime);
            }
            
            
        }
    }
}