using FluentXPath.Api.Components;
using FluentXPath.Api.Components.Composites;

namespace FluentXPath.Implementation.Api.Components.Composites;

public class NodeAndConnector : INodeAndConnector
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
