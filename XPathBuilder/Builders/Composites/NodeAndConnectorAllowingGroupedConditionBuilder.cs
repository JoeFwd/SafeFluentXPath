using XpathBuilder.ReturnLogic;
using XpathBuilder.ReturnLogic.Composites;

namespace XpathBuilder.Builders.Composites;

public class NodeAndConnectorAllowingGroupedConditionBuilder : INodeAndConnectorAllowingGroupedCondition
{
    private INode _node;
    private IConnector<IConditionStartGroupAndConditionAllowingNode> _connectorAllowingGroupedCondition;
    
    public void Init(INode node, IConnector<IConditionStartGroupAndConditionAllowingNode> connector)
    {
        _node = node;
        _connectorAllowingGroupedCondition = connector;
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

    public IConditionStartGroupAndConditionAllowingNode And()
    {
        return _connectorAllowingGroupedCondition.And();
    }

    public IConditionStartGroupAndConditionAllowingNode Or()
    {
        return _connectorAllowingGroupedCondition.Or();
    }
}