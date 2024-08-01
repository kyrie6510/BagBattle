



using FixMath.NET;

public sealed partial class ActorEntity 
{
    //受到伤害
    public void GetDamage(Fix64 damageValue)
    {
        ReplaceHp(hp.MaxValue, hp.Value - damageValue);
    }
    
    
    
    
}

