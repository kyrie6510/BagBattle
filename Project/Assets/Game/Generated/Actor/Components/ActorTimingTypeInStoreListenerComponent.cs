//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ActorEntity {

    public TimingTypeInStoreListenerComponent timingTypeInStoreListener { get { return (TimingTypeInStoreListenerComponent)GetComponent(ActorComponentsLookup.TimingTypeInStoreListener); } }
    public bool hasTimingTypeInStoreListener { get { return HasComponent(ActorComponentsLookup.TimingTypeInStoreListener); } }

    public void AddTimingTypeInStoreListener(System.Collections.Generic.List<ITimingTypeInStoreListener> newValue) {
        var index = ActorComponentsLookup.TimingTypeInStoreListener;
        var component = (TimingTypeInStoreListenerComponent)CreateComponent(index, typeof(TimingTypeInStoreListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceTimingTypeInStoreListener(System.Collections.Generic.List<ITimingTypeInStoreListener> newValue) {
        var index = ActorComponentsLookup.TimingTypeInStoreListener;
        var component = (TimingTypeInStoreListenerComponent)CreateComponent(index, typeof(TimingTypeInStoreListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveTimingTypeInStoreListener() {
        RemoveComponent(ActorComponentsLookup.TimingTypeInStoreListener);
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

    static Entitas.IMatcher<ActorEntity> _matcherTimingTypeInStoreListener;

    public static Entitas.IMatcher<ActorEntity> TimingTypeInStoreListener {
        get {
            if (_matcherTimingTypeInStoreListener == null) {
                var matcher = (Entitas.Matcher<ActorEntity>)Entitas.Matcher<ActorEntity>.AllOf(ActorComponentsLookup.TimingTypeInStoreListener);
                matcher.componentNames = ActorComponentsLookup.componentNames;
                _matcherTimingTypeInStoreListener = matcher;
            }

            return _matcherTimingTypeInStoreListener;
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

    public void AddTimingTypeInStoreListener(ITimingTypeInStoreListener value) {
        var listeners = hasTimingTypeInStoreListener
            ? timingTypeInStoreListener.value
            : new System.Collections.Generic.List<ITimingTypeInStoreListener>();
        listeners.Add(value);
        ReplaceTimingTypeInStoreListener(listeners);
    }

    public void RemoveTimingTypeInStoreListener(ITimingTypeInStoreListener value, bool removeComponentWhenEmpty = true) {
        var listeners = timingTypeInStoreListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveTimingTypeInStoreListener();
        } else {
            ReplaceTimingTypeInStoreListener(listeners);
        }
    }
}