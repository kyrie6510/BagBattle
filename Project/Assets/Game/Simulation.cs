using Script;

namespace Game
{
    public class Simulation
    {
        public int _tick;

        private World _world;

        public Simulation(GameUser[] actors)
        {
            _world = new World(actors);
            Time.SetWorld(_world);
        }

        public void Update()
        {
            _tick++;
            _world.Update();
            
        }


    }
}