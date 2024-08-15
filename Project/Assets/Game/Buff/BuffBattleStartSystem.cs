using Entitas;

namespace Game.Buff
{
    public class BuffBattleStartSystem : IInitializeSystem, ITearDownSystem
    {
        public void Initialize()
        {
            var group = Contexts.sharedInstance.buff.GetGroup(BuffMatcher.TimingTypeBattleStart);
            group.OnEntityAdded += OnAdd;
            group.OnEntityRemoved += OnRemove;
        }
        
        public void TearDown()
        {
            var group = Contexts.sharedInstance.buff.GetGroup(BuffMatcher.TimingTypeBattleStart);
            group.OnEntityAdded -= OnAdd;
            group.OnEntityRemoved -= OnRemove;
        }

        private void OnRemove(IGroup<BuffEntity> @group, BuffEntity entity, int index, IComponent component)
        {
           
        }

        private void OnAdd(IGroup<BuffEntity> @group, BuffEntity buff, int index, IComponent component)
        {
            var config = ConfigManager.Instance.GetTimConfig(buff.timingConfigId.Value);

            var e = Contexts.sharedInstance.game.GetEntityWithLocalId(buff.attachId.Value);

          
            //触发效果
            foreach (var effectId in buff.buffEffectId.Value)
            {
                var effectConfig = ConfigManager.Instance.GetEffectConfig(effectId);
                        
                EventManager.Instance.TriggerEvent(new BattleLog(e.actorId.Value, $"actor:{e.actorId.Value} {effectConfig.Name}"));
                EffectManager.Instance.CreatEffect(effectId, e.actorId.Value, e.localId.value, buff.localId.value);
            }
            
            
            buff.Destroy();
        }

      
    
        
        
        
        
        
    }
}