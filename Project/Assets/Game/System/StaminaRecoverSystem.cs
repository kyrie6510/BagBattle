using Entitas;

namespace Game
{
    public class StaminaRecoverSystem : IExecuteSystem
    {
        private IGroup<ActorEntity> _actors;


        public StaminaRecoverSystem()
        {
            _actors = Contexts.sharedInstance.actor.GetGroup(ActorMatcher.Stamina);
        }

        public void Execute()
        {
            foreach (var actor in _actors)
            {
                var lastTimeSpan = actor.stamina.LastCoverSpan;
                if (Time.TimeFromStart - lastTimeSpan >= 1)
                {
                    var addValue = actor.stamina.Value + 1 >= actor.stamina.MaxValue? actor.stamina.MaxValue : actor.stamina.Value + 1;
                    
                    
                    actor.ReplaceStamina(actor.stamina.MaxValue, addValue,
                        actor.stamina.LastCoverSpan + 1);
                }
            }
        }
    }
}