
using System;
using FixMath.NET;
using Game;

public partial class BuffEntity
{
    public Fix64 GetCoolDownTime()
    {
        if (hasTimingTypeSecondPass)
        {
            var second = timingTypeSecondPass.Value;
            
            var e = Contexts.sharedInstance.game.GetEntityWithLocalId(attachId.Value);
            
            

            Fix64 buffValue = 0;
            var targetBuff =  Contexts.sharedInstance.buff.GetEntityWithBuffAddCoolDown(localId.value);
            if (targetBuff != null)
            {
                buffValue = targetBuff.buffAddCoolDown.Value;
            }
            
            var percent = 100 + e.GetActor().GetBuffCoolDownAddition()  - buffValue;
            if (percent <= 0) return 0;

            return second *  percent/100;
        }
        
        return Int32.MaxValue;
    }
    
    
    
    
    
    
    
}
