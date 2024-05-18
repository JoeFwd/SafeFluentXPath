using XPathBuilder.Builders.Components;
using XpathBuilder.Builders.Composites;
using XPathBuilder.Builders.Core;
using XpathBuilder.Api;
using XpathBuilder.Api.Composites;

namespace XPathBuilder.Builders.Factories;

public class XPathBuilderFactory
{
    private readonly NodeBuilder _nodeBuilder;
    private readonly ConditionGroupBuilder _conditionGroupBuilder;

    private readonly NodeAndConditionBuilder _nodeAndConditionBuilder;
    private readonly NodeAndConnectorBuilder _nodeAndConnectorBuilder;
    private readonly ConnectorAndConditionStartGroupBuilder _connectorAndConditionStartGroupBuilder;
    private readonly ConnectorAndConditionEndGroupBuilder _connectorAndConditionEndGroupBuilder;
    private readonly NodeAndConnectorAllowingGroupedConditionBuilder _nodeAndConnectorAllowingGroupedConditionBuilder;
    private readonly ConditionStartGroupAndConditionAllowingNodeBuilder _conditionStartGroupAndConditionAllowingNodeBuilder;
    private readonly ConditionStartGroupAndConditionBuilder _conditionStartGroupAndConditionBuilder;

    private readonly ConditionBuilder<IConnectorAndConditionStartGroup> _conditionRedirectedToStartGroupBuilder;
    private readonly ConditionBuilder<IConnectorAndConditionEndGroup> _conditionRedirectedToEndGroupBuilder;
    private readonly ConditionBuilder<INodeAndConnector> _conditionRedirectedToNodeBuilder;
    private readonly ConditionBuilder<IConnector<IConditionStartGroupAndConditionAllowingNode>> _conditionRedirectedToConnectorAllowingGroupedConditionAndNode;
    private readonly ConditionBuilder<IConnector<IConditionStartGroupAndCondition>> _conditionRedirectedToConnectorAllowingGroupedCondition;
    private readonly ConditionBuilder<INodeAndConnectorAllowingGroupedCondition> _conditionRedirectedToNodeAndConnectorAllowingGroupedCondition;
    
    private readonly ConnectorBuilder<ICondition<IConnectorAndConditionStartGroup>> _connectorRedirectedToConditionStartGroupBuilder;
    private readonly ConnectorBuilder<ICondition<IConnectorAndConditionEndGroup>> _connectorRedirectedToConditionEndGroupBuilder;
    private readonly ConnectorBuilder<ICondition<INodeAndConnector>> _createTransitiveConnectorBuilder;
    private readonly ConnectorBuilder<IConditionStartGroupAndConditionAllowingNode> _connectorRedirectedToConditionStartGroupAllowingNode;
    private readonly ConnectorBuilder<IConditionStartGroupAndCondition> _connectorRedirectedToConditionStartGroupAndCondition;
    
