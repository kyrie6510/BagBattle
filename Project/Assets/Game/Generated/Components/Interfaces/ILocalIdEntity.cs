//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface ILocalIdEntity {

    Game.LocalIdComponent localId { get; }
    bool hasLocalId { get; }

    void AddLocalId(int newValue);
    void ReplaceLocalId(int newValue);
    void RemoveLocalId();
}
