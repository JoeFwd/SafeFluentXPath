using XpathBuilder.Api;
using XpathBuilder.Api.Composites;

namespace XpathBuilder.Builders.Composites;

public class NodeAndConnectorWithGroupedConditionBuilder : INodeAndConnectorWithGroupedCondition
{
    private INode _node;
    private IConnector<IConditionStartGroupWithNode> _connectorAllowingGroupedCondition;
    
    public void Init(INode node, IConnector<IConditionStartGroupWithNode> connector)
    {
        _node = node;
        _connectorAllowingGroupedCondition = connector;
    }
    
    public INodeWithCondition Root(string elementName)
    {
        return _node.Root(elementName);
    }

    public INodeWithCondition ChildNode(string elementName)
    {
        return _node.ChildNode(elementName);
    }

    public INodeWithCondition Descendant(string descendant)
    {
        return _node.Descendant(descendant);
    }

    public string Build()
    {
        return _node.Build();
    }

    public IConditionStartGroupWithNode And()
    {
        return _connectorAllowingGroupedCondition.And();
    }

    public IConditionStartGroupWithNode Or()
    {
        return _connectorAllowingGroupedCondition.Or();
    }
}