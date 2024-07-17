namespace Game.Generated
{
    public class GameFeature : Entitas.Systems
    {

        public GameFeature(string name)
        {
            
        }

        public override void Execute()
        {
            for (int i = 0; i < _executeSystems.Count; i++)
            {
                _executeSystems[i].Execute();
            }
        }
    }
}