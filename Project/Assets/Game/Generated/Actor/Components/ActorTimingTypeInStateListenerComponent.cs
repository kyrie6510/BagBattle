//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ActorEntity {

    public TimingTypeInStateListenerComponent timingTypeInStateListener { get { return (TimingTypeInStateListenerComponent)GetComponent(ActorComponentsLookup.TimingTypeInStateListener); } }
    public bool hasTimingTypeInStateListener { get { return HasComponent(ActorComponentsLookup.TimingTypeInStateListener); } }

    public void AddTimingTypeInStateListener(System.Collections.Generic.List<ITimingTypeInStateListener> newValue) {
        var index = ActorComponentsLookup.TimingTypeInStateListener;
        var component = (TimingTypeInStateListenerComponent)CreateComponent(index, typeof(TimingTypeInStateListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceTimingTypeInStateListener(System.Collections.Generic.List<ITimingTypeInStateListener> newValue) {
        var index = ActorComponentsLookup.TimingTypeInStateListener;
        var component = (TimingTypeInStateListenerComponent)CreateComponent(index, typeof(TimingTypeInStateListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveTimingTypeInStateListener() {
        RemoveComponent(ActorComponentsLookup.TimingTypeInStateListener);
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
public sealed partial class ActorMatcher {

    static Entitas.IMatcher<ActorEntity> _matcherTimingTypeInStateListener;

    public static Entitas.IMatcher<ActorEntity> TimingTypeInStateListener {
        get {
            if (_matcherTimingTypeInStateListener == null) {
                var matcher = (Entitas.Matcher<ActorEntity>)Entitas.Matcher<ActorEntity>.AllOf(ActorComponentsLookup.TimingTypeInStateListener);
                matcher.componentNames = ActorComponentsLookup.componentNames;
                _matcherTimingTypeInStateListener = matcher;
            }

            return _matcherTimingTypeInStateListener;
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
public partial class ActorEntity {

    public void AddTimingTypeInStateListener(ITimingTypeInStateListener value) {
        var listeners = hasTimingTypeInStateListener
            ? timingTypeInStateListener.value
            : new System.Collections.Generic.List<ITimingTypeInStateListener>();
        listeners.Add(value);
        ReplaceTimingTypeInStateListener(listeners);
    }

    public void RemoveTimingTypeInStateListener(ITimingTypeInStateListener value, bool removeComponentWhenEmpty = true) {
        var listeners = timingTypeInStateListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveTimingTypeInStateListener();
        } else {
            ReplaceTimingTypeInStateListener(listeners);
        }
    }
}
