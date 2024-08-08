using System.Collections.Generic;
using Entitas;

namespace Game
{
    public class BuffBaseExecuteSystem: IExecuteSystem
    {
        private IGroup<BuffEntity> _group;

        private readonly List<BuffEntity> _list = new List<BuffEntity>();
        
        
        public BuffBaseExecuteSystem(IMatcher<BuffEntity> matcher)
        {
            _group = Contexts.sharedInstance.buff.GetGroup(matcher);
            _group.OnEntityAdded += OnAdd;
            _group.OnEntityRemoved += OnRemove;
        } 
        
        private void OnAdd(IGroup<BuffEntity> group, BuffEntity entity, int index, IComponent component)
        {
            _list.Add(entity);
        }

        private void OnRemove(IGroup<BuffEntity> group, BuffEntity entity, int index, IComponent component)
        {
            _list.Remove(entity);
        }
        
        public void Execute()
        {
            for (var i = 0; i < _list.Count; i++)
            {
                Update(_list[i]);
            }
                
        }
        protected virtual void Update(BuffEntity e)
        {
            
        }
    }
}