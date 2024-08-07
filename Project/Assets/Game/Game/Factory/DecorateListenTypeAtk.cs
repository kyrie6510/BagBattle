using System.Collections.Generic;

namespace Game.Game.Factory
{
    public class DecorateListenTypeAtk : IDecorate
    {
        
        public void Do(GameEntity e, int timConfigId, List<int> effectId)
        {
            if (!ConfigManager.Instance.IsHaveTimingConfig((short) timConfigId))
            {
                return;
            }
            
            var timConfig = ConfigManager.Instance.GetTimConfig((short)timConfigId);
            
            if (!e.hasTimingTypeAtk)
            {
                e.AddTimingTypeAtk(0);    
            }

            var buffEntity = FactoryEntity.CreatBuffEntity();
            buffEntity.AddTimingTypeAtk(timConfig.ListenType);

            


        }
    }
}