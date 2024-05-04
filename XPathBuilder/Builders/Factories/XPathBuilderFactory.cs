using XpathBuilder.Builders;
using XPathBuilder.Builders.Components;
using XpathBuilder.Builders.Composites;
using XPathBuilder.Builders.Core;
using XpathBuilder.ReturnLogic;
using XpathBuilder.ReturnLogic.Composites;

namespace XPathBuilder.Builders.Factories;

public class XPathBuilderFactory
{
    private readonly NodeBuilder _nodeBuilder;
    private readonly NodeAndConditionBuilder _nodeAndConditionBuilder;
    private readonly NodeAndConnectorBuilder _nodeAndConnectorBuilder;
    private readonly ConditionGroupBuilder _conditionGroupBuilder;
    private readonly ConnectorAndConditionStartGroupBuilder _connectorAndConditionStartGroupBuilder;
    private readonly ConnectorAndConditionEndGroupBuilder _connectorAndConditionEndGroupBuilder;
    private readonly ConditionBuilder<IConnectorAndConditionStartGroup> _conditionRedirectedToStartGroupBuilder;
    private readonly ConditionBuilder<IConnectorAndConditionEndGroup> _conditionRedirectedToEndGroupBuilder;
    private readonly ConditionBuilder<INodeAndConnector> _conditionRedirectedToNodeBuilder;
    private readonly ConnectorBuilder<ICondition<IConnectorAndConditionStartGroup>>
        _connectorRedirectedToConditionStartGroupBuilder;
    private readonly ConnectorBuilder<ICondition<IConnectorAndConditionEndGroup>>
        _connectorRedirectedToConditionEndGroupBuilder;
    private readonly ConnectorBuilder<ICondition<INodeAndConnector>> _createTransitiveConnectorBuilder;

    
    public XPathBuilderFactory(XPathProcessor xPathProcessor)
    {
        _nodeBuilder = new NodeBuilder(xPathProcessor);
        _conditionGroupBuilder = new ConditionGroupBuilder(xPathProcessor);

        // CompositeBuilders
        _nodeAndConditionBuilder = new NodeAndConditionBuilder();
        _nodeAndConnectorBuilder = new NodeAndConnectorBuilder();
        _connectorAndConditionStartGroupBuilder = new ConnectorAndConditionStartGroupBuilder();
        _connectorAndConditionEndGroupBuilder = new ConnectorAndConditionEndGroupBuilder();

        // ConditionBuilders
        _conditionRedirectedToStartGroupBuilder = new ConditionBuilder<IConnectorAndConditionStartGroup>(xPathProcessor);
        _conditionRedirectedToEndGroupBuilder = new ConditionBuilder<IConnectorAndConditionEndGroup>(xPathProcessor);
        _conditionRedirectedToNodeBuilder = new ConditionBuilder<INodeAndConnector>(xPathProcessor);

        // ConnectorBuilders
        _connectorRedirectedToConditionStartGroupBuilder = new ConnectorBuilder<ICondition<IConnectorAndConditionStartGroup>>(xPathProcessor);
        _connectorRedirectedToConditionEndGroupBuilder = new ConnectorBuilder<ICondition<IConnectorAndConditionEndGroup>>(xPathProcessor);
        _createTransitiveConnectorBuilder = new ConnectorBuilder<ICondition<INodeAndConnector>>(xPathProcessor);

        _nodeBuilder.Init(_nodeAndConditionBuilder);
        _conditionGroupBuilder.Init(_conditionRedirectedToEndGroupBuilder, _nodeAndConnectorBuilder);
        _nodeAndConditionBuilder.Init(_nodeBuilder, _conditionRedirectedToNodeBuilder, _conditionGroupBuilder);
        _nodeAndConnectorBuilder.Init(_nodeBuilder, _createTransitiveConnectorBuilder, _conditionGroupBuilder);
        _connectorAndConditionStartGroupBuilder.Init(_connectorRedirectedToConditionStartGroupBuilder, _conditionGroupBuilder);
        _connectorAndConditionEndGroupBuilder.Init(_connectorRedirectedToConditionEndGroupBuilder, _conditionGroupBuilder);
        _conditionRedirectedToStartGroupBuilder.Init(_nodeBuilder, _connectorAndConditionStartGroupBuilder);
        _conditionRedirectedToEndGroupBuilder.Init(_nodeBuilder, _connectorAndConditionEndGroupBuilder);
        _conditionRedirectedToNodeBuilder.Init(_nodeBuilder, _nodeAndConnectorBuilder);
        _connectorRedirectedToConditionStartGroupBuilder.Init(_conditionRedirectedToStartGroupBuilder);
        _connectorRedirectedToConditionEndGroupBuilder.Init(_conditionRedirectedToEndGroupBuilder);
        _createTransitiveConnectorBuilder.Init(_nodeAndConditionBuilder);
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