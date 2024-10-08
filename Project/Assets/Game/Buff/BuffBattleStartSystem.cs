﻿using Entitas;

namespace Game.Buff
{
    public class BuffBattleStartSystem : IInitializeSystem, ITearDownSystem
    {
        private IGroup<BuffEntity> _group;


        public BuffBattleStartSystem()
        {
            _group = Contexts.sharedInstance.buff.GetGroup(BuffMatcher.TimingTypeBattleStart);
            _group.OnEntityAdded += OnAdd;
            _group.OnEntityRemoved += OnRemove;
        }
        
        public void Initialize()
        {
            
           
        }
        
        public void TearDown()
        {
           
            _group.OnEntityAdded -= OnAdd;
            _group.OnEntityRemoved -= OnRemove;
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
                        
               
                EffectManager.Instance.CreatEffect(effectId, e.actorId.Value, e.localId.value);
            }
            
            
            buff.Destroy();
        }

      
    
        
        
        
        
        
    }
}