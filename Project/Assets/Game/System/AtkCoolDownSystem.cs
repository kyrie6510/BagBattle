using Entitas;

namespace Game
{
    public class AtkCoolDownSystem : IExecuteSystem
    {

        private IGroup<GameEntity> _ens;


        public AtkCoolDownSystem()
        {
            _ens = Contexts.sharedInstance.game.GetGroup(GameMatcher.CoolDownTime);
        }
        
        
        public void Execute()
        {
            foreach (var e in _ens)
            {
                var value = Time.TimeFromStart - e.coolDownTime.TimeSpan;
                if (value >= e.coolDownTime.Value)
                {
                    e.ReplaceCoolDownTime(e.coolDownTime.TimeSpan+ e.coolDownTime.Value,e.coolDownTime.Value);
                    e.DoAttack();
                }
                 
            }
            
            
        
            
        }
    }
}