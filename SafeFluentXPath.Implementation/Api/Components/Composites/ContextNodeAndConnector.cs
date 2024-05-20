using SafeFluentXPath.Api.Components;
using SafeFluentXPath.Api.Components.Composites;

namespace SafeFluentXPath.Implementation.Api.Components.Composites;

internal class ContextNodeAndConnector : IContextNodeAndConnector
{
    private IContextNode _node;

    private IConnector<ICondition<IContextNodeAndConnector>> _connector;

    private IConditionStartGroup _conditionStartGroup;

    private IEnd _end;

    internal void Init(IContextNode node, IConnector<ICondition<IContextNodeAndConnector>> connector,
        IConditionStartGroup conditionStartGroup, IEnd end)
    {
        _node = node;
        _connector = connector;
        _conditionStartGroup = conditionStartGroup;
        _end = end;
    }
    
    public IContextNodeAndCondition ChildElement(string elementName)
    {
        return _node.ChildElement(elementName);
    }

    public IContextNodeAndCondition Descendant(string descendant)
    {
        return _node.Descendant(descendant);
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

    public string Build()
    {
        return _end.Build();
    }
}
