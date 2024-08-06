//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentLookupGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public static class ActorComponentsLookup {

    public const int Hp = 0;
    public const int Id = 1;
    public const int Stamina = 2;
    public const int TimingTypeInState = 3;
    public const int TimingTypeInStore = 4;
    public const int HpListener = 5;
    public const int StaminaListener = 6;
    public const int TimingTypeInStateListener = 7;
    public const int TimingTypeInStoreListener = 8;

    public const int TotalComponents = 9;

    public static readonly string[] componentNames = {
        "Hp",
        "Id",
        "Stamina",
        "TimingTypeInState",
        "TimingTypeInStore",
        "HpListener",
        "StaminaListener",
        "TimingTypeInStateListener",
        "TimingTypeInStoreListener"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(Game.HpComponent),
        typeof(Game.IdComponent),
        typeof(Game.StaminaComponent),
        typeof(Game.TimingTypeInStateComponent),
        typeof(Game.TimingTypeInStoreComponent),
        typeof(HpListenerComponent),
        typeof(StaminaListenerComponent),
        typeof(TimingTypeInStateListenerComponent),
        typeof(TimingTypeInStoreListenerComponent)
    };
}
