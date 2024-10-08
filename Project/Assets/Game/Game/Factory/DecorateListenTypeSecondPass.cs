﻿using System.Collections.Generic;

namespace Game.Game.Factory
{
    public class DecorateListenTypeSecondPass : IDecorate
    {
       

        public void Do(GameEntity e, int timConfigId, List<int> effectId)
        {
            if (!ConfigManager.Instance.IsHaveTimingConfig((short) timConfigId))
            {
                return;
            }
            
            var timConfig = ConfigManager.Instance.GetTimConfig((short)timConfigId);
            
            // if (!e.hasTimingTypeAtk)
            // {
            //     e.AddTimingTypeAtk(0);    
            // }

            var buffEntity = FactoryEntity.CreatBuffEntity();
            
            buffEntity.AddBuffEffectId(effectId);
            buffEntity.AddAttachId(e.localId.value);
            buffEntity.AddTimingTypeSecondPass(timConfig.ListenValue(0),0);
            buffEntity.AddTimingConfigId(timConfigId);
        }
    }
}