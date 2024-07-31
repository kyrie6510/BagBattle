//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public TimingTypeTriggerNumListenerComponent timingTypeTriggerNumListener { get { return (TimingTypeTriggerNumListenerComponent)GetComponent(GameComponentsLookup.TimingTypeTriggerNumListener); } }
    public bool hasTimingTypeTriggerNumListener { get { return HasComponent(GameComponentsLookup.TimingTypeTriggerNumListener); } }

    public void AddTimingTypeTriggerNumListener(System.Collections.Generic.List<ITimingTypeTriggerNumListener> newValue) {
        var index = GameComponentsLookup.TimingTypeTriggerNumListener;
        var component = (TimingTypeTriggerNumListenerComponent)CreateComponent(index, typeof(TimingTypeTriggerNumListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceTimingTypeTriggerNumListener(System.Collections.Generic.List<ITimingTypeTriggerNumListener> newValue) {
        var index = GameComponentsLookup.TimingTypeTriggerNumListener;
        var component = (TimingTypeTriggerNumListenerComponent)CreateComponent(index, typeof(TimingTypeTriggerNumListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveTimingTypeTriggerNumListener() {
        RemoveComponent(GameComponentsLookup.TimingTypeTriggerNumListener);
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

    static Entitas.IMatcher<GameEntity> _matcherTimingTypeTriggerNumListener;

    public static Entitas.IMatcher<GameEntity> TimingTypeTriggerNumListener {
        get {
            if (_matcherTimingTypeTriggerNumListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.TimingTypeTriggerNumListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherTimingTypeTriggerNumListener = matcher;
            }

            return _matcherTimingTypeTriggerNumListener;
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

    public void AddTimingTypeTriggerNumListener(ITimingTypeTriggerNumListener value) {
        var listeners = hasTimingTypeTriggerNumListener
            ? timingTypeTriggerNumListener.value
            : new System.Collections.Generic.List<ITimingTypeTriggerNumListener>();
        listeners.Add(value);
        ReplaceTimingTypeTriggerNumListener(listeners);
    }

    public void RemoveTimingTypeTriggerNumListener(ITimingTypeTriggerNumListener value, bool removeComponentWhenEmpty = true) {
        var listeners = timingTypeTriggerNumListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveTimingTypeTriggerNumListener();
        } else {
            ReplaceTimingTypeTriggerNumListener(listeners);
        }
    }
}
