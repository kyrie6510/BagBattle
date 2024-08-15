using System.Collections.Generic;

namespace Game.Game.Factory
{
    public class DecorateListenBattleStart : IDecorate
    {
        public void Do(GameEntity e, int timConfigId, List<int> effectId)
        { 
            if (!ConfigManager.Instance.IsHaveTimingConfig((short) timConfigId))
            {
                return;
            }
            
            var timConfig = ConfigManager.Instance.GetTimConfig((short)timConfigId);
            
           
            var buffEntity = FactoryEntity.CreatBuffEntity();
            buffEntity.AddBuffEffectId(effectId);
            buffEntity.AddTimingConfigId(timConfigId);

            buffEntity.isTimingTypeBattleStart = true;
            buffEntity.AddAttachId(e.localId.value);
        }
    }
}