using SafeFluentXPath.Api.Components;
using SafeFluentXPath.Api.Components.Composites;

namespace SafeFluentXPath.Implementation.Api.Components.Composites;

internal class NodeAndConnector : INodeAndConnector
{
    private INode _node;

    private IConnector<ICondition<INodeAndConnector>> _connector;

    private IConditionStartGroup _conditionStartGroup;

    internal void Init(INode node, IConnector<ICondition<INodeAndConnector>> connector,
        IConditionStartGroup conditionStartGroup)
    {
        _node = node;
        _connector = connector;
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

    public string Build()
    {
        return _node.Build();
    }

    public ICondition<INodeAndConnector> And()
    {
        return _connector.And();
    }

    public ICondition<INodeAndConnector> Or()
    {
        return _connector.Or();
    }

    public ICondition<IConnectorAndConditionEndGroup> StartGroupCondition()
    {
        return _conditionStartGroup.StartGroupCondition();
    }
}
