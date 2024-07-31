//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Game.TimingTypeTriggerNumComponent timingTypeTriggerNum { get { return (Game.TimingTypeTriggerNumComponent)GetComponent(GameComponentsLookup.TimingTypeTriggerNum); } }
    public bool hasTimingTypeTriggerNum { get { return HasComponent(GameComponentsLookup.TimingTypeTriggerNum); } }

    public void AddTimingTypeTriggerNum(int newValue) {
        var index = GameComponentsLookup.TimingTypeTriggerNum;
        var component = (Game.TimingTypeTriggerNumComponent)CreateComponent(index, typeof(Game.TimingTypeTriggerNumComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceTimingTypeTriggerNum(int newValue) {
        var index = GameComponentsLookup.TimingTypeTriggerNum;
        var component = (Game.TimingTypeTriggerNumComponent)CreateComponent(index, typeof(Game.TimingTypeTriggerNumComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveTimingTypeTriggerNum() {
        RemoveComponent(GameComponentsLookup.TimingTypeTriggerNum);
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

    static Entitas.IMatcher<GameEntity> _matcherTimingTypeTriggerNum;

    public static Entitas.IMatcher<GameEntity> TimingTypeTriggerNum {
        get {
            if (_matcherTimingTypeTriggerNum == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.TimingTypeTriggerNum);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherTimingTypeTriggerNum = matcher;
            }

            return _matcherTimingTypeTriggerNum;
        }
    }
}