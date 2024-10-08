//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Game.StaminaCostComponent staminaCost { get { return (Game.StaminaCostComponent)GetComponent(GameComponentsLookup.StaminaCost); } }
    public bool hasStaminaCost { get { return HasComponent(GameComponentsLookup.StaminaCost); } }

    public void AddStaminaCost(FixMath.NET.Fix64 newValue) {
        var index = GameComponentsLookup.StaminaCost;
        var component = (Game.StaminaCostComponent)CreateComponent(index, typeof(Game.StaminaCostComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceStaminaCost(FixMath.NET.Fix64 newValue) {
        var index = GameComponentsLookup.StaminaCost;
        var component = (Game.StaminaCostComponent)CreateComponent(index, typeof(Game.StaminaCostComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveStaminaCost() {
        RemoveComponent(GameComponentsLookup.StaminaCost);
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

    static Entitas.IMatcher<GameEntity> _matcherStaminaCost;

    public static Entitas.IMatcher<GameEntity> StaminaCost {
        get {
            if (_matcherStaminaCost == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.StaminaCost);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherStaminaCost = matcher;
            }

            return _matcherStaminaCost;
        }
    }
}
