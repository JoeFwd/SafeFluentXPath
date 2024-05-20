using SafeFluentXPath.Api.Components;
using SafeFluentXPath.Api.Components.Composites;

namespace SafeFluentXPath.Implementation.Api.Components.Composites;

internal class ContextNodeAndConnector : IContextNodeAndConnector
{
    private IContextNode _node;

    private IConnector<ICondition<IContextNodeAndConnector>> _connector;

    private IConditionStartGroup _conditionStartGroup;

    internal void Init(IContextNode node, IConnector<ICondition<IContextNodeAndConnector>> connector,
        IConditionStartGroup conditionStartGroup)
    {
        _node = node;
        _connector = connector;
        _conditionStartGroup = conditionStartGroup;
    }
    
    public IContextNodeAndCondition ChildElement(string elementName)
    {
        return _node.ChildElement(elementName);
    }

    public IContextNodeAndCondition Descendant(string descendant)
    {
        return _node.Descendant(descendant);
    }

    public string Build()
    {
        return _node.Build();
    }

    public ICondition<IContextNodeAndConnector> And()
    {
        return _connector.And();
    }

    public ICondition<IContextNodeAndConnector> Or()
    {
        return _connector.Or();
    }

    public ICondition<IConnectorAndConditionEndGroup> StartGroupCondition()
    {
        return _conditionStartGroup.StartGroupCondition();
    }
}
