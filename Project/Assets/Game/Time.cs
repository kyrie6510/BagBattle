using FixMath.NET;

namespace Game
{
    public static class Time
    {
        private static World _world;
        
        //一帧多少毫秒
        private static int _frameMilliSecond = 50;
        
        //倍速
        public static Fix64 TimeScale = 1;
        
        /// <summary>
        /// 一帧的时间
        /// </summary>
        public static Fix64 FrameTime{ get; private set; }
        
        //从游戏开始的时间
        public static Fix64 TimeFromStart => _world.Tick * FrameTime;
        
        
        public static void SetWorld(World newWorld)
        {
            _world = newWorld;
            TimeScale = 1;
            FrameTime = (Fix64)_frameMilliSecond / 1000 * TimeScale;
        }
        
    }
}