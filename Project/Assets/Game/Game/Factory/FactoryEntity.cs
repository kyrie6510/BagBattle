using FixMath.NET;
using Game.Game;
using Game.Game.Factory;
using Unity.VisualScripting;
using UnityEngine.Rendering;

namespace Game
{
    public static class FactoryEntity
    {
        private static int _gameEntityLocalId;
        private static int _buffEntityLocalId;
        public static void Init()
        {
           // _gameEntityLocalId = 0;
            _buffEntityLocalId = 0;
        }

        
  
        public static GameEntity CreatGameEntity(int actorId, int configId)
        {
            var actor = Contexts.sharedInstance.actor.GetEntityWithId(actorId);
            var e = Contexts.sharedInstance.game.CreateEntity();
//            e.AddLocalId(_gameEntityLocalId);
 //           _gameEntityLocalId++;

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

        public static BuffEntity CreatBuffEntity()
        {
            var e = Contexts.sharedInstance.buff.CreateEntity();
            e.AddLocalId(_buffEntityLocalId);
            _buffEntityLocalId++;
            return e;
        }
        
        
        public static CombatEntity CreatCombatEntity()
        {
            var e = Contexts.sharedInstance.combat.CreateEntity();
            return e;
        }
        
    }
}