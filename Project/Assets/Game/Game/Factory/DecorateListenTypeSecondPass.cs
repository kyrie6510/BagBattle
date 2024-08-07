using System.Collections.Generic;

namespace Game.Game.Factory
{
    public class DecorateListenTypeSecondPass : IDecorate
    {
       

        public void Do(GameEntity e, int timConfigId, List<int> effectId)
        {
            var timConfig = ConfigManager.Instance.GetTimConfig((short)timConfigId);
            
            var target = timConfig.ListenTarget;
            switch (target)
            {
                case (int)ListenTarget.Game:

                 
                    
                    break;
                
            }
        }
    }
}