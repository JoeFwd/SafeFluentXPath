using SafeFluentXPath.Api.Components;
using SafeFluentXPath.Api.Components.Composites;

namespace SafeFluentXPath.Implementation.Api.Components.Composites;

internal class NodeAndCondition : INodeAndCondition
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
    
    public INodeAndCondition Element(string elementName)
    {
        return _node.Element(elementName);
    }

    public INodeAndCondition ChildElement(string elementName)
    {
        return _node.ChildElement(elementName);
    }

    public INodeAndCondition Descendant(string descendant)
    {
        return _node.Descendant(descendant);
    }

    public INodeAndConnector ChildElementsAtSameLevel(params string[] elementNames)
    {
        return _conditionRedirectedToNodeAndConnector.ChildElementsAtSameLevel(elementNames);
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

    public INodeAndConnector HasName(string nodeName)
    {
        return _conditionRedirectedToNodeAndConnector.HasName(nodeName);
    }

    public ICondition<IConnectorAndConditionEndGroup> StartGroupCondition()
    {
        return _conditionStartGroup.StartGroupCondition();
    }
}
