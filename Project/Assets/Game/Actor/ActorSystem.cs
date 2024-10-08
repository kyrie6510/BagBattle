﻿using System.Collections.Generic;
using Game.Game;
using Game.Game.Factory;

namespace Game.Actor
{
    public class ActorSystem : Feature
    {
        public ActorSystem(GameUser[] actors)
        {

            Add(new StaminaRecoverSystem());
            
            
            //把UI数据转化成entity数据转换成
            foreach (var actor in actors)
            {
                var actorEntity = Contexts.sharedInstance.actor.CreateEntity();
                actorEntity.AddId(actor.ActorId);
                actorEntity.AddStamina(6,6,0);
                actorEntity.AddHp(100,100);
                actorEntity.AddActorBuff(new Dictionary<int, int>());
                //通知ActorView
                EventManager.Instance.TriggerEvent(new OnActorEntityCreat(){ActorId =  actor.ActorId, ActorEntity = actorEntity});
                
            }

            for (int i = 0; i < actors.Length; i++)
            {
                var actor = actors[i];
                //创建物品
                foreach (var item in actor.Items)
                {
                    if(item.State!= 1) continue;
                    
                    var e = FactoryEntity.CreatGameEntity(actor.ActorId, item.ConfigId);

                    e.AddLocalId(item.LocalId);
                    
                    //通知EntityView
                    EventManager.Instance.TriggerEvent(new OnGameEntityCreat{ViewLocalId =  item.LocalId, Entity = e});
                    
                    // 星物品
                    if (item.StarTargetLocalId.Count != 0)
                    {
                        e.AddStarTarget(item.StarTargetLocalId);
                    }

                    if (item.IsBag)
                    {
                        e.AddBag(item.BagItemId);
                    }
                    
                    
                }
            }
            
          
            
            
            
            
            // 1.攻击时 
            // 2.未命中时 
            // 3.命中时 
            // 4.激活时 
            // 5.获得n层b时 
            // 6.生命值低于n时 
            // 7.拥有n层b时 
            // 8.战斗开始 
            // 9.战斗触发n次 
            // 10.每n秒 
            // 11.进入xx状态
            // 12.进入商店
            //添加监听组件
            //开始添加监听类型组件
            var ens = Contexts.sharedInstance.game.GetEntities();
            foreach (var entity in ens)
            {
                
                var timEffectInfo = ConfigManager.Instance.GetConfigTimEffectInfo((short)entity.configId.Value);
                foreach (var item in timEffectInfo)
                {
                    var timId = item.Key;
                    var effectIds = timEffectInfo[timId];

                    if (!ConfigManager.Instance.IsHaveTimingConfig((short) timId))
                    {
                        continue;
                    }
                    
                    var timConfig = ConfigManager.Instance.GetTimConfig((short)timId);

                    var type = (ListenType)timConfig.ListenType;

                    IDecorate decorate = null;
                    // 
                    if ( type <=  ListenType.Atked&& type>0)  decorate = new DecorateListenTypeAtk();
                    else if (type == ListenType.SecondPass) decorate = new DecorateListenTypeSecondPass();
                    else if (type == ListenType.HaveBuf) decorate = new DecorateListenTypeHaveBuff();
                    else if (type == ListenType.EverHaveBuff) decorate = new DecorateListenTypeEverHaveBuff();
                    else if (type == ListenType.BattleStart) decorate = new DecorateListenBattleStart();
                    decorate?.Do(entity,timId,effectIds);
                }
            }
        }
    }
}