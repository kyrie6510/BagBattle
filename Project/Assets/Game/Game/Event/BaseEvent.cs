namespace Game
{
    public interface BaseEvent
    {
    
    }


    public struct OnItemSelectEvent : BaseEvent
    {
        public int LocalId;
    }
    
    
    public struct OnGamePlayEvent : BaseEvent
    {
        
    }


    public struct OnGameEntityCreat : BaseEvent
    {
        public int ViewLocalId;
        public GameEntity Entity;
    }

    public struct OnActorEntityCreat : BaseEvent
    {
        public int ActorId;
        public ActorEntity ActorEntity;
    }
    
    public struct OnLog : BaseEvent
    {
        public OnLog(string info)
        {
            this.Info = info;
        }
        
        public string Info;
    }
    
    public struct OnWorldTick : BaseEvent
    {
        public int Tick;
    }

}