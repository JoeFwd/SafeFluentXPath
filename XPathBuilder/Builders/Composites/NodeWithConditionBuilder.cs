using XpathBuilder.Api;
using XpathBuilder.Api.Composites;

namespace XpathBuilder.Builders.Composites;

public class NodeWithConditionBuilder : INodeWithCondition
{
    private INode _node;

    private ICondition<INodeWithConnector> _conditionRedirectedToNodeAndConnector;

    private IConditionStartGroup _conditionStartGroup;

    internal void Init(INode node, ICondition<INodeWithConnector> conditionRedirectedToNodeAndConnector,
        IConditionStartGroup conditionStartGroup)
    {
        _node = node;
        _conditionRedirectedToNodeAndConnector = conditionRedirectedToNodeAndConnector;
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

    public INodeWithConnector ChildNodesAtSameLevel(params string[] elementNames)
    {
        return _conditionRedirectedToNodeAndConnector.ChildNodesAtSameLevel(elementNames);
    }

    public string Build()
    {
        return _node.Build();
    }

    public INodeWithConnector WithAttribute(string attributeName, string attributeValue)
    {
        return _conditionRedirectedToNodeAndConnector.WithAttribute(attributeName, attributeValue);
    }

    public INodeWithConnector AtPosition(int position)
    {
        return _conditionRedirectedToNodeAndConnector.AtPosition(position);
    }

    public INodeWithConnector NodeHasName(string nodeName)
    {
        return _conditionRedirectedToNodeAndConnector.NodeHasName(nodeName);
    }

    public ICondition<IConnectorWithConditionEndGroup> StartGroupCondition()
    {
        return _conditionStartGroup.StartGroupCondition();
    }
}
