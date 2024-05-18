using FluentXPath.Api.Components;
using FluentXPath.Api.Components.Composites;

namespace FluentXPath.Implementation.Api.Components.Composites;

public class NodeAndCondition : INodeAndCondition
{
    private INode _node;

    private ICondition<INodeAndConnector> _conditionRedirectedToNodeAndConnector;

    private IConditionStartGroup _conditionStartGroup;

    internal void Init(INode node, ICondition<INodeAndConnector> conditionRedirectedToNodeAndConnector,
        IConditionStartGroup conditionStartGroup)
    {
        _node = node;
        _conditionRedirectedToNodeAndConnector = conditionRedirectedToNodeAndConnector;
        _conditionStartGroup = conditionStartGroup;
    }
    
    public INodeAndCondition Root(string elementName)
    {
        return _node.Root(elementName);
    }

    public INodeAndCondition ChildNode(string elementName)
    {
        return _node.ChildNode(elementName);
    }

    public INodeAndCondition Descendant(string descendant)
    {
        return _node.Descendant(descendant);
    }

    public INodeAndConnector ChildNodesAtSameLevel(params string[] elementNames)
    {
        return _conditionRedirectedToNodeAndConnector.ChildNodesAtSameLevel(elementNames);
    }

    public string Build()
    {
        return _node.Build();
    }

    public INodeAndConnector WithAttribute(string attributeName, string attributeValue)
    {
        return _conditionRedirectedToNodeAndConnector.WithAttribute(attributeName, attributeValue);
    }

    public INodeAndConnector AtPosition(int position)
    {
        return _conditionRedirectedToNodeAndConnector.AtPosition(position);
    }

    public INodeAndConnector NodeHasName(string nodeName)
    {
        return _conditionRedirectedToNodeAndConnector.NodeHasName(nodeName);
    }

    public ICondition<IConnectorAndConditionEndGroup> StartGroupCondition()
    {
        return _conditionStartGroup.StartGroupCondition();
    }
}
