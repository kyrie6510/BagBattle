//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Game.TimingTypeActiveComponent timingTypeActive { get { return (Game.TimingTypeActiveComponent)GetComponent(GameComponentsLookup.TimingTypeActive); } }
    public bool hasTimingTypeActive { get { return HasComponent(GameComponentsLookup.TimingTypeActive); } }

    public void AddTimingTypeActive(int newValue) {
        var index = GameComponentsLookup.TimingTypeActive;
        var component = (Game.TimingTypeActiveComponent)CreateComponent(index, typeof(Game.TimingTypeActiveComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceTimingTypeActive(int newValue) {
        var index = GameComponentsLookup.TimingTypeActive;
        var component = (Game.TimingTypeActiveComponent)CreateComponent(index, typeof(Game.TimingTypeActiveComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveTimingTypeActive() {
        RemoveComponent(GameComponentsLookup.TimingTypeActive);
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

    static Entitas.IMatcher<GameEntity> _matcherTimingTypeActive;

    public static Entitas.IMatcher<GameEntity> TimingTypeActive {
        get {
            if (_matcherTimingTypeActive == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.TimingTypeActive);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherTimingTypeActive = matcher;
            }

            return _matcherTimingTypeActive;
        }
    }
}
