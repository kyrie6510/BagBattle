//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class BuffEntity {

    public Game.TimingTypeTriggerNumComponent timingTypeTriggerNum { get { return (Game.TimingTypeTriggerNumComponent)GetComponent(BuffComponentsLookup.TimingTypeTriggerNum); } }
    public bool hasTimingTypeTriggerNum { get { return HasComponent(BuffComponentsLookup.TimingTypeTriggerNum); } }

    public void AddTimingTypeTriggerNum(int newValue) {
        var index = BuffComponentsLookup.TimingTypeTriggerNum;
        var component = (Game.TimingTypeTriggerNumComponent)CreateComponent(index, typeof(Game.TimingTypeTriggerNumComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceTimingTypeTriggerNum(int newValue) {
        var index = BuffComponentsLookup.TimingTypeTriggerNum;
        var component = (Game.TimingTypeTriggerNumComponent)CreateComponent(index, typeof(Game.TimingTypeTriggerNumComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveTimingTypeTriggerNum() {
        RemoveComponent(BuffComponentsLookup.TimingTypeTriggerNum);
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
public partial class BuffEntity : ITimingTypeTriggerNumEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class BuffMatcher {

    static Entitas.IMatcher<BuffEntity> _matcherTimingTypeTriggerNum;

    public static Entitas.IMatcher<BuffEntity> TimingTypeTriggerNum {
        get {
            if (_matcherTimingTypeTriggerNum == null) {
                var matcher = (Entitas.Matcher<BuffEntity>)Entitas.Matcher<BuffEntity>.AllOf(BuffComponentsLookup.TimingTypeTriggerNum);
                matcher.componentNames = BuffComponentsLookup.componentNames;
                _matcherTimingTypeTriggerNum = matcher;
            }

            return _matcherTimingTypeTriggerNum;
        }
    }
}
