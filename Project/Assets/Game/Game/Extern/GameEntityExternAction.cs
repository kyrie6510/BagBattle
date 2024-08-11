using FixMath.NET;
using Game;
using Game.Game;


public partial class GameEntity
{
    
    
    public void DoAttack()
    {

        var combat = Contexts.sharedInstance.combat.CreateEntity();
        var config =  ConfigManager.Instance.GetPropConfig((short) configId.Value);
        if (config.PropType == (int) PropType.MeleeWeapon)
        {
            combat.AddCombatMeleeWeapon(this.localId.value,this.actorId.Value,0);
        }
        else
        {
            combat.AddCombatRangedWeapon(this.localId.value,this.actorId.Value,0);
        }


        //EventManager.Instance.TriggerEvent(new OnLog($"冷却完成{localId.value}"));

        // if (CanAttack())
        // {
        //    var Id = actorId.Value == 0? 1: 0;
        //    var actor = Contexts.sharedInstance.actor.GetEntityWithId(Id);
        //    var v = UtilityRandom.Random.Next((int)attack.Value[0], (int)attack.Value[1] + 1);
        //    actor.ReplaceHp(actor.hp.MaxValue,actor.hp.Value- v);
        // }



        //以下全部针对buffEntity

        //攻击相关

        //2.玩家有一个攻击动作组件 攻击时  攻击未命中时 命中时 ,受到攻击组件 未收到攻击 受到攻击 受到未命中攻击 
        //3.然后根据我们的config给物体添加组件是否监听该对象的组件
        //4.在OnAttackActionCompt 每次replace中判断是否产生效果
    }


    public Fix64 GetDamage()
    {
        if (!hasAttack) return 0;
        var value = UtilityRandom.Random.Next((int)attack.Value[0], (int)attack.Value[1]);
        var buffs = Contexts.sharedInstance.buff.GetEntitiesWithAttachId(localId.value);
        foreach (var buff in buffs)
        {
            if (buff.hasBuffAdditionAttack)
            {
                value += (int)buff.buffAdditionAttack.Value;
            }
        }
        
        return value;
    }
    
    public bool JudgeCanHit()
    {
        if (!hasAtkRate) return false;
        var value = UtilityRandom.Random.Next(0, 100);
        
        EventManager.Instance.TriggerEvent(new BattleLog(actorId.Value,$"local:{localId.value} 概率判断：{value}"));
        
        return value <= atkRate.Value;
    }


 
}