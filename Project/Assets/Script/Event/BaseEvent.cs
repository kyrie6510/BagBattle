namespace Script.Event
{
    public interface BaseEvent
    {
    
    }


    public struct OnItemSelectEvent : BaseEvent
    {
        public int LocalId;
    }
   
}