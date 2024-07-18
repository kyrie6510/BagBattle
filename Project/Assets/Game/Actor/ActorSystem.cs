

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
                actorEntity.AddActorId(actor.ActorId);

                //创建物品
                foreach (var item in actor.Items)
                {
                    FactoryEntity.CreatEntity(actor.ActorId, item.ConfigId);
                }
            }
        }
    }
}