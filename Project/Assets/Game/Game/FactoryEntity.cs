using FixMath.NET;

namespace Game.Game
{
    public static class FactoryEntity
    {
        private static int _localId;

        public static void Init()
        {
            _localId = 0;
        }

        public static GameEntity CreatEntity(int actorId, int configId)
        {
            var e = Contexts.sharedInstance.game.CreateEntity();
            e.AddLocalId(_localId);
            _localId++;

            e.AddActorId(actorId);
            e.AddConfigId(configId);

            var config = ConfigManager.Instance.GetPropConfig((short) configId);

            //config
            var atk = config.GetDamageArray();
            e.AddAttack(new[] {(Fix64) atk[0], (Fix64) atk[1]});
            e.AddStaminaCost(config.Power);
            e.AddCoolDownTime(0,config.Interval);

            return e;
        }
    }
}