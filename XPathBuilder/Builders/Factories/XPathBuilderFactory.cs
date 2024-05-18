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

    private readonly NodeWithCondition _nodeWithCondition;
    private readonly NodeWithConnector _nodeWithConnector;
    private readonly ConnectorWithConditionStartGroup _connectorWithConditionStartGroup;
    private readonly ConnectorWithConditionEndGroup _connectorWithConditionEndGroup;
    private readonly NodeAndConnectorWithGroupedCondition _nodeAndConnectorWithGroupedCondition;
    private readonly ConditionStartGroupWithNode _conditionStartGroupWithNode;
    private readonly ConditionStartGroupWithCondition _conditionStartGroupWithCondition;

    private readonly Condition<IConnectorWithConditionStartGroup> _conditionRedirectedToStartGroup;
    private readonly Condition<IConnectorWithConditionEndGroup> _conditionRedirectedToEndGroup;
    private readonly Condition<INodeWithConnector> _conditionRedirectedToNode;
    private readonly Condition<IConnector<IConditionStartGroupWithNode>> _conditionRedirectedToConnectorAllowingGroupedConditionAndNode;
    private readonly Condition<IConnector<IConditionStartGroupWithCondition>> _conditionRedirectedToConnectorAllowingGroupedCondition;
    private readonly Condition<INodeAndConnectorWithGroupedCondition> _conditionRedirectedToNodeAndConnectorAllowingGroupedCondition;
    
    private readonly Connector<ICondition<IConnectorWithConditionStartGroup>> _connectorRedirectedToConditionStartGroup;
    private readonly Connector<ICondition<IConnectorWithConditionEndGroup>> _connectorRedirectedToConditionEndGroup;
    private readonly Connector<ICondition<INodeWithConnector>> _createTransitiveConnector;
    private readonly Connector<IConditionStartGroupWithNode> _connectorRedirectedToConditionStartGroupAllowingNode;
    private readonly Connector<IConditionStartGroupWithCondition> _connectorRedirectedToConditionStartGroupAndCondition;
    
    public XPathBuilderFactory(XPathProcessor xPathProcessor)
    {
        _node = new Node(xPathProcessor);
        _conditionGroup = new ConditionGroup(xPathProcessor);

        // CompositeBuilders
        _nodeWithCondition = new NodeWithCondition();
        _nodeWithConnector = new NodeWithConnector();
        _connectorWithConditionStartGroup = new ConnectorWithConditionStartGroup();
        _connectorWithConditionEndGroup = new ConnectorWithConditionEndGroup();
        _conditionStartGroupWithCondition = new ConditionStartGroupWithCondition();
        _conditionStartGroupWithNode = new ConditionStartGroupWithNode();
        _nodeAndConnectorWithGroupedCondition = new NodeAndConnectorWithGroupedCondition();

        // ConditionBuilders
        _conditionRedirectedToStartGroup = new Condition<IConnectorWithConditionStartGroup>(xPathProcessor);
        _conditionRedirectedToEndGroup = new Condition<IConnectorWithConditionEndGroup>(xPathProcessor);
        _conditionRedirectedToNode = new Condition<INodeWithConnector>(xPathProcessor);
        _conditionRedirectedToConnectorAllowingGroupedConditionAndNode =
            new Condition<IConnector<IConditionStartGroupWithNode>>(xPathProcessor);
        _conditionRedirectedToConnectorAllowingGroupedCondition =
            new Condition<IConnector<IConditionStartGroupWithCondition>>(xPathProcessor);
        _conditionRedirectedToNodeAndConnectorAllowingGroupedCondition =
            new Condition<INodeAndConnectorWithGroupedCondition>(xPathProcessor);

        // ConnectorBuilders
        _connectorRedirectedToConditionStartGroup = new Connector<ICondition<IConnectorWithConditionStartGroup>>(xPathProcessor);
        _connectorRedirectedToConditionEndGroup = new Connector<ICondition<IConnectorWithConditionEndGroup>>(xPathProcessor);
        _createTransitiveConnector = new Connector<ICondition<INodeWithConnector>>(xPathProcessor);
        _connectorRedirectedToConditionStartGroupAllowingNode = new Connector<IConditionStartGroupWithNode>(xPathProcessor);
        _connectorRedirectedToConditionStartGroupAndCondition = new Connector<IConditionStartGroupWithCondition>(xPathProcessor);

        _node.Init(_nodeWithCondition);
        _conditionGroup.Init(_conditionRedirectedToEndGroup, _nodeAndConnectorWithGroupedCondition);
        _nodeWithCondition.Init(_node, _conditionRedirectedToNode, _conditionGroup);
        _nodeWithConnector.Init(_node, _createTransitiveConnector, _conditionGroup);
        _connectorWithConditionStartGroup.Init(_connectorRedirectedToConditionStartGroup, _conditionGroup);
        _connectorWithConditionEndGroup.Init(_connectorRedirectedToConditionEndGroup, _conditionGroup);
        _conditionStartGroupWithCondition.Init(_conditionRedirectedToConnectorAllowingGroupedCondition, _conditionGroup);
        _conditionStartGroupWithNode.Init(_conditionRedirectedToNodeAndConnectorAllowingGroupedCondition, _conditionGroup);
        _nodeAndConnectorWithGroupedCondition.Init(_node, _connectorRedirectedToConditionStartGroupAllowingNode);
        
        _conditionRedirectedToStartGroup.Init(_node, _connectorWithConditionStartGroup);
        _conditionRedirectedToEndGroup.Init(_node, _connectorWithConditionEndGroup);
        _conditionRedirectedToNode.Init(_node, _nodeWithConnector);
        _conditionRedirectedToConnectorAllowingGroupedConditionAndNode.Init(_node, _connectorRedirectedToConditionStartGroupAllowingNode);
        _conditionRedirectedToConnectorAllowingGroupedCondition.Init(_node, _connectorRedirectedToConditionStartGroupAndCondition);
        _conditionRedirectedToNodeAndConnectorAllowingGroupedCondition.Init(_node,
            _nodeAndConnectorWithGroupedCondition);
        
        _connectorRedirectedToConditionStartGroup.Init(_conditionRedirectedToStartGroup);
        _connectorRedirectedToConditionEndGroup.Init(_conditionRedirectedToEndGroup);
        _createTransitiveConnector.Init(_nodeWithCondition);
        _connectorRedirectedToConditionStartGroupAllowingNode.Init(_conditionStartGroupWithNode);
    }

    public INode CreateNodeBuilder()
    {
        return _node;
    }

    public INodeWithCondition CreateNodeAndConditionBuilder()
    {
        return _nodeWithCondition;
    }

    public IConditionEndGroup CreateConditionEndGroupBuilder()
    {
        return _conditionGroup;
    }

    public IConditionStartGroup CreateConditionStartGroupBuilder()
    {
        return _conditionGroup;
    }

    public IConnectorWithConditionStartGroup CreateConnectorAndConditionStartGroupBuilder()
    {
        return _connectorWithConditionStartGroup;
    }

    public IConnectorWithConditionEndGroup CreateConnectorAndConditionEndGroupBuilder()
    {
        return _connectorWithConditionEndGroup;
    }

    public ICondition<IConnectorWithConditionStartGroup> CreateConditionRedirectedToStartGroupBuilder()
    {
        return _conditionRedirectedToStartGroup;
    }

    public ICondition<IConnectorWithConditionEndGroup> CreateConditionRedirectedToEndGroupBuilder()
    {
        return _conditionRedirectedToEndGroup;
    }

    public ICondition<INodeWithConnector> CreateConditionRedirectedToNodeBuilder()
    {
        return _conditionRedirectedToNode;
    }

    public IConnector<ICondition<IConnectorWithConditionStartGroup>> CreateConnectorRedirectedToConditionStartGroupBuilder()
    {
        return _connectorRedirectedToConditionStartGroup;
    }

    public IConnector<ICondition<IConnectorWithConditionEndGroup>> CreateConnectorRedirectedToConditionEndGroupBuilder()
    {
        return _connectorRedirectedToConditionEndGroup;
    }

    public IConnector<ICondition<INodeWithConnector>> CreateTransitiveConnectorBuilder()
    {
        return _createTransitiveConnector;
    }
}