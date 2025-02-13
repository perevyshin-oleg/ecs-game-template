//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherDamage;

    public static Entitas.IMatcher<GameEntity> Damage {
        get {
            if (_matcherDamage == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Damage);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDamage = matcher;
            }

            return _matcherDamage;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Code.Gameplay.Features.Battle.Damage.DamageComponent damage { get { return (Code.Gameplay.Features.Battle.Damage.DamageComponent)GetComponent(GameComponentsLookup.Damage); } }
    public int Damage { get { return damage.Value; } }
    public bool hasDamage { get { return HasComponent(GameComponentsLookup.Damage); } }

    public GameEntity AddDamage(int newValue) {
        var index = GameComponentsLookup.Damage;
        var component = (Code.Gameplay.Features.Battle.Damage.DamageComponent)CreateComponent(index, typeof(Code.Gameplay.Features.Battle.Damage.DamageComponent));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceDamage(int newValue) {
        var index = GameComponentsLookup.Damage;
        var component = (Code.Gameplay.Features.Battle.Damage.DamageComponent)CreateComponent(index, typeof(Code.Gameplay.Features.Battle.Damage.DamageComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveDamage() {
        RemoveComponent(GameComponentsLookup.Damage);
        return this;
    }
}
