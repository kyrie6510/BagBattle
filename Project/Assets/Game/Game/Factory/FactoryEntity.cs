using FixMath.NET;
using Game.Game;
using Game.Game.Factory;
using Unity.VisualScripting;
using UnityEngine.Rendering;

namespace Game
{
    public static class FactoryEntity
    {
        private static int _localId;

        public static void Init()
        {
            _localId = 0;
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
        public static GameEntity CreatEntity(int actorId, int configId)
        {
            var actor = Contexts.sharedInstance.actor.GetEntityWithId(actorId);
            var e = Contexts.sharedInstance.game.CreateEntity();
            e.AddLocalId(_localId);
            _localId++;

            e.AddActorId((short)actorId);
            e.AddConfigId(configId);

            var config = ConfigManager.Instance.GetPropConfig((short) configId);

            //config
            var atk = config.GetDamageArray();

            if (atk[1] != 0)
            {
                e.AddAttack(new[] {(Fix64) atk[0], (Fix64) atk[1]});
                e.AddCoolDownTime(0,(Fix64)config.Interval);
            }
            e.AddStaminaCost((Fix64)config.Power);
            
            return e;
        }
    }
}