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
            var perActiveTime = buff.buffPoison.PerActiveTime;
            var lastSpan = buff.buffPoison.LastSpan;
            var num = buff.buffPoison.Num;
            if (Time.TimeFromStart - lastSpan>=perActiveTime)
            {
                var otherActor = GetOtherActor(buff.attachActorId.Value);
                otherActor.OnGetBuffSpikesDamage(num);
                buff.ReplaceBuffPoison(num,perActiveTime+ lastSpan,perActiveTime);
            }
            
            
        }
    }
}