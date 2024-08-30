namespace Game
{
    public class NormalVictory: IGameVictoryMode
    {
        public void Tick()
        {

            var actors =  Contexts.sharedInstance.actor.GetEntities();

           
            
            foreach (var actor in actors)
            {
                if(!actor.hasHp) return;

                if (actor.hp.Value <= 0)
                {
                    
                    EventManager.Instance.TriggerEvent(new BattleLog(actor.id.Value, "失败"));
                    EventManager.Instance.TriggerEvent(new OnGameOver());

                    return;
                }
                
            }
            
            
        }
    }
}