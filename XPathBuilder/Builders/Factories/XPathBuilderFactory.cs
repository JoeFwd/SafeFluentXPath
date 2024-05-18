using XPathBuilder.Builders.Components;
using XpathBuilder.Builders.Composites;
using XPathBuilder.Builders.Core;
using XpathBuilder.Api;
using XpathBuilder.Api.Composites;

namespace XPathBuilder.Builders.Factories;

public class XPathBuilderFactory
{
    private readonly Node _node;
    private readonly ConditionGroup _conditionGroup;

    private readonly NodeAndCondition _nodeAndCondition;
    private readonly NodeAndConnector _nodeAndConnector;
    private readonly ConnectorAndConditionStartGroup _connectorAndConditionStartGroup;
    private readonly ConnectorAndConditionEndGroup _connectorAndConditionEndGroup;
    private readonly NodeAndConnectorAndGroupedCondition _nodeAndConnectorAndGroupedCondition;
    private readonly ConditionStartGroupAndNode _conditionStartGroupAndNode;
    private readonly ConditionStartGroupAndCondition _conditionStartGroupAndCondition;

    private readonly Condition<IConnectorAndConditionStartGroup> _conditionRedirectedToStartGroup;
    private readonly Condition<IConnectorAndConditionEndGroup> _conditionRedirectedToEndGroup;
    private readonly Condition<INodeAndConnector> _conditionRedirectedToNode;
    private readonly Condition<IConnector<IConditionStartGroupAndNode>> _conditionRedirectedToConnectorAllowingGroupedConditionAndNode;
    private readonly Condition<IConnector<IConditionStartGroupAndCondition>> _conditionRedirectedToConnectorAllowingGroupedCondition;
    private readonly Condition<INodeAndConnectorAndGroupedCondition> _conditionRedirectedToNodeAndConnectorAllowingGroupedCondition;
    
    private readonly Connector<ICondition<IConnectorAndConditionStartGroup>> _connectorRedirectedToConditionStartGroup;
    private readonly Connector<ICondition<IConnectorAndConditionEndGroup>> _connectorRedirectedToConditionEndGroup;
    private readonly Connector<ICondition<INodeAndConnector>> _createTransitiveConnector;
    private readonly Connector<IConditionStartGroupAndNode> _connectorRedirectedToConditionStartGroupAllowingNode;
    private readonly Connector<IConditionStartGroupAndCondition> _connectorRedirectedToConditionStartGroupAndCondition;
    
