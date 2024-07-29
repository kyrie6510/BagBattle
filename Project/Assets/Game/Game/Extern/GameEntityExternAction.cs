using FixMath.NET;
using Game;


public partial class GameEntity: IHpListener
{
    // 输入：s = "the sky is blue"
    // 输出："blue is sky the"
    public string ReverseWords(string s)
    {

        string res = "";
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == ' ')
            {
                continue;
            }
            
            int left = i;
            int right = i;
            while (s[right]!= ' '&& right < s.Length)
            {
                right++;
            }

            string tempStr = s.Substring(i, right - left);
            res = tempStr + " " + res;
        }

        return res;


    }
    
    public void DoAttack()
    {

        var combat = Contexts.sharedInstance.combat.CreateEntity();
        // combat


        //EventManager.Instance.TriggerEvent(new OnLog($"冷却完成{localId.value}"));

        // if (CanAttack())
        // {
        //    var Id = actorId.Value == 0? 1: 0;
        //    var actor = Contexts.sharedInstance.actor.GetEntityWithId(Id);
        //    var v = UtilityRandom.random.Next((int)attack.Value[0], (int)attack.Value[1] + 1);
        //    actor.ReplaceHp(actor.hp.MaxValue,actor.hp.Value- v);
        // }



        //以下全部针对buffEntity

        //攻击相关

        //2.玩家有一个攻击动作组件 攻击时  攻击未命中时 命中时 ,受到攻击组件 未收到攻击 受到攻击 受到未命中攻击 
        //3.然后根据我们的config给物体添加组件是否监听该对象的组件
        //4.在OnAttackActionCompt 每次replace中判断是否产生效果






    }

    // public bool CanAttack()
    // {
    //     return attack.Value[0] != 0 || attack.Value[1] != 0;
    // }
    

    public void OnHp(ActorEntity entity, Fix64 maxValue, Fix64 value)
    {
        var config = ConfigManager.Instance.GetPropConfig((short) this.configId.Value);
        
        
        
        
        throw new System.NotImplementedException();
    }
}