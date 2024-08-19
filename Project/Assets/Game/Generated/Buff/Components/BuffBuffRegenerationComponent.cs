//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class BuffEntity {

    public Game.Buff.BuffRegenerationComponent buffRegeneration { get { return (Game.Buff.BuffRegenerationComponent)GetComponent(BuffComponentsLookup.BuffRegeneration); } }
    public bool hasBuffRegeneration { get { return HasComponent(BuffComponentsLookup.BuffRegeneration); } }

    public void AddBuffRegeneration(int newNum, FixMath.NET.Fix64 newLastSpan, FixMath.NET.Fix64 newPerActiveTime) {
        var index = BuffComponentsLookup.BuffRegeneration;
        var component = (Game.Buff.BuffRegenerationComponent)CreateComponent(index, typeof(Game.Buff.BuffRegenerationComponent));
        component.Num = newNum;
        component.LastSpan = newLastSpan;
        component.PerActiveTime = newPerActiveTime;
        AddComponent(index, component);
    }

    public void ReplaceBuffRegeneration(int newNum, FixMath.NET.Fix64 newLastSpan, FixMath.NET.Fix64 newPerActiveTime) {
        var index = BuffComponentsLookup.BuffRegeneration;
        var component = (Game.Buff.BuffRegenerationComponent)CreateComponent(index, typeof(Game.Buff.BuffRegenerationComponent));
        component.Num = newNum;
        component.LastSpan = newLastSpan;
        component.PerActiveTime = newPerActiveTime;
        ReplaceComponent(index, component);
    }

    public void RemoveBuffRegeneration() {
        RemoveComponent(BuffComponentsLookup.BuffRegeneration);
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

    static Entitas.IMatcher<BuffEntity> _matcherBuffRegeneration;

    public static Entitas.IMatcher<BuffEntity> BuffRegeneration {
        get {
            if (_matcherBuffRegeneration == null) {
                var matcher = (Entitas.Matcher<BuffEntity>)Entitas.Matcher<BuffEntity>.AllOf(BuffComponentsLookup.BuffRegeneration);
                matcher.componentNames = BuffComponentsLookup.componentNames;
                _matcherBuffRegeneration = matcher;
            }

            return _matcherBuffRegeneration;
        }
    }
}
