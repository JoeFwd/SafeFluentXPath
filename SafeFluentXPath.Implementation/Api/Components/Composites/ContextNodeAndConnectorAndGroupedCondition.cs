using SafeFluentXPath.Abstraction.Api.Components;
using SafeFluentXPath.Abstraction.Api.Components.Composites;

namespace SafeFluentXPath.Implementation.Api.Components.Composites;

internal class ContextNodeAndConnectorAndGroupedCondition : IContextNodeAndConnectorAndGroupedCondition
{
    private IContextNode _contextNode;
    private IConnector<IConditionStartGroupAndContextNode> _connectorAllowingGroupedCondition;
    private IEnd _end;
    
    public void Init(IContextNode contextNode, IConnector<IConditionStartGroupAndContextNode> connector, IEnd end)
    {
        _contextNode = contextNode;
        _connectorAllowingGroupedCondition = connector;
        _end = end;
    }

    public IContextNodeAndCondition ChildElement(string elementName)
    {
        return _contextNode.ChildElement(elementName);
    }

    public IContextNodeAndCondition Descendant(string descendant)
    {
        return _contextNode.Descendant(descendant);
    }

    public IConditionStartGroupAndContextNode And()
    {
        return _connectorAllowingGroupedCondition.And();
    }

    public IConditionStartGroupAndContextNode Or()
    {
        return _connectorAllowingGroupedCondition.Or();
    }

    public string Build()
    {
        return _end.Build();
    }
}
