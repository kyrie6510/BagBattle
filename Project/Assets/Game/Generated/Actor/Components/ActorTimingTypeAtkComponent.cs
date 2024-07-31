//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ActorEntity {

    public Game.TimingTypeAtkComponent timingTypeAtk { get { return (Game.TimingTypeAtkComponent)GetComponent(ActorComponentsLookup.TimingTypeAtk); } }
    public bool hasTimingTypeAtk { get { return HasComponent(ActorComponentsLookup.TimingTypeAtk); } }

    public void AddTimingTypeAtk(int newValue, int newListenType) {
        var index = ActorComponentsLookup.TimingTypeAtk;
        var component = (Game.TimingTypeAtkComponent)CreateComponent(index, typeof(Game.TimingTypeAtkComponent));
        component.Value = newValue;
     
        AddComponent(index, component);
    }

    public void ReplaceTimingTypeAtk(int newValue, int newListenType) {
        var index = ActorComponentsLookup.TimingTypeAtk;
        var component = (Game.TimingTypeAtkComponent)CreateComponent(index, typeof(Game.TimingTypeAtkComponent));
        component.Value = newValue;
       
        ReplaceComponent(index, component);
    }

    public void RemoveTimingTypeAtk() {
        RemoveComponent(ActorComponentsLookup.TimingTypeAtk);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ActorEntity : ITimingTypeAtkEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class ActorMatcher {

    static Entitas.IMatcher<ActorEntity> _matcherTimingTypeAtk;

    public static Entitas.IMatcher<ActorEntity> TimingTypeAtk {
        get {
            if (_matcherTimingTypeAtk == null) {
                var matcher = (Entitas.Matcher<ActorEntity>)Entitas.Matcher<ActorEntity>.AllOf(ActorComponentsLookup.TimingTypeAtk);
                matcher.componentNames = ActorComponentsLookup.componentNames;
                _matcherTimingTypeAtk = matcher;
            }

            return _matcherTimingTypeAtk;
        }
    }
}
