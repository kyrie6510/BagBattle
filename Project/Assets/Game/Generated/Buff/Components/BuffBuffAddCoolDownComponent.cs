//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class BuffEntity {

    public Game.BuffAddCoolDown buffAddCoolDown { get { return (Game.BuffAddCoolDown)GetComponent(BuffComponentsLookup.BuffAddCoolDown); } }
    public bool hasBuffAddCoolDown { get { return HasComponent(BuffComponentsLookup.BuffAddCoolDown); } }

    public void AddBuffAddCoolDown(FixMath.NET.Fix64 newValue, int newAttackLocalId) {
        var index = BuffComponentsLookup.BuffAddCoolDown;
        var component = (Game.BuffAddCoolDown)CreateComponent(index, typeof(Game.BuffAddCoolDown));
        component.Value = newValue;
        component.AttackLocalId = newAttackLocalId;
        AddComponent(index, component);
    }

    public void ReplaceBuffAddCoolDown(FixMath.NET.Fix64 newValue, int newAttackLocalId) {
        var index = BuffComponentsLookup.BuffAddCoolDown;
        var component = (Game.BuffAddCoolDown)CreateComponent(index, typeof(Game.BuffAddCoolDown));
        component.Value = newValue;
        component.AttackLocalId = newAttackLocalId;
        ReplaceComponent(index, component);
    }

    public void RemoveBuffAddCoolDown() {
        RemoveComponent(BuffComponentsLookup.BuffAddCoolDown);
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

    static Entitas.IMatcher<BuffEntity> _matcherBuffAddCoolDown;

    public static Entitas.IMatcher<BuffEntity> BuffAddCoolDown {
        get {
            if (_matcherBuffAddCoolDown == null) {
                var matcher = (Entitas.Matcher<BuffEntity>)Entitas.Matcher<BuffEntity>.AllOf(BuffComponentsLookup.BuffAddCoolDown);
                matcher.componentNames = BuffComponentsLookup.componentNames;
                _matcherBuffAddCoolDown = matcher;
            }

            return _matcherBuffAddCoolDown;
        }
    }
}
