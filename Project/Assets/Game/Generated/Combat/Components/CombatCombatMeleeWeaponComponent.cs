//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class CombatEntity {

    public Game.CombatMeleeWeapon combatMeleeWeapon { get { return (Game.CombatMeleeWeapon)GetComponent(CombatComponentsLookup.CombatMeleeWeapon); } }
    public bool hasCombatMeleeWeapon { get { return HasComponent(CombatComponentsLookup.CombatMeleeWeapon); } }

    public void AddCombatMeleeWeapon(int newAttackerLocalId, int newAttackerActorId, int newStep) {
        var index = CombatComponentsLookup.CombatMeleeWeapon;
        var component = (Game.CombatMeleeWeapon)CreateComponent(index, typeof(Game.CombatMeleeWeapon));
        component.AttackerLocalId = newAttackerLocalId;
        component.AttackerActorId = newAttackerActorId;
        component.Step = newStep;
        AddComponent(index, component);
    }

    public void ReplaceCombatMeleeWeapon(int newAttackerLocalId, int newAttackerActorId, int newStep) {
        var index = CombatComponentsLookup.CombatMeleeWeapon;
        var component = (Game.CombatMeleeWeapon)CreateComponent(index, typeof(Game.CombatMeleeWeapon));
        component.AttackerLocalId = newAttackerLocalId;
        component.AttackerActorId = newAttackerActorId;
        component.Step = newStep;
        ReplaceComponent(index, component);
    }

    public void RemoveCombatMeleeWeapon() {
        RemoveComponent(CombatComponentsLookup.CombatMeleeWeapon);
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

    static Entitas.IMatcher<CombatEntity> _matcherCombatMeleeWeapon;

    public static Entitas.IMatcher<CombatEntity> CombatMeleeWeapon {
        get {
            if (_matcherCombatMeleeWeapon == null) {
                var matcher = (Entitas.Matcher<CombatEntity>)Entitas.Matcher<CombatEntity>.AllOf(CombatComponentsLookup.CombatMeleeWeapon);
                matcher.componentNames = CombatComponentsLookup.componentNames;
                _matcherCombatMeleeWeapon = matcher;
            }

            return _matcherCombatMeleeWeapon;
        }
    }
}