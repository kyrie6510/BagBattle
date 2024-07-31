//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public TimingTypeSecondPassListenerComponent timingTypeSecondPassListener { get { return (TimingTypeSecondPassListenerComponent)GetComponent(GameComponentsLookup.TimingTypeSecondPassListener); } }
    public bool hasTimingTypeSecondPassListener { get { return HasComponent(GameComponentsLookup.TimingTypeSecondPassListener); } }

    public void AddTimingTypeSecondPassListener(System.Collections.Generic.List<ITimingTypeSecondPassListener> newValue) {
        var index = GameComponentsLookup.TimingTypeSecondPassListener;
        var component = (TimingTypeSecondPassListenerComponent)CreateComponent(index, typeof(TimingTypeSecondPassListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceTimingTypeSecondPassListener(System.Collections.Generic.List<ITimingTypeSecondPassListener> newValue) {
        var index = GameComponentsLookup.TimingTypeSecondPassListener;
        var component = (TimingTypeSecondPassListenerComponent)CreateComponent(index, typeof(TimingTypeSecondPassListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveTimingTypeSecondPassListener() {
        RemoveComponent(GameComponentsLookup.TimingTypeSecondPassListener);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherTimingTypeSecondPassListener;

    public static Entitas.IMatcher<GameEntity> TimingTypeSecondPassListener {
        get {
            if (_matcherTimingTypeSecondPassListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.TimingTypeSecondPassListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherTimingTypeSecondPassListener = matcher;
            }

            return _matcherTimingTypeSecondPassListener;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public void AddTimingTypeSecondPassListener(ITimingTypeSecondPassListener value) {
        var listeners = hasTimingTypeSecondPassListener
            ? timingTypeSecondPassListener.value
            : new System.Collections.Generic.List<ITimingTypeSecondPassListener>();
        listeners.Add(value);
        ReplaceTimingTypeSecondPassListener(listeners);
    }

    public void RemoveTimingTypeSecondPassListener(ITimingTypeSecondPassListener value, bool removeComponentWhenEmpty = true) {
        var listeners = timingTypeSecondPassListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveTimingTypeSecondPassListener();
        } else {
            ReplaceTimingTypeSecondPassListener(listeners);
        }
    }
}
