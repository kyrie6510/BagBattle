namespace Game.Game
{
    /// <summary>
    /// 给Entity添加entity组件
    /// </summary>
    public interface IDecorate
    {
        /// <summary>
        /// 给entity添加 tim组件,在合适的时机 replace 组件,然后根据类型产生对应的buff entity ,buff entity用来监听
        /// </summary>
        /// <param name="e"></param>
        /// <param name="timConfigId"></param>
        public void Do(GameEntity e, int timConfigId);
    }
}