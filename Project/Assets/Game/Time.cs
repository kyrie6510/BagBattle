using FixMath.NET;

namespace Game
{
    public static class Time
    {
        private static World _world;
        
        //Tick 1 次 多少毫秒 
        public static int OneTickMilliSecond = 50;
        
        //倍速
        public static Fix64 TimeScale = 1;
        
        /// <summary>
        /// tick一次的时间
        /// </summary>
        public static Fix64 TickOnceTime{ get; private set; }
        
        //从游戏开始的时间
        public static Fix64 TimeFromStart => _world.Tick * TickOnceTime;
        
        
        public static void SetWorld(World newWorld)
        {
            _world = newWorld;
            TimeScale = 1;
            TickOnceTime = (Fix64)OneTickMilliSecond / 1000 * TimeScale;
        }
        
    }
}