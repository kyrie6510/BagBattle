using Game.Game;
using Game.Game.Factory;

namespace Game.Actor
{
    public class ActorSystem : Feature
    {
        public ActorSystem(GameUser[] actors)
        {
            
            //把UI数据转化成entity数据转换成
            foreach (var actor in actors)
            {
                var actorEntity = Contexts.sharedInstance.actor.CreateEntity();
                actorEntity.AddId(actor.ActorId);
                actorEntity.AddStamina(10,10);
                actorEntity.AddHp(100,100);
                
                //通知ActorView
                EventManager.Instance.TriggerEvent(new OnActorEntityCreat(){ActorId =  actor.ActorId, ActorEntity = actorEntity});
                
            }

            foreach (var actor in actors)
            {
                //创建物品
                foreach (var item in actor.Items)
                {
                    var e = FactoryEntity.CreatEntity(actor.ActorId, item.ConfigId);
                    //通知EntityView
                    EventManager.Instance.TriggerEvent(new OnGameEntityCreat{ViewLocalId =  item.LocalId, Entity = e});
                }
            }
            
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

                    var timConfig = ConfigManager.Instance.GetTimConfig((short)timId);
                
                
                    //攻击类型组件
                    if (timConfig.ListenType <= (int) ListenType.Atked)
                    {
                        IDecorate decorate = new DecorateListenTypeAtk();
                        decorate.Do(entity,timId);
                    }
                }
            }
        }
    }
}