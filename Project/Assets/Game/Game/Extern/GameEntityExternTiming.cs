using System.Collections.Generic;
using Game;

public sealed  partial class GameEntity : IGameTimingTypeAtkListener , ITimingTypeHaveBuffListener
{
    
    
    
    public void OnTimingTypeAtk(GameEntity entity, int value)
    {
      //  EventManager.Instance.TriggerEvent(new OnLog($"value:{value}"));
    }

    public void OnTimingTypeHaveBuff(ActorEntity entity, Dictionary<int, int> value)
    {
      
    }
}