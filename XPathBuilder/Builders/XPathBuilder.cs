using XPathBuilder.Builders.Core;
using XPathBuilder.Builders.Factories;
using XpathBuilder.Api;
using XpathBuilder.Api.Composites;

namespace XpathBuilder.Builders;

public class XPathBuilder : IXPathBuilder
{
    private readonly XPathProcessor _xPathProcessor = new ();

    private readonly INode _nodeBuilder;

    private readonly IConnector<ICondition<IConnectorAndConditionStartGroup>>
        _connectorRedirectedToChainedConditionBuilder;

    private readonly IConnector<ICondition<IConnectorAndConditionEndGroup>>
        _connectorRedirectedToConditionEndGroupBuilder;

    private readonly IConditionStartGroup _conditionStartGroupBuilder;
    private readonly IConditionEndGroup _conditionEndGroupBuilder;
    private readonly ICondition<INodeAndConnector> _conditionRedirectedToNodeBuilder;
    private readonly ICondition<IConnectorAndConditionEndGroup> _conditionRedirectedToEndGroupBuilder;

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

    public INodeAndCondition Root(string elementName)
    {
        return _nodeBuilder.Root(elementName);
    }

    public INodeAndCondition ChildNode(string elementName)
    {
        return _nodeBuilder.ChildNode(elementName);
    }

    public INodeAndCondition Descendant(string descendant)
    {
        return _nodeBuilder.Descendant(descendant);
    }

    public string Build()
    {
        return _xPathProcessor.Build();
    }

    ICondition<IConnectorAndConditionEndGroup> IConnector<ICondition<IConnectorAndConditionEndGroup>>.And()
    {
        return _connectorRedirectedToConditionEndGroupBuilder.And();
    }

    public ICondition<IConnectorAndConditionStartGroup> And()
    {
        return _connectorRedirectedToChainedConditionBuilder.And();
    }

    public ICondition<IConnectorAndConditionStartGroup> Or()
    {
        return _connectorRedirectedToChainedConditionBuilder.Or();
    }

    ICondition<IConnectorAndConditionEndGroup> IConnector<ICondition<IConnectorAndConditionEndGroup>>.Or()
    {
        return _connectorRedirectedToConditionEndGroupBuilder.Or();
    }

    public INodeAndConnector WithAttribute(string attributeName, string attributeValue)
    {
        return _conditionRedirectedToNodeBuilder.WithAttribute(attributeName, attributeValue);
    }

    IConnectorAndConditionEndGroup ICondition<IConnectorAndConditionEndGroup>.AtPosition(
        int position)
    {
        return _conditionRedirectedToEndGroupBuilder.AtPosition(position);
    }

    IConnectorAndConditionEndGroup ICondition<IConnectorAndConditionEndGroup>.NodeHasName(
        string nodeName)
    {
        return _conditionRedirectedToEndGroupBuilder.NodeHasName(nodeName);
    }

    IConnectorAndConditionEndGroup ICondition<IConnectorAndConditionEndGroup>.ChildNodesAtSameLevel(
        params string[] elementNames)
    {
        return _conditionRedirectedToEndGroupBuilder.ChildNodesAtSameLevel(elementNames);
    }

    IConnectorAndConditionEndGroup ICondition<IConnectorAndConditionEndGroup>.WithAttribute(
        string attributeName, string attributeValue)
    {
        return _conditionRedirectedToEndGroupBuilder.WithAttribute(attributeName, attributeValue);
    }

    public INodeAndConnector AtPosition(int position)
    {
        return _conditionRedirectedToNodeBuilder.AtPosition(position);
    }

    public INodeAndConnector NodeHasName(string nodeName)
    {
        return _conditionRedirectedToNodeBuilder.NodeHasName(nodeName);
    }

    INodeAndConnector ICondition<INodeAndConnector>.ChildNodesAtSameLevel(params string[] elementNames)
    {
        return _conditionRedirectedToNodeBuilder.ChildNodesAtSameLevel(elementNames);
    }

    public ICondition<IConnectorAndConditionEndGroup> StartGroupCondition()
    {
        return _conditionStartGroupBuilder.StartGroupCondition();
    }

    public INodeAndConnectorAndGroupedCondition EndConditionGroup()
    {
        return _conditionEndGroupBuilder.EndConditionGroup();
    }
}