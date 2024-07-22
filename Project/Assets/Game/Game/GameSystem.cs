namespace Game.Game
{
    public class GameSystem : Feature
    {
        public GameSystem()
        {
            Add(new ActorEventSystems(Contexts.sharedInstance));
            Add(new CoolDownSystem());
            
            
            
        }
        
        
    }
    
    
  
}