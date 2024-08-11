using FixMath.NET;
using Game.Game;
using Script;

namespace Game
{
    public class Simulation
    {
        

        private World _world;

        public Simulation(GameUser[] actors)
        {
            FactoryEntity.Init();
            UtilityRandom.InitRandom(1);
            
            _world = new World(actors);
            Time.SetWorld(_world);
            
        }

        private float _tickTime = 0;
        
        public void Update(float deltaTime)
        {
            _tickTime += deltaTime;
            
            if (_tickTime >= Time.OneTickMilliSecond)
            {
                _tickTime -= Time.OneTickMilliSecond;
                _world.Update();
            }
            
          
            
        }


    }
}