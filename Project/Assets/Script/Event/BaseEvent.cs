namespace Script.Event
{
    public interface BaseEvent
    {
    
    }


    public struct OnClick : BaseEvent
    {
        public int Id;
        public int X;
        public int Y;
    }
   
}