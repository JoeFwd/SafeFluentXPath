using XpathBuilder.Api;
using XpathBuilder.Api.Composites;

namespace XpathBuilder.Builders.Composites;

public class NodeWithConnectorBuilder : INodeWithConnector
{
    private INode _node;

    private IConnector<ICondition<INodeWithConnector>> _connector;

    private IConditionStartGroup _conditionStartGroup;

    internal void Init(INode node, IConnector<ICondition<INodeWithConnector>> connector,
        IConditionStartGroup conditionStartGroup)
    {
        _node = node;
        _connector = connector;
        _conditionStartGroup = conditionStartGroup;
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

    public ICondition<INodeWithConnector> And()
    {
        return _connector.And();
    }

    public ICondition<INodeWithConnector> Or()
    {
        return _connector.Or();
    }

    public ICondition<IConnectorWithConditionEndGroup> StartGroupCondition()
    {
        return _conditionStartGroup.StartGroupCondition();
    }
}
