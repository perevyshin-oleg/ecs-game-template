//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class NodeSystemMatcher {

    static Entitas.IMatcher<NodeSystemEntity> _matcherNextChoices;

    public static Entitas.IMatcher<NodeSystemEntity> NextChoices {
        get {
            if (_matcherNextChoices == null) {
                var matcher = (Entitas.Matcher<NodeSystemEntity>)Entitas.Matcher<NodeSystemEntity>.AllOf(NodeSystemComponentsLookup.NextChoices);
                matcher.componentNames = NodeSystemComponentsLookup.componentNames;
                _matcherNextChoices = matcher;
            }

            return _matcherNextChoices;
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
public partial class NodeSystemEntity {

    public NodeBasedSystem.Nodes.NextChoices nextChoices { get { return (NodeBasedSystem.Nodes.NextChoices)GetComponent(NodeSystemComponentsLookup.NextChoices); } }
    public System.Collections.Generic.List<Code.NodeBasedSystem.Core.Conditions.ChoiceNodeLink> NextChoices { get { return nextChoices.Value; } }
    public bool hasNextChoices { get { return HasComponent(NodeSystemComponentsLookup.NextChoices); } }

    public NodeSystemEntity AddNextChoices(System.Collections.Generic.List<Code.NodeBasedSystem.Core.Conditions.ChoiceNodeLink> newValue) {
        var index = NodeSystemComponentsLookup.NextChoices;
        var component = (NodeBasedSystem.Nodes.NextChoices)CreateComponent(index, typeof(NodeBasedSystem.Nodes.NextChoices));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public NodeSystemEntity ReplaceNextChoices(System.Collections.Generic.List<Code.NodeBasedSystem.Core.Conditions.ChoiceNodeLink> newValue) {
        var index = NodeSystemComponentsLookup.NextChoices;
        var component = (NodeBasedSystem.Nodes.NextChoices)CreateComponent(index, typeof(NodeBasedSystem.Nodes.NextChoices));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public NodeSystemEntity RemoveNextChoices() {
        RemoveComponent(NodeSystemComponentsLookup.NextChoices);
        return this;
    }
}