    public XPathBuilderFactory(XPathProcessor xPathProcessor)
    {
        _node = new Node(xPathProcessor);
        _conditionGroup = new ConditionGroup(xPathProcessor);

        // CompositeBuilders
        _nodeAndCondition = new NodeAndCondition();
        _nodeAndConnector = new NodeAndConnector();
        _connectorAndConditionStartGroup = new ConnectorAndConditionStartGroup();
        _connectorAndConditionEndGroup = new ConnectorAndConditionEndGroup();
        _conditionStartGroupAndCondition = new ConditionStartGroupAndCondition();
        _conditionStartGroupAndNode = new ConditionStartGroupAndNode();
        _nodeAndConnectorAndGroupedCondition = new NodeAndConnectorAndGroupedCondition();

        // ConditionBuilders
        _conditionRedirectedToStartGroup = new Condition<IConnectorAndConditionStartGroup>(xPathProcessor);
        _conditionRedirectedToEndGroup = new Condition<IConnectorAndConditionEndGroup>(xPathProcessor);
        _conditionRedirectedToNode = new Condition<INodeAndConnector>(xPathProcessor);
        _conditionRedirectedToConnectorAllowingGroupedConditionAndNode =
            new Condition<IConnector<IConditionStartGroupAndNode>>(xPathProcessor);
        _conditionRedirectedToConnectorAllowingGroupedCondition =
            new Condition<IConnector<IConditionStartGroupAndCondition>>(xPathProcessor);
        _conditionRedirectedToNodeAndConnectorAllowingGroupedCondition =
            new Condition<INodeAndConnectorAndGroupedCondition>(xPathProcessor);

        // ConnectorBuilders
        _connectorRedirectedToConditionStartGroup = new Connector<ICondition<IConnectorAndConditionStartGroup>>(xPathProcessor);
        _connectorRedirectedToConditionEndGroup = new Connector<ICondition<IConnectorAndConditionEndGroup>>(xPathProcessor);
        _createTransitiveConnector = new Connector<ICondition<INodeAndConnector>>(xPathProcessor);
        _connectorRedirectedToConditionStartGroupAllowingNode = new Connector<IConditionStartGroupAndNode>(xPathProcessor);
        _connectorRedirectedToConditionStartGroupAndCondition = new Connector<IConditionStartGroupAndCondition>(xPathProcessor);

        _node.Init(_nodeAndCondition);
        _conditionGroup.Init(_conditionRedirectedToEndGroup, _nodeAndConnectorAndGroupedCondition);
        _nodeAndCondition.Init(_node, _conditionRedirectedToNode, _conditionGroup);
        _nodeAndConnector.Init(_node, _createTransitiveConnector, _conditionGroup);
        _connectorAndConditionStartGroup.Init(_connectorRedirectedToConditionStartGroup, _conditionGroup);
        _connectorAndConditionEndGroup.Init(_connectorRedirectedToConditionEndGroup, _conditionGroup);
        _conditionStartGroupAndCondition.Init(_conditionRedirectedToConnectorAllowingGroupedCondition, _conditionGroup);
        _conditionStartGroupAndNode.Init(_conditionRedirectedToNodeAndConnectorAllowingGroupedCondition, _conditionGroup);
        _nodeAndConnectorAndGroupedCondition.Init(_node, _connectorRedirectedToConditionStartGroupAllowingNode);
        
        _conditionRedirectedToStartGroup.Init(_node, _connectorAndConditionStartGroup);
        _conditionRedirectedToEndGroup.Init(_node, _connectorAndConditionEndGroup);
        _conditionRedirectedToNode.Init(_node, _nodeAndConnector);
        _conditionRedirectedToConnectorAllowingGroupedConditionAndNode.Init(_node, _connectorRedirectedToConditionStartGroupAllowingNode);
        _conditionRedirectedToConnectorAllowingGroupedCondition.Init(_node, _connectorRedirectedToConditionStartGroupAndCondition);
        _conditionRedirectedToNodeAndConnectorAllowingGroupedCondition.Init(_node,
            _nodeAndConnectorAndGroupedCondition);
        
        _connectorRedirectedToConditionStartGroup.Init(_conditionRedirectedToStartGroup);
        _connectorRedirectedToConditionEndGroup.Init(_conditionRedirectedToEndGroup);
        _createTransitiveConnector.Init(_nodeAndCondition);
        _connectorRedirectedToConditionStartGroupAllowingNode.Init(_conditionStartGroupAndNode);
    }

    public INode CreateNodeBuilder()
    {
        return _node;
    }

    public INodeAndCondition CreateNodeAndConditionBuilder()
    {
        return _nodeAndCondition;
    }

    public IConditionEndGroup CreateConditionEndGroupBuilder()
    {
        return _conditionGroup;
    }

    public IConditionStartGroup CreateConditionStartGroupBuilder()
    {
        return _conditionGroup;
    }

    public IConnectorAndConditionStartGroup CreateConnectorAndConditionStartGroupBuilder()
    {
        return _connectorAndConditionStartGroup;
    }

    public IConnectorAndConditionEndGroup CreateConnectorAndConditionEndGroupBuilder()
    {
        return _connectorAndConditionEndGroup;
    }

    public ICondition<IConnectorAndConditionStartGroup> CreateConditionRedirectedToStartGroupBuilder()
    {
        return _conditionRedirectedToStartGroup;
    }

    public ICondition<IConnectorAndConditionEndGroup> CreateConditionRedirectedToEndGroupBuilder()
    {
        return _conditionRedirectedToEndGroup;
    }

    public ICondition<INodeAndConnector> CreateConditionRedirectedToNodeBuilder()
    {
        return _conditionRedirectedToNode;
    }

    public IConnector<ICondition<IConnectorAndConditionStartGroup>> CreateConnectorRedirectedToConditionStartGroupBuilder()
    {
        return _connectorRedirectedToConditionStartGroup;
    }

    public IConnector<ICondition<IConnectorAndConditionEndGroup>> CreateConnectorRedirectedToConditionEndGroupBuilder()
    {
        return _connectorRedirectedToConditionEndGroup;
    }

    public IConnector<ICondition<INodeAndConnector>> CreateTransitiveConnectorBuilder()
    {
        return _createTransitiveConnector;
    }
}