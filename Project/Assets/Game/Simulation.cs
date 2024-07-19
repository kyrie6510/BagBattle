using FixMath.NET;
using Game.Game;
using Script;

namespace Game
{
    public class Simulation
    {
        //public int _tick;

        private World _world;

        public Simulation(GameUser[] actors)
        {
            FactoryEntity.Init();
 
            _world = new World(actors);
            Time.SetWorld(_world);
            
        }

        private float _tickTime = 0;
        
        public void Update(float deltaTime)
        {
            _tickTime += deltaTime;
            
            if (_tickTime >= Time._frameMilliSecond)
            {
                _tickTime -= Time._frameMilliSecond;
                _world.Update();
            }
            
          
            
        }


    }
}