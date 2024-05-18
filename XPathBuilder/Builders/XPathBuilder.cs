using XPathBuilder.Builders.Core;
using XPathBuilder.Builders.Factories;
using XpathBuilder.Api;
using XpathBuilder.Api.Composites;

namespace XpathBuilder.Builders;

public class XPathBuilder : IXPathBuilder
{
    private readonly XPathProcessor _xPathProcessor = new ();

    private readonly INode _nodeBuilder;

    private readonly IConnector<ICondition<IConnectorWithConditionStartGroup>>
        _connectorRedirectedToChainedConditionBuilder;

    private readonly IConnector<ICondition<IConnectorWithConditionEndGroup>>
        _connectorRedirectedToConditionEndGroupBuilder;

    private readonly IConditionStartGroup _conditionStartGroupBuilder;
    private readonly IConditionEndGroup _conditionEndGroupBuilder;
    private readonly ICondition<INodeWithConnector> _conditionRedirectedToNodeBuilder;
    private readonly ICondition<IConnectorWithConditionEndGroup> _conditionRedirectedToEndGroupBuilder;

    public XPathBuilder()
    {
        var builderFactory = new XPathBuilderFactory(_xPathProcessor);
        _nodeBuilder = builderFactory.CreateNodeBuilder();
        _connectorRedirectedToChainedConditionBuilder = builderFactory.CreateConnectorAndConditionStartGroupBuilder();
        _connectorRedirectedToConditionEndGroupBuilder = builderFactory.CreateConnectorAndConditionEndGroupBuilder();
        _conditionStartGroupBuilder = builderFactory.CreateConditionStartGroupBuilder();
        _conditionEndGroupBuilder = builderFactory.CreateConditionEndGroupBuilder();
        _conditionRedirectedToNodeBuilder = builderFactory.CreateConditionRedirectedToNodeBuilder();
        _conditionRedirectedToEndGroupBuilder = builderFactory.CreateConditionRedirectedToEndGroupBuilder();
    }

    public INodeWithCondition Root(string elementName)
    {
        return _nodeBuilder.Root(elementName);
    }

    public INodeWithCondition ChildNode(string elementName)
    {
        return _nodeBuilder.ChildNode(elementName);
    }

    public INodeWithCondition Descendant(string descendant)
    {
        return _nodeBuilder.Descendant(descendant);
    }

    public string Build()
    {
        return _xPathProcessor.Build();
    }

    ICondition<IConnectorWithConditionEndGroup> IConnector<ICondition<IConnectorWithConditionEndGroup>>.And()
    {
        return _connectorRedirectedToConditionEndGroupBuilder.And();
    }

    public ICondition<IConnectorWithConditionStartGroup> And()
    {
        return _connectorRedirectedToChainedConditionBuilder.And();
    }

    public ICondition<IConnectorWithConditionStartGroup> Or()
    {
        return _connectorRedirectedToChainedConditionBuilder.Or();
    }

    ICondition<IConnectorWithConditionEndGroup> IConnector<ICondition<IConnectorWithConditionEndGroup>>.Or()
    {
        return _connectorRedirectedToConditionEndGroupBuilder.Or();
    }

    public INodeWithConnector WithAttribute(string attributeName, string attributeValue)
    {
        return _conditionRedirectedToNodeBuilder.WithAttribute(attributeName, attributeValue);
    }

    IConnectorWithConditionEndGroup ICondition<IConnectorWithConditionEndGroup>.AtPosition(
        int position)
    {
        return _conditionRedirectedToEndGroupBuilder.AtPosition(position);
    }

    IConnectorWithConditionEndGroup ICondition<IConnectorWithConditionEndGroup>.NodeHasName(
        string nodeName)
    {
        return _conditionRedirectedToEndGroupBuilder.NodeHasName(nodeName);
    }

    IConnectorWithConditionEndGroup ICondition<IConnectorWithConditionEndGroup>.ChildNodesAtSameLevel(
        params string[] elementNames)
    {
        return _conditionRedirectedToEndGroupBuilder.ChildNodesAtSameLevel(elementNames);
    }

    IConnectorWithConditionEndGroup ICondition<IConnectorWithConditionEndGroup>.WithAttribute(
        string attributeName, string attributeValue)
    {
        return _conditionRedirectedToEndGroupBuilder.WithAttribute(attributeName, attributeValue);
    }

    public INodeWithConnector AtPosition(int position)
    {
        return _conditionRedirectedToNodeBuilder.AtPosition(position);
    }

    public INodeWithConnector NodeHasName(string nodeName)
    {
        return _conditionRedirectedToNodeBuilder.NodeHasName(nodeName);
    }

    INodeWithConnector ICondition<INodeWithConnector>.ChildNodesAtSameLevel(params string[] elementNames)
    {
        return _conditionRedirectedToNodeBuilder.ChildNodesAtSameLevel(elementNames);
    }

    public ICondition<IConnectorWithConditionEndGroup> StartGroupCondition()
    {
        return _conditionStartGroupBuilder.StartGroupCondition();
    }

    public INodeAndConnectorWithGroupedCondition EndConditionGroup()
    {
        return _conditionEndGroupBuilder.EndConditionGroup();
    }
}