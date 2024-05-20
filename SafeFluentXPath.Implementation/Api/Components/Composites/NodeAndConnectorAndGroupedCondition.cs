using SafeFluentXPath.Api.Components;
using SafeFluentXPath.Api.Components.Composites;

namespace SafeFluentXPath.Implementation.Api.Components.Composites;

internal class NodeAndConnectorAndGroupedCondition : INodeAndConnectorAndGroupedCondition
{
    private INode _node;
    private IConnector<IConditionStartGroupAndNode> _connectorAllowingGroupedCondition;
    
    public void Init(INode node, IConnector<IConditionStartGroupAndNode> connector)
    {
        _node = node;
        _connectorAllowingGroupedCondition = connector;
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

    public IConditionStartGroupAndNode And()
    {
        return _connectorAllowingGroupedCondition.And();
    }

    public IConditionStartGroupAndNode Or()
    {
        return _connectorAllowingGroupedCondition.Or();
    }
}