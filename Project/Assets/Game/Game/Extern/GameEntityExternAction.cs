using Game;

public partial class GameEntity
{
    public void DoAction()
    {
        EventManager.Instance.TriggerEvent(new OnLog($"冷却完成{localId.value}"));
    }
}