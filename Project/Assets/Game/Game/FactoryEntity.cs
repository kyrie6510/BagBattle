using FixMath.NET;

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
            var e = Contexts.sharedInstance.game.CreateEntity();
            e.AddLocalId(_localId);
            _localId++;

            e.AddActorId((short)actorId);
            e.AddConfigId(configId);

            var config = ConfigManager.Instance.GetPropConfig((short) configId);

            //config
            var atk = config.GetDamageArray();
            e.AddAttack(new[] {(Fix64) atk[0], (Fix64) atk[1]});
            e.AddStaminaCost((Fix64)config.Power);
            e.AddCoolDownTime(0,(Fix64)config.Interval);
            
            
            //开始添加监听类型组件
            
            
            return e;
        }
    }
}