using Entitas;

namespace Game.Game
{
    public class CoolDownSystem : IExecuteSystem
    {

        private IGroup<GameEntity> _ens;


        public CoolDownSystem()
        {
           // _ens = Contexts.sharedInstance.game.GetGroup(GameMatcher.CoolDownTime);
        }
        
        
        public void Execute()
        {
            // foreach (var e in _ens)
            // {
            //     e.coolDownTime 
            // }
            //
            //
            // for (int i = 0; i < _ens.count; i++)
            // {
            //     var e = _ens[i];
            //     
            // }
            
        }
    }
}