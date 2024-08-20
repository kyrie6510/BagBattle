using FixMath.NET;
using Game.Game;
using Script;

namespace Game
{
    public class Simulation
    {
        private World _world;

        private IGameVictoryMode _victoryMode;
        private GameState _state;
        
        public Simulation(GameUser[] actors)
        {
            FactoryEntity.Init();
            UtilityRandom.InitRandom(1);

            
            
            _world = new World(actors);
            Time.SetWorld(_world);

            _victoryMode = new NormalVictory();
            
            _state = GameState.Running;
            
          
        }

        private float _tickTime = 0;
        
        public void Update(float deltaTime)
        {
            if (_state == GameState.Pause)
            {
                return;
            }

            if (_state == GameState.Over)
            {
                return;
            }
            
            if (_state == GameState.Running)
            {
                _tickTime += deltaTime;
            
                if (_tickTime >= Time.OneTickMilliSecond)
                {
                    _tickTime -= Time.OneTickMilliSecond;
                    _world.Update();
                }
                
                _victoryMode.Tick();
                
            }
            
           
        }


        public void OnGameOver()
        {
            _state = GameState.Over;
            _world.Reset();
            _tickTime = 0;
        }
        
    }
}