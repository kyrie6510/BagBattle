//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class BuffEntity {

    public Game.Buff.AttachActorIdComponent attachActorId { get { return (Game.Buff.AttachActorIdComponent)GetComponent(BuffComponentsLookup.AttachActorId); } }
    public bool hasAttachActorId { get { return HasComponent(BuffComponentsLookup.AttachActorId); } }

    public void AddAttachActorId(int newValue) {
        var index = BuffComponentsLookup.AttachActorId;
        var component = (Game.Buff.AttachActorIdComponent)CreateComponent(index, typeof(Game.Buff.AttachActorIdComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceAttachActorId(int newValue) {
        var index = BuffComponentsLookup.AttachActorId;
        var component = (Game.Buff.AttachActorIdComponent)CreateComponent(index, typeof(Game.Buff.AttachActorIdComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveAttachActorId() {
        RemoveComponent(BuffComponentsLookup.AttachActorId);
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

    static Entitas.IMatcher<BuffEntity> _matcherAttachActorId;

    public static Entitas.IMatcher<BuffEntity> AttachActorId {
        get {
            if (_matcherAttachActorId == null) {
                var matcher = (Entitas.Matcher<BuffEntity>)Entitas.Matcher<BuffEntity>.AllOf(BuffComponentsLookup.AttachActorId);
                matcher.componentNames = BuffComponentsLookup.componentNames;
                _matcherAttachActorId = matcher;
            }

            return _matcherAttachActorId;
        }
    }
}
