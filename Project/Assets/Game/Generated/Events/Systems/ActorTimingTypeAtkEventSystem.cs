//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class ActorTimingTypeAtkEventSystem : Entitas.ReactiveSystem<ActorEntity> {

    readonly System.Collections.Generic.List<IActorTimingTypeAtkListener> _listenerBuffer;

    public ActorTimingTypeAtkEventSystem(Contexts contexts) : base(contexts.actor) {
        _listenerBuffer = new System.Collections.Generic.List<IActorTimingTypeAtkListener>();
    }

    protected override Entitas.ICollector<ActorEntity> GetTrigger(Entitas.IContext<ActorEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(ActorMatcher.TimingTypeAtk)
        );
    }

    protected override bool Filter(ActorEntity entity) {
        return entity.hasTimingTypeAtk && entity.hasActorTimingTypeAtkListener;
    }

    protected override void Execute(System.Collections.Generic.List<ActorEntity> entities) {
        foreach (var e in entities) {
            var component = e.timingTypeAtk;
            _listenerBuffer.Clear();
            _listenerBuffer.AddRange(e.actorTimingTypeAtkListener.value);
            foreach (var listener in _listenerBuffer) {
                listener.OnTimingTypeAtk(e, component.Value, component.ListenType);
            }
        }
    }
}