    public XPathBuilderFactory(XPathProcessor xPathProcessor)
    {
        _nodeBuilder = new NodeBuilder(xPathProcessor);
        _conditionGroupBuilder = new ConditionGroupBuilder(xPathProcessor);

        // CompositeBuilders
        _nodeAndConditionBuilder = new NodeAndConditionBuilder();
        _nodeAndConnectorBuilder = new NodeAndConnectorBuilder();
        _connectorAndConditionStartGroupBuilder = new ConnectorAndConditionStartGroupBuilder();
        _connectorAndConditionEndGroupBuilder = new ConnectorAndConditionEndGroupBuilder();
        _conditionStartGroupAndConditionBuilder = new ConditionStartGroupAndConditionBuilder();
        _conditionStartGroupAndConditionAllowingNodeBuilder = new ConditionStartGroupAndConditionAllowingNodeBuilder();
        _nodeAndConnectorAllowingGroupedConditionBuilder = new NodeAndConnectorAllowingGroupedConditionBuilder();

        // ConditionBuilders
        _conditionRedirectedToStartGroupBuilder = new ConditionBuilder<IConnectorAndConditionStartGroup>(xPathProcessor);
        _conditionRedirectedToEndGroupBuilder = new ConditionBuilder<IConnectorAndConditionEndGroup>(xPathProcessor);
        _conditionRedirectedToNodeBuilder = new ConditionBuilder<INodeAndConnector>(xPathProcessor);
        _conditionRedirectedToConnectorAllowingGroupedConditionAndNode =
            new ConditionBuilder<IConnector<IConditionStartGroupAndConditionAllowingNode>>(xPathProcessor);
        _conditionRedirectedToConnectorAllowingGroupedCondition =
            new ConditionBuilder<IConnector<IConditionStartGroupAndCondition>>(xPathProcessor);
        _conditionRedirectedToNodeAndConnectorAllowingGroupedCondition =
            new ConditionBuilder<INodeAndConnectorAllowingGroupedCondition>(xPathProcessor);

        // ConnectorBuilders
        _connectorRedirectedToConditionStartGroupBuilder = new ConnectorBuilder<ICondition<IConnectorAndConditionStartGroup>>(xPathProcessor);
        _connectorRedirectedToConditionEndGroupBuilder = new ConnectorBuilder<ICondition<IConnectorAndConditionEndGroup>>(xPathProcessor);
        _createTransitiveConnectorBuilder = new ConnectorBuilder<ICondition<INodeAndConnector>>(xPathProcessor);
        _connectorRedirectedToConditionStartGroupAllowingNode = new ConnectorBuilder<IConditionStartGroupAndConditionAllowingNode>(xPathProcessor);
        _connectorRedirectedToConditionStartGroupAndCondition = new ConnectorBuilder<IConditionStartGroupAndCondition>(xPathProcessor);

        _nodeBuilder.Init(_nodeAndConditionBuilder);
        _conditionGroupBuilder.Init(_conditionRedirectedToEndGroupBuilder, _nodeAndConnectorAllowingGroupedConditionBuilder);
        _nodeAndConditionBuilder.Init(_nodeBuilder, _conditionRedirectedToNodeBuilder, _conditionGroupBuilder);
        _nodeAndConnectorBuilder.Init(_nodeBuilder, _createTransitiveConnectorBuilder, _conditionGroupBuilder);
        _connectorAndConditionStartGroupBuilder.Init(_connectorRedirectedToConditionStartGroupBuilder, _conditionGroupBuilder);
        _connectorAndConditionEndGroupBuilder.Init(_connectorRedirectedToConditionEndGroupBuilder, _conditionGroupBuilder);
        _conditionStartGroupAndConditionBuilder.Init(_conditionRedirectedToConnectorAllowingGroupedCondition, _conditionGroupBuilder);
        _conditionStartGroupAndConditionAllowingNodeBuilder.Init(_conditionRedirectedToNodeAndConnectorAllowingGroupedCondition, _conditionGroupBuilder);
        _nodeAndConnectorAllowingGroupedConditionBuilder.Init(_nodeBuilder, _connectorRedirectedToConditionStartGroupAllowingNode);
        
        _conditionRedirectedToStartGroupBuilder.Init(_nodeBuilder, _connectorAndConditionStartGroupBuilder);
        _conditionRedirectedToEndGroupBuilder.Init(_nodeBuilder, _connectorAndConditionEndGroupBuilder);
        _conditionRedirectedToNodeBuilder.Init(_nodeBuilder, _nodeAndConnectorBuilder);
        _conditionRedirectedToConnectorAllowingGroupedConditionAndNode.Init(_nodeBuilder, _connectorRedirectedToConditionStartGroupAllowingNode);
        _conditionRedirectedToConnectorAllowingGroupedCondition.Init(_nodeBuilder, _connectorRedirectedToConditionStartGroupAndCondition);
        _conditionRedirectedToNodeAndConnectorAllowingGroupedCondition.Init(_nodeBuilder,
            _nodeAndConnectorAllowingGroupedConditionBuilder);
        
        _connectorRedirectedToConditionStartGroupBuilder.Init(_conditionRedirectedToStartGroupBuilder);
        _connectorRedirectedToConditionEndGroupBuilder.Init(_conditionRedirectedToEndGroupBuilder);
        _createTransitiveConnectorBuilder.Init(_nodeAndConditionBuilder);
        _connectorRedirectedToConditionStartGroupAllowingNode.Init(_conditionStartGroupAndConditionAllowingNodeBuilder);
    }

    public INode CreateNodeBuilder()
    {
        return _nodeBuilder;
    }

    public INodeAndCondition CreateNodeAndConditionBuilder()
    {
        return _nodeAndConditionBuilder;
    }

    public IConditionEndGroup CreateConditionEndGroupBuilder()
    {
        return _conditionGroupBuilder;
    }

    public IConditionStartGroup CreateConditionStartGroupBuilder()
    {
        return _conditionGroupBuilder;
    }

    public IConnectorAndConditionStartGroup CreateConnectorAndConditionStartGroupBuilder()
    {
        return _connectorAndConditionStartGroupBuilder;
    }

    public IConnectorAndConditionEndGroup CreateConnectorAndConditionEndGroupBuilder()
    {
        return _connectorAndConditionEndGroupBuilder;
    }

    public ICondition<IConnectorAndConditionStartGroup> CreateConditionRedirectedToStartGroupBuilder()
    {
        return _conditionRedirectedToStartGroupBuilder;
    }

    public ICondition<IConnectorAndConditionEndGroup> CreateConditionRedirectedToEndGroupBuilder()
    {
        return _conditionRedirectedToEndGroupBuilder;
    }

    public ICondition<INodeAndConnector> CreateConditionRedirectedToNodeBuilder()
    {
        return _conditionRedirectedToNodeBuilder;
    }

    public IConnector<ICondition<IConnectorAndConditionStartGroup>> CreateConnectorRedirectedToConditionStartGroupBuilder()
    {
        return _connectorRedirectedToConditionStartGroupBuilder;
    }

    public IConnector<ICondition<IConnectorAndConditionEndGroup>> CreateConnectorRedirectedToConditionEndGroupBuilder()
    {
        return _connectorRedirectedToConditionEndGroupBuilder;
    }

    public IConnector<ICondition<INodeAndConnector>> CreateTransitiveConnectorBuilder()
    {
        return _createTransitiveConnectorBuilder;
    }
}