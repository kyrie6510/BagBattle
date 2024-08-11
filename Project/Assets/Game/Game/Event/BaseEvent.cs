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

    public struct BattleLog : BaseEvent
    {
        public BattleLog(int actorId, string info)
        {

            if (actorId == 0)
            {
                Info = $"<color=#ff0000>{info}</color>";
            }
            else
            {
                Info = $"<color=#fff100>{info}</color>";
            }
            
            this.ActorId = actorId;
        }

        public string Info;
        public int ActorId;
    }

    public struct OnWorldTick : BaseEvent
    {
        public int Tick;
    }
}

