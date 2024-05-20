using SafeFluentXPath.Api.Components;
using SafeFluentXPath.Api.Components.Composites;

namespace SafeFluentXPath.Implementation.Api.Components.Composites;

internal class ContextNodeAndConnectorAndGroupedCondition : IContextNodeAndConnectorAndGroupedCondition
{
    private IContextNode _contextNode;
    private IConnector<IConditionStartGroupAndContextNode> _connectorAllowingGroupedCondition;
    
    public void Init(IContextNode contextNode, IConnector<IConditionStartGroupAndContextNode> connector)
    {
        _contextNode = contextNode;
        _connectorAllowingGroupedCondition = connector;
    }

    public IContextNodeAndCondition ChildElement(string elementName)
    {
        return _contextNode.ChildElement(elementName);
    }

    public IContextNodeAndCondition Descendant(string descendant)
    {
        return _contextNode.Descendant(descendant);
    }

    public string Build()
    {
        return _contextNode.Build();
    }

    public IConditionStartGroupAndContextNode And()
    {
        return _connectorAllowingGroupedCondition.And();
    }

    public IConditionStartGroupAndContextNode Or()
    {
        return _connectorAllowingGroupedCondition.Or();
    }
}