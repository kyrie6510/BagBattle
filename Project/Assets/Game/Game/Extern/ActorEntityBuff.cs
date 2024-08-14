using Game;

public sealed partial class ActorEntity : Entitas.Entity
{
    /// <summary>
    /// 添加固定里类型buff
    /// </summary>
    /// <param name="buffId"></param>
    /// <param name="num"></param>
    public void AddBuff(int buffId, int num)
    {
        if (!hasActorBuff) return;


        var buffMap = actorBuff.Value;
        if (!buffMap.ContainsKey(buffId))
        {
            buffMap.Add(buffId, num);
        }
        else
        {
            buffMap[buffId] += num;
        }

        if (buffId == (int)BuffType.Poison_10)
        {
            var buff = Contexts.sharedInstance.buff.GetEntityWithAttachActorId(id.Value);
            if (buff == null)
            {
                buff = FactoryEntity.CreatBuffEntity();
                buff.AddAttachActorId(this.id.Value);
                buff.AddBuffPoison(num,Time.TimeFromStart,2);
            }
            else
            {
                var curNum = buff.buffPoison.Num;
                buff.ReplaceBuffPoison(curNum+ num,buff.buffPoison.LastSpan,2);
            }
            
        }
        
        
        ReplaceActorBuff(buffMap);
    }


    public ActorEntity GetOtherActor()
    {
        var actorId = id.Value;
        actorId = actorId == 1 ? 0 : 1;
        return Contexts.sharedInstance.actor.GetEntityWithId(actorId);
    }
}