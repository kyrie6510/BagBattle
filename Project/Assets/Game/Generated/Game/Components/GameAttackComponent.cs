//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Game.AttackComponent attack { get { return (Game.AttackComponent)GetComponent(GameComponentsLookup.Attack); } }
    public bool hasAttack { get { return HasComponent(GameComponentsLookup.Attack); } }

    public void AddAttack(FixMath.NET.Fix64[] newValue) {
        var index = GameComponentsLookup.Attack;
        var component = (Game.AttackComponent)CreateComponent(index, typeof(Game.AttackComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceAttack(FixMath.NET.Fix64[] newValue) {
        var index = GameComponentsLookup.Attack;
        var component = (Game.AttackComponent)CreateComponent(index, typeof(Game.AttackComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveAttack() {
        RemoveComponent(GameComponentsLookup.Attack);
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

    static Entitas.IMatcher<GameEntity> _matcherAttack;

    public static Entitas.IMatcher<GameEntity> Attack {
        get {
            if (_matcherAttack == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Attack);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAttack = matcher;
            }

            return _matcherAttack;
        }
    }
}
