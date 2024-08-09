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
        
        ReplaceActorBuff(buffMap);
    }
}