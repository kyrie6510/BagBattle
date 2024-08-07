using System.Collections.Generic;

namespace Game.Game
{
    /// <summary>
    ///给game entity,buff entity添加 tim组件,对于game entity tim就像相当于状态组件,在何时的时机replace改变状态,
    /// 对于buff entity 来监听我们gameEntity的状态组件.
    /// </summary>
    public interface IDecorate
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="timConfigId"></param>
        public void Do(GameEntity e, int timConfigId,List<int> effectId);
    }
}