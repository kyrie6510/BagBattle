using System.Collections.Generic;
using Entitas;

namespace Game
{
    public class CombatBaseExecuteSystem: IExecuteSystem
    {
        private IGroup<CombatEntity> _group;

        private readonly List<CombatEntity> _list = new List<CombatEntity>();
        
        
        public CombatBaseExecuteSystem(IMatcher<CombatEntity> matcher)
        {
            _group = Contexts.sharedInstance.combat.GetGroup(matcher);
            _group.OnEntityAdded += OnAdd;
            _group.OnEntityRemoved += OnRemove;
        } 
        
        private void OnAdd(IGroup<CombatEntity> group, CombatEntity entity, int index, IComponent component)
        {
            _list.Add(entity);
        }

        private void OnRemove(IGroup<CombatEntity> group, CombatEntity entity, int index, IComponent component)
        {
            _list.Remove(entity);
        }
        
        public void Execute()
        {
            for(int i= _list.Count-1;i>=0;i--)
            {
                Update(_list[i]);
            }
            
                
        }
        protected virtual void Update(CombatEntity e)
        {
            
        }

        public ActorEntity GetMyActor(int actorId)
        {
            return Contexts.sharedInstance.actor.GetEntityWithId(actorId);
        }
        
        public ActorEntity GetOtherActor(int actorId)
        {
            actorId = actorId == 1 ? 0 : 1;
            return Contexts.sharedInstance.actor.GetEntityWithId(actorId);
        }
        
    }
}