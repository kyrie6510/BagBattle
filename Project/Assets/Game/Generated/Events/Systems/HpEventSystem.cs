//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class HpEventSystem : Entitas.ReactiveSystem<ActorEntity> {

    readonly System.Collections.Generic.List<IHpListener> _listenerBuffer;

    public HpEventSystem(Contexts contexts) : base(contexts.actor) {
        _listenerBuffer = new System.Collections.Generic.List<IHpListener>();
    }

    protected override Entitas.ICollector<ActorEntity> GetTrigger(Entitas.IContext<ActorEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(ActorMatcher.Hp)
        );
    }

    protected override bool Filter(ActorEntity entity) {
        return entity.hasHp && entity.hasHpListener;
    }

    protected override void Execute(System.Collections.Generic.List<ActorEntity> entities) {
        foreach (var e in entities) {
            var component = e.hp;
            _listenerBuffer.Clear();
            _listenerBuffer.AddRange(e.hpListener.value);
            foreach (var listener in _listenerBuffer) {
                listener.OnHp(e, component.MaxValue, component.Value);
            }
        }
    }
}