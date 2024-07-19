using System;

namespace Game.Game
{
    internal static class UtilityRandom
    {
        private static Random _random;
        private static int _useCount;
        
        internal static Random random
        {
            get
            {
                _useCount++;
                return _random;
            }
            set
            {
                _random = value;
            }
        }
        
        
        internal static void InitRandom(int seed)
        {
            _useCount = 0;
            _random = new Random(seed);
            _useCount = 0;
        }
        
    }
}