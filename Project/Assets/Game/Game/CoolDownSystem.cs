using Entitas;

namespace Game
{
    public class CoolDownSystem : IExecuteSystem
    {

        private IGroup<GameEntity> _ens;


        public CoolDownSystem()
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
                    e.coolDownTime.TimeSpan = Time.TimeFromStart;
                    e.DoAction();
                }
                 
            }
            
            
        
            
        }
    }
}