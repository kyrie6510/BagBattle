//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class CombatEntity {

    public Game.Combat.CombatReduceDamageComponent combatReduceDamage { get { return (Game.Combat.CombatReduceDamageComponent)GetComponent(CombatComponentsLookup.CombatReduceDamage); } }
    public bool hasCombatReduceDamage { get { return HasComponent(CombatComponentsLookup.CombatReduceDamage); } }

    public void AddCombatReduceDamage(FixMath.NET.Fix64 newValue) {
        var index = CombatComponentsLookup.CombatReduceDamage;
        var component = (Game.Combat.CombatReduceDamageComponent)CreateComponent(index, typeof(Game.Combat.CombatReduceDamageComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceCombatReduceDamage(FixMath.NET.Fix64 newValue) {
        var index = CombatComponentsLookup.CombatReduceDamage;
        var component = (Game.Combat.CombatReduceDamageComponent)CreateComponent(index, typeof(Game.Combat.CombatReduceDamageComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveCombatReduceDamage() {
        RemoveComponent(CombatComponentsLookup.CombatReduceDamage);
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
public sealed partial class CombatMatcher {

    static Entitas.IMatcher<CombatEntity> _matcherCombatReduceDamage;

    public static Entitas.IMatcher<CombatEntity> CombatReduceDamage {
        get {
            if (_matcherCombatReduceDamage == null) {
                var matcher = (Entitas.Matcher<CombatEntity>)Entitas.Matcher<CombatEntity>.AllOf(CombatComponentsLookup.CombatReduceDamage);
                matcher.componentNames = CombatComponentsLookup.componentNames;
                _matcherCombatReduceDamage = matcher;
            }

            return _matcherCombatReduceDamage;
        }
    }
}
