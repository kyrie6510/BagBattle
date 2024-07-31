//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class TimingTypeHaveBuffEventSystem : Entitas.ReactiveSystem<ActorEntity> {

    readonly System.Collections.Generic.List<ITimingTypeHaveBuffListener> _listenerBuffer;

    public TimingTypeHaveBuffEventSystem(Contexts contexts) : base(contexts.actor) {
        _listenerBuffer = new System.Collections.Generic.List<ITimingTypeHaveBuffListener>();
    }

    protected override Entitas.ICollector<ActorEntity> GetTrigger(Entitas.IContext<ActorEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(ActorMatcher.TimingTypeHaveBuff)
        );
    }

    protected override bool Filter(ActorEntity entity) {
        return entity.hasTimingTypeHaveBuff && entity.hasTimingTypeHaveBuffListener;
    }

    protected override void Execute(System.Collections.Generic.List<ActorEntity> entities) {
        foreach (var e in entities) {
            var component = e.timingTypeHaveBuff;
            _listenerBuffer.Clear();
            _listenerBuffer.AddRange(e.timingTypeHaveBuffListener.value);
            foreach (var listener in _listenerBuffer) {
                listener.OnTimingTypeHaveBuff(e, component.Value);
            }
        }
    }
}
