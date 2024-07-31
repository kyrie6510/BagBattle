namespace Game.Game
{
    /// <summary>
    /// 用来给entity添加监听者
    /// </summary>
    public interface IDecorate
    {
        public void Do(GameEntity e, int timConfigId);
    }
}