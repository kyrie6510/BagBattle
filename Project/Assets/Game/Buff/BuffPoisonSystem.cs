using System.Collections.Generic;
using Entitas;


namespace Game.Buff
{
    public class BuffPoisonSystem : BuffBaseExecuteSystem
    {
        
        private IGroup<BuffEntity> _group;
        private readonly List<BuffEntity> _list = new ();


        public BuffPoisonSystem(): base(BuffMatcher.BuffPoison)
        {
            _group.OnEntityAdded += OnAdd;
            _group.OnEntityRemoved += OnRemove;
        }

        private void OnRemove(IGroup<BuffEntity> @group, BuffEntity entity, int index, IComponent component)
        {
            this._list.Remove(entity);
        }

        private void OnAdd(IGroup<BuffEntity> @group, BuffEntity entity, int index, IComponent component)
        {
            this._list.Add(entity);
        }


        protected override void Update(BuffEntity buff)
        {
            //触发
            if (Time.TimeFromStart - buff.buffPoison.LastSpan >= buff.buffPoison.PerActiveTime)
            {
                var otherActor = GetOtherActor(buff.attachActorId.Value);
                otherActor.OnGetBuffSpikesDamage(buff.buffPoison.Num);
                buff.ReplaceBuffPoison(buff.buffPoison.Num,buff.buffPoison.PerActiveTime+ buff.buffPoison.LastSpan,buff.buffPoison.PerActiveTime);
            }
            
            
        }
    }
}