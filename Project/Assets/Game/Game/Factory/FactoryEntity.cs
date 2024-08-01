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

            if (atk[1] != 0&& (config.PropType == (int)PropType.MeleeWeapon || config.PropType == (int)PropType.RangedWeapon))
            {
                e.AddAttack(new[] {(Fix64) atk[0], (Fix64) atk[1]});
                e.AddCoolDownTime(0,(Fix64)config.Interval);
                e.AddAtkRate(config.Rate);
            }
            e.AddStaminaCost((Fix64)config.Power);
            
            return e;
        }
    }
}