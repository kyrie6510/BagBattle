

using Game.Game;

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
                
                EventManager.Instance.TriggerEvent(new OnActorEntityCreat(){ActorId =  actor.ActorId, ActorEntity = actorEntity});
                
                
                //创建物品
                foreach (var item in actor.Items)
                {
                    var e = FactoryEntity.CreatEntity(actor.ActorId, item.ConfigId);
                    EventManager.Instance.TriggerEvent(new OnGameEntityCreat{ViewLocalId =  item.LocalId, Entity = e});
                }
            }
        }
    }
}