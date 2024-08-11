//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class BuffEntity {

    public Game.Combat.TimingTypeEverHaveBuffComponent timingTypeEverHaveBuff { get { return (Game.Combat.TimingTypeEverHaveBuffComponent)GetComponent(BuffComponentsLookup.TimingTypeEverHaveBuff); } }
    public bool hasTimingTypeEverHaveBuff { get { return HasComponent(BuffComponentsLookup.TimingTypeEverHaveBuff); } }

    public void AddTimingTypeEverHaveBuff(int newBuffId, int newLastActiveNum) {
        var index = BuffComponentsLookup.TimingTypeEverHaveBuff;
        var component = (Game.Combat.TimingTypeEverHaveBuffComponent)CreateComponent(index, typeof(Game.Combat.TimingTypeEverHaveBuffComponent));
        component.BuffId = newBuffId;
        component.LastActiveNum = newLastActiveNum;
        AddComponent(index, component);
    }

    public void ReplaceTimingTypeEverHaveBuff(int newBuffId, int newLastActiveNum) {
        var index = BuffComponentsLookup.TimingTypeEverHaveBuff;
        var component = (Game.Combat.TimingTypeEverHaveBuffComponent)CreateComponent(index, typeof(Game.Combat.TimingTypeEverHaveBuffComponent));
        component.BuffId = newBuffId;
        component.LastActiveNum = newLastActiveNum;
        ReplaceComponent(index, component);
    }

    public void RemoveTimingTypeEverHaveBuff() {
        RemoveComponent(BuffComponentsLookup.TimingTypeEverHaveBuff);
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
public sealed partial class BuffMatcher {

    static Entitas.IMatcher<BuffEntity> _matcherTimingTypeEverHaveBuff;

    public static Entitas.IMatcher<BuffEntity> TimingTypeEverHaveBuff {
        get {
            if (_matcherTimingTypeEverHaveBuff == null) {
                var matcher = (Entitas.Matcher<BuffEntity>)Entitas.Matcher<BuffEntity>.AllOf(BuffComponentsLookup.TimingTypeEverHaveBuff);
                matcher.componentNames = BuffComponentsLookup.componentNames;
                _matcherTimingTypeEverHaveBuff = matcher;
            }

            return _matcherTimingTypeEverHaveBuff;
        }
    }
}