//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentLookupGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public static class CombatComponentsLookup {

    public const int CombatReduceDamage = 0;
    public const int CombatMeleeWeapon = 1;
    public const int CombatRangedWeapon = 2;
    public const int LocalId = 3;

    public const int TotalComponents = 4;

    public static readonly string[] componentNames = {
        "CombatReduceDamage",
        "CombatMeleeWeapon",
        "CombatRangedWeapon",
        "LocalId"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(Game.Combat.CombatReduceDamageComponent),
        typeof(Game.CombatMeleeWeapon),
        typeof(Game.CombatRangedWeaponComponent),
        typeof(Game.LocalIdComponent)
    };
}
