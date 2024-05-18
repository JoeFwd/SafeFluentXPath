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

    private readonly NodeWithConditionBuilder _nodeWithConditionBuilder;
    private readonly NodeWithConnectorBuilder _nodeWithConnectorBuilder;
    private readonly ConnectorWithConditionStartGroupBuilder _connectorWithConditionStartGroupBuilder;
    private readonly ConnectorWithConditionEndGroupBuilder _connectorWithConditionEndGroupBuilder;
    private readonly NodeAndConnectorWithGroupedConditionBuilder _nodeAndConnectorWithGroupedConditionBuilder;
    private readonly ConditionStartGroupWithNodeBuilder _conditionStartGroupWithNodeBuilder;
    private readonly ConditionStartGroupWithConditionBuilder _conditionStartGroupWithConditionBuilder;

    private readonly ConditionBuilder<IConnectorWithConditionStartGroup> _conditionRedirectedToStartGroupBuilder;
    private readonly ConditionBuilder<IConnectorWithConditionEndGroup> _conditionRedirectedToEndGroupBuilder;
    private readonly ConditionBuilder<INodeWithConnector> _conditionRedirectedToNodeBuilder;
    private readonly ConditionBuilder<IConnector<IConditionStartGroupWithNode>> _conditionRedirectedToConnectorAllowingGroupedConditionAndNode;
    private readonly ConditionBuilder<IConnector<IConditionStartGroupWithCondition>> _conditionRedirectedToConnectorAllowingGroupedCondition;
    private readonly ConditionBuilder<INodeAndConnectorWithGroupedCondition> _conditionRedirectedToNodeAndConnectorAllowingGroupedCondition;
    
    private readonly ConnectorBuilder<ICondition<IConnectorWithConditionStartGroup>> _connectorRedirectedToConditionStartGroupBuilder;
    private readonly ConnectorBuilder<ICondition<IConnectorWithConditionEndGroup>> _connectorRedirectedToConditionEndGroupBuilder;
    private readonly ConnectorBuilder<ICondition<INodeWithConnector>> _createTransitiveConnectorBuilder;
    private readonly ConnectorBuilder<IConditionStartGroupWithNode> _connectorRedirectedToConditionStartGroupAllowingNode;
    private readonly ConnectorBuilder<IConditionStartGroupWithCondition> _connectorRedirectedToConditionStartGroupAndCondition;
    
    public XPathBuilderFactory(XPathProcessor xPathProcessor)
    {
        _nodeBuilder = new NodeBuilder(xPathProcessor);
        _conditionGroupBuilder = new ConditionGroupBuilder(xPathProcessor);

        // CompositeBuilders
        _nodeWithConditionBuilder = new NodeWithConditionBuilder();
        _nodeWithConnectorBuilder = new NodeWithConnectorBuilder();
        _connectorWithConditionStartGroupBuilder = new ConnectorWithConditionStartGroupBuilder();
        _connectorWithConditionEndGroupBuilder = new ConnectorWithConditionEndGroupBuilder();
        _conditionStartGroupWithConditionBuilder = new ConditionStartGroupWithConditionBuilder();
        _conditionStartGroupWithNodeBuilder = new ConditionStartGroupWithNodeBuilder();
        _nodeAndConnectorWithGroupedConditionBuilder = new NodeAndConnectorWithGroupedConditionBuilder();

        // ConditionBuilders
        _conditionRedirectedToStartGroupBuilder = new ConditionBuilder<IConnectorWithConditionStartGroup>(xPathProcessor);
        _conditionRedirectedToEndGroupBuilder = new ConditionBuilder<IConnectorWithConditionEndGroup>(xPathProcessor);
        _conditionRedirectedToNodeBuilder = new ConditionBuilder<INodeWithConnector>(xPathProcessor);
        _conditionRedirectedToConnectorAllowingGroupedConditionAndNode =
            new ConditionBuilder<IConnector<IConditionStartGroupWithNode>>(xPathProcessor);
        _conditionRedirectedToConnectorAllowingGroupedCondition =
            new ConditionBuilder<IConnector<IConditionStartGroupWithCondition>>(xPathProcessor);
        _conditionRedirectedToNodeAndConnectorAllowingGroupedCondition =
            new ConditionBuilder<INodeAndConnectorWithGroupedCondition>(xPathProcessor);

        // ConnectorBuilders
        _connectorRedirectedToConditionStartGroupBuilder = new ConnectorBuilder<ICondition<IConnectorWithConditionStartGroup>>(xPathProcessor);
        _connectorRedirectedToConditionEndGroupBuilder = new ConnectorBuilder<ICondition<IConnectorWithConditionEndGroup>>(xPathProcessor);
        _createTransitiveConnectorBuilder = new ConnectorBuilder<ICondition<INodeWithConnector>>(xPathProcessor);
        _connectorRedirectedToConditionStartGroupAllowingNode = new ConnectorBuilder<IConditionStartGroupWithNode>(xPathProcessor);
        _connectorRedirectedToConditionStartGroupAndCondition = new ConnectorBuilder<IConditionStartGroupWithCondition>(xPathProcessor);

        _nodeBuilder.Init(_nodeWithConditionBuilder);
        _conditionGroupBuilder.Init(_conditionRedirectedToEndGroupBuilder, _nodeAndConnectorWithGroupedConditionBuilder);
        _nodeWithConditionBuilder.Init(_nodeBuilder, _conditionRedirectedToNodeBuilder, _conditionGroupBuilder);
        _nodeWithConnectorBuilder.Init(_nodeBuilder, _createTransitiveConnectorBuilder, _conditionGroupBuilder);
        _connectorWithConditionStartGroupBuilder.Init(_connectorRedirectedToConditionStartGroupBuilder, _conditionGroupBuilder);
        _connectorWithConditionEndGroupBuilder.Init(_connectorRedirectedToConditionEndGroupBuilder, _conditionGroupBuilder);
        _conditionStartGroupWithConditionBuilder.Init(_conditionRedirectedToConnectorAllowingGroupedCondition, _conditionGroupBuilder);
        _conditionStartGroupWithNodeBuilder.Init(_conditionRedirectedToNodeAndConnectorAllowingGroupedCondition, _conditionGroupBuilder);
        _nodeAndConnectorWithGroupedConditionBuilder.Init(_nodeBuilder, _connectorRedirectedToConditionStartGroupAllowingNode);
        
        _conditionRedirectedToStartGroupBuilder.Init(_nodeBuilder, _connectorWithConditionStartGroupBuilder);
        _conditionRedirectedToEndGroupBuilder.Init(_nodeBuilder, _connectorWithConditionEndGroupBuilder);
        _conditionRedirectedToNodeBuilder.Init(_nodeBuilder, _nodeWithConnectorBuilder);
        _conditionRedirectedToConnectorAllowingGroupedConditionAndNode.Init(_nodeBuilder, _connectorRedirectedToConditionStartGroupAllowingNode);
        _conditionRedirectedToConnectorAllowingGroupedCondition.Init(_nodeBuilder, _connectorRedirectedToConditionStartGroupAndCondition);
        _conditionRedirectedToNodeAndConnectorAllowingGroupedCondition.Init(_nodeBuilder,
            _nodeAndConnectorWithGroupedConditionBuilder);
        
        _connectorRedirectedToConditionStartGroupBuilder.Init(_conditionRedirectedToStartGroupBuilder);
        _connectorRedirectedToConditionEndGroupBuilder.Init(_conditionRedirectedToEndGroupBuilder);
        _createTransitiveConnectorBuilder.Init(_nodeWithConditionBuilder);
        _connectorRedirectedToConditionStartGroupAllowingNode.Init(_conditionStartGroupWithNodeBuilder);
    }

    public INode CreateNodeBuilder()
    {
        return _nodeBuilder;
    }

    public INodeWithCondition CreateNodeAndConditionBuilder()
    {
        return _nodeWithConditionBuilder;
    }

    public IConditionEndGroup CreateConditionEndGroupBuilder()
    {
        return _conditionGroupBuilder;
    }

    public IConditionStartGroup CreateConditionStartGroupBuilder()
    {
        return _conditionGroupBuilder;
    }

    public IConnectorWithConditionStartGroup CreateConnectorAndConditionStartGroupBuilder()
    {
        return _connectorWithConditionStartGroupBuilder;
    }

    public IConnectorWithConditionEndGroup CreateConnectorAndConditionEndGroupBuilder()
    {
        return _connectorWithConditionEndGroupBuilder;
    }

    public ICondition<IConnectorWithConditionStartGroup> CreateConditionRedirectedToStartGroupBuilder()
    {
        return _conditionRedirectedToStartGroupBuilder;
    }

    public ICondition<IConnectorWithConditionEndGroup> CreateConditionRedirectedToEndGroupBuilder()
    {
        return _conditionRedirectedToEndGroupBuilder;
    }

    public ICondition<INodeWithConnector> CreateConditionRedirectedToNodeBuilder()
    {
        return _conditionRedirectedToNodeBuilder;
    }

    public IConnector<ICondition<IConnectorWithConditionStartGroup>> CreateConnectorRedirectedToConditionStartGroupBuilder()
    {
        return _connectorRedirectedToConditionStartGroupBuilder;
    }

    public IConnector<ICondition<IConnectorWithConditionEndGroup>> CreateConnectorRedirectedToConditionEndGroupBuilder()
    {
        return _connectorRedirectedToConditionEndGroupBuilder;
    }

    public IConnector<ICondition<INodeWithConnector>> CreateTransitiveConnectorBuilder()
    {
        return _createTransitiveConnectorBuilder;
    }
}