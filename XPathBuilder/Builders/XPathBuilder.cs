using XpathBuilder.Builders.Composites;
using XpathBuilder.ReturnLogic;
using XpathBuilder.ReturnLogic.Composites;

namespace XpathBuilder.Builders;

public class XPathBuilder : INode,
    IConnector<IConnectorAndConditionEndGroup>, IConditionStartGroup, IConditionEndGroup,
    ICondition<INodeAndConnector>, ICondition<IConnectorAndConditionEndGroup>, IConnector<IConnectorAndConditionStartGroup>
{
    private readonly XPathProcessor _xPathProcessor = new();

    private readonly NodeBuilder _nodeBuilder;
    private readonly ConnectorBuilder<IConnectorAndConditionStartGroup> _connectorRedirectedToChainedConditionBuilder;
    private readonly ConnectorBuilder<IConnectorAndConditionEndGroup>
        _connectorRedirectedToConditionEndGroupBuilder;

    private readonly ConditionGroupBuilder _conditionGroupBuilder;
    private readonly ConditionBuilder<INodeAndConnector> _conditionRedirectedToNodeBuilder;
    private readonly ConditionBuilder<IConnectorAndConditionStartGroup> _conditionRedirectedToStartGroupBuilder;
    private readonly ConditionBuilder<IConnectorAndConditionEndGroup> _conditionRedirectedToEndGroupBuilder;

    public XPathBuilder()
    {
        // Node builder
        _nodeBuilder = new NodeBuilder(_xPathProcessor);
        // Connector builders
        _connectorRedirectedToChainedConditionBuilder = new ConnectorBuilder<IConnectorAndConditionStartGroup>(_xPathProcessor);
        _connectorRedirectedToConditionEndGroupBuilder =
            new ConnectorBuilder<IConnectorAndConditionEndGroup>(_xPathProcessor);
        // Condition group builder
        _conditionGroupBuilder = new ConditionGroupBuilder(_xPathProcessor);

        // Composite builders
        var connectorAndConditionStartGroupBuilder = new ConnectorAndConditionStartGroupBuilder();
        var connectorAndConditionEndGroupBuilder = new ConnectorAndConditionEndGroupBuilder();
        var nodeAndConditionBuilder = new NodeAndConditionBuilder();
        var nodeAndConnectorBuilder = new NodeAndConnectorBuilder();

        // Condition builders
        _conditionRedirectedToNodeBuilder =
            new ConditionBuilder<INodeAndConnector>(_xPathProcessor, nodeAndConnectorBuilder);
        _conditionRedirectedToStartGroupBuilder =
            new ConditionBuilder<IConnectorAndConditionStartGroup>(_xPathProcessor, connectorAndConditionStartGroupBuilder);
        _conditionRedirectedToEndGroupBuilder =
            new ConditionBuilder<IConnectorAndConditionEndGroup>(_xPathProcessor,
                connectorAndConditionEndGroupBuilder);

        // We have to set the dependencies manually because of circular dependencies
        // Set dependencies for Node builder
        _nodeBuilder.Init(nodeAndConditionBuilder);

        // Set dependencies for Connector builders
        _connectorRedirectedToConditionEndGroupBuilder.Init(_conditionRedirectedToEndGroupBuilder);

        // Set dependencies for Condition group builder
        _conditionGroupBuilder.Init(_conditionRedirectedToEndGroupBuilder, nodeAndConnectorBuilder);

        // Set dependencies for Condition builders
        _conditionRedirectedToNodeBuilder.Init(_nodeBuilder);
        _connectorRedirectedToChainedConditionBuilder.Init(_conditionRedirectedToStartGroupBuilder);
        _conditionRedirectedToEndGroupBuilder.Init(_nodeBuilder);

        // Set dependencies for Composite builders
        connectorAndConditionEndGroupBuilder.Init(_connectorRedirectedToConditionEndGroupBuilder,
            _conditionGroupBuilder);
        nodeAndConditionBuilder.Init(_nodeBuilder, _conditionRedirectedToNodeBuilder, _conditionGroupBuilder);
        nodeAndConnectorBuilder.Init(_nodeBuilder, , _conditionGroupBuilder);
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

    ICondition<IConnectorAndConditionEndGroup> IConnector<IConnectorAndConditionEndGroup>.And()
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

    ICondition<IConnectorAndConditionEndGroup> IConnector<IConnectorAndConditionEndGroup>.Or()
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
        return _conditionGroupBuilder.StartGroupCondition();
    }

    public INodeAndConnector EndConditionGroup()
    {
        return _conditionGroupBuilder.EndConditionGroup();
    }
}