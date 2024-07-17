//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class CombatEntity {

    public Game.LocalIdComponent localId { get { return (Game.LocalIdComponent)GetComponent(CombatComponentsLookup.LocalId); } }
    public bool hasLocalId { get { return HasComponent(CombatComponentsLookup.LocalId); } }

    public void AddLocalId(uint newValue) {
        var index = CombatComponentsLookup.LocalId;
        var component = (Game.LocalIdComponent)CreateComponent(index, typeof(Game.LocalIdComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceLocalId(uint newValue) {
        var index = CombatComponentsLookup.LocalId;
        var component = (Game.LocalIdComponent)CreateComponent(index, typeof(Game.LocalIdComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveLocalId() {
        RemoveComponent(CombatComponentsLookup.LocalId);
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
public partial class CombatEntity : ILocalIdEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class CombatMatcher {

    static Entitas.IMatcher<CombatEntity> _matcherLocalId;

    public static Entitas.IMatcher<CombatEntity> LocalId {
        get {
            if (_matcherLocalId == null) {
                var matcher = (Entitas.Matcher<CombatEntity>)Entitas.Matcher<CombatEntity>.AllOf(CombatComponentsLookup.LocalId);
                matcher.componentNames = CombatComponentsLookup.componentNames;
                _matcherLocalId = matcher;
            }

            return _matcherLocalId;
        }
    }
}
