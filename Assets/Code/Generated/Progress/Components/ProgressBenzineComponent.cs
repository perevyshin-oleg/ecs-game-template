//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class ProgressMatcher {

    static Entitas.IMatcher<ProgressEntity> _matcherBenzine;

    public static Entitas.IMatcher<ProgressEntity> Benzine {
        get {
            if (_matcherBenzine == null) {
                var matcher = (Entitas.Matcher<ProgressEntity>)Entitas.Matcher<ProgressEntity>.AllOf(ProgressComponentsLookup.Benzine);
                matcher.componentNames = ProgressComponentsLookup.componentNames;
                _matcherBenzine = matcher;
            }

            return _matcherBenzine;
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
public partial class ProgressEntity {

    public Code.Progress.PlayerStorage.BenzineComponent benzine { get { return (Code.Progress.PlayerStorage.BenzineComponent)GetComponent(ProgressComponentsLookup.Benzine); } }
    public int Benzine { get { return benzine.Value; } }
    public bool hasBenzine { get { return HasComponent(ProgressComponentsLookup.Benzine); } }

    public ProgressEntity AddBenzine(int newValue) {
        var index = ProgressComponentsLookup.Benzine;
        var component = (Code.Progress.PlayerStorage.BenzineComponent)CreateComponent(index, typeof(Code.Progress.PlayerStorage.BenzineComponent));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public ProgressEntity ReplaceBenzine(int newValue) {
        var index = ProgressComponentsLookup.Benzine;
        var component = (Code.Progress.PlayerStorage.BenzineComponent)CreateComponent(index, typeof(Code.Progress.PlayerStorage.BenzineComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public ProgressEntity RemoveBenzine() {
        RemoveComponent(ProgressComponentsLookup.Benzine);
        return this;
    }
}
