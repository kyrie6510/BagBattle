using System.Collections.Generic;

public sealed  partial class GameEntity : IGameTimingTypeAtkListener , ITimingTypeHaveBuffListener
{
    public void OnTimingTypeAtk(GameEntity entity, int value)
    {
        
    }

    public void OnTimingTypeHaveBuff(ActorEntity entity, Dictionary<int, int> value)
    {
      
    }
}