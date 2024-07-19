//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ActorEntity {

    public Game.IdComponent id { get { return (Game.IdComponent)GetComponent(ActorComponentsLookup.Id); } }
    public bool hasId { get { return HasComponent(ActorComponentsLookup.Id); } }

    public void AddId(int newValue) {
        var index = ActorComponentsLookup.Id;
        var component = (Game.IdComponent)CreateComponent(index, typeof(Game.IdComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceId(int newValue) {
        var index = ActorComponentsLookup.Id;
        var component = (Game.IdComponent)CreateComponent(index, typeof(Game.IdComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveId() {
        RemoveComponent(ActorComponentsLookup.Id);
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
public sealed partial class ActorMatcher {

    static Entitas.IMatcher<ActorEntity> _matcherId;

    public static Entitas.IMatcher<ActorEntity> Id {
        get {
            if (_matcherId == null) {
                var matcher = (Entitas.Matcher<ActorEntity>)Entitas.Matcher<ActorEntity>.AllOf(ActorComponentsLookup.Id);
                matcher.componentNames = ActorComponentsLookup.componentNames;
                _matcherId = matcher;
            }

            return _matcherId;
        }
    }
}