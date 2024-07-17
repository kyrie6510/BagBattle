using Game.Actor;
using Game.Buff;
using Game.Combat;
using Game.Game;
using Game.Generated;

namespace Game
{
    
    
    
    public class World
    {

        private GameFeature _systems;

        internal  int Tick;
        
        public World(GameUser[] actors)
        {
            _systems = new GameFeature("world");

            _systems.Add(new ActorSystem(actors));
            _systems.Add(new GameSystem());
            _systems.Add(new CombatSystem());
            _systems.Add(new BuffSystem());

            _systems.Initialize();
            
        }

        public void Update()
        {
            Tick++;
            
            _systems.Execute();
            _systems.Cleanup();
        }
    }
}