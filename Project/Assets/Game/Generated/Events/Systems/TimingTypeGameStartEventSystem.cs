//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class TimingTypeGameStartEventSystem : Entitas.ReactiveSystem<GameEntity> {

    readonly System.Collections.Generic.List<ITimingTypeGameStartListener> _listenerBuffer;

    public TimingTypeGameStartEventSystem(Contexts contexts) : base(contexts.game) {
        _listenerBuffer = new System.Collections.Generic.List<ITimingTypeGameStartListener>();
    }

    protected override Entitas.ICollector<GameEntity> GetTrigger(Entitas.IContext<GameEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(GameMatcher.TimingTypeGameStart)
        );
    }

    protected override bool Filter(GameEntity entity) {
        return entity.isTimingTypeGameStart && entity.hasTimingTypeGameStartListener;
    }

    protected override void Execute(System.Collections.Generic.List<GameEntity> entities) {
        foreach (var e in entities) {
            
            _listenerBuffer.Clear();
            _listenerBuffer.AddRange(e.timingTypeGameStartListener.value);
            foreach (var listener in _listenerBuffer) {
                listener.OnTimingTypeGameStart(e);
            }
        }
    }
}
