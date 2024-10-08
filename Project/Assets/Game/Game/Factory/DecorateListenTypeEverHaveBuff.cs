﻿using System.Collections.Generic;

namespace Game.Game.Factory
{
    public class DecorateListenTypeEverHaveBuff : IDecorate
    {
        public void Do(GameEntity e, int timConfigId, List<int> effectId)
        {
            if (!ConfigManager.Instance.IsHaveTimingConfig((short) timConfigId))
            {
                return;
            }
            
            var timConfig = ConfigManager.Instance.GetTimConfig((short)timConfigId);
            
            var target = timConfig.ListenTarget;
            switch (target)
            {
                case (int)ListenTarget.MyActor:
                    var actor = Contexts.sharedInstance.actor.GetEntityWithId(e.actorId.Value);
                    
                    var buffEntity = FactoryEntity.CreatBuffEntity();
                    buffEntity.AddBuffEffectId(effectId);
                    buffEntity.AddTimingConfigId(timConfigId);
            
                    buffEntity.AddTimingTypeEverHaveBuff(timConfig.ListenValue(0),0);
                    buffEntity.AddAttachId(e.localId.value);
                    
                    break;
                
            }
        }
    }
}