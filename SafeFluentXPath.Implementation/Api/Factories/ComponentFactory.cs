using SafeFluentXPath.Api.Components;
using SafeFluentXPath.Api.Components.Composites;
using SafeFluentXPath.Implementation.Api.Components;
using SafeFluentXPath.Implementation.Api.Components.Composites;
using SafeFluentXPath.Implementation.Api.Processors;

namespace SafeFluentXPath.Implementation.Api.Factories;

internal class ComponentFactory
{
    private readonly Node _node;
    private readonly ContextNode _contextNode;
    private readonly ConditionGroup _conditionGroup;

    private readonly ContextNodeAndCondition _contextNodeAndCondition;
    private readonly ContextNodeAndConnector _contextNodeAndConnector;
    private readonly ConnectorAndConditionStartGroup _connectorAndConditionStartGroup;
    private readonly ConnectorAndConditionEndGroup _connectorAndConditionEndGroup;
    private readonly ContextNodeAndConnectorAndGroupedCondition _contextNodeAndConnectorAndGroupedCondition;
    private readonly ConditionStartGroupAndContextNode _conditionStartGroupAndContextNode;
    private readonly ConditionStartGroupAndCondition _conditionStartGroupAndCondition;

    private readonly Condition<IConnectorAndConditionStartGroup> _conditionRedirectedToStartGroup;
    private readonly Condition<IConnectorAndConditionEndGroup> _conditionRedirectedToEndGroup;
    private readonly Condition<IContextNodeAndConnector> _conditionRedirectedToNode;
    private readonly Condition<IConnector<IConditionStartGroupAndContextNode>> _conditionRedirectedToConnectorAllowingGroupedConditionAndNode;
    private readonly Condition<IConnector<IConditionStartGroupAndCondition>> _conditionRedirectedToConnectorAllowingGroupedCondition;
    private readonly Condition<IContextNodeAndConnectorAndGroupedCondition> _conditionRedirectedToNodeAndConnectorAllowingGroupedCondition;
    
    private readonly Connector<ICondition<IConnectorAndConditionStartGroup>> _connectorRedirectedToConditionStartGroup;
    private readonly Connector<ICondition<IConnectorAndConditionEndGroup>> _connectorRedirectedToConditionEndGroup;
    private readonly Connector<ICondition<IContextNodeAndConnector>> _createTransitiveConnector;
    private readonly Connector<IConditionStartGroupAndContextNode> _connectorRedirectedToConditionStartGroupAllowingNode;
    private readonly Connector<IConditionStartGroupAndCondition> _connectorRedirectedToConditionStartGroupAndCondition;
    
    public ComponentFactory(XPathProcessor xPathProcessor)
    {
        _node = new Node(xPathProcessor);
        _contextNode = new ContextNode(xPathProcessor);
        _conditionGroup = new ConditionGroup(xPathProcessor);

        // CompositeBuilders
        _contextNodeAndCondition = new ContextNodeAndCondition();
        _contextNodeAndConnector = new ContextNodeAndConnector();
        _connectorAndConditionStartGroup = new ConnectorAndConditionStartGroup();
        _connectorAndConditionEndGroup = new ConnectorAndConditionEndGroup();
        _conditionStartGroupAndCondition = new ConditionStartGroupAndCondition();
        _conditionStartGroupAndContextNode = new ConditionStartGroupAndContextNode();
        _contextNodeAndConnectorAndGroupedCondition = new ContextNodeAndConnectorAndGroupedCondition();

        // ConditionBuilders
        _conditionRedirectedToStartGroup = new Condition<IConnectorAndConditionStartGroup>(xPathProcessor);
        _conditionRedirectedToEndGroup = new Condition<IConnectorAndConditionEndGroup>(xPathProcessor);
        _conditionRedirectedToNode = new Condition<IContextNodeAndConnector>(xPathProcessor);
        _conditionRedirectedToConnectorAllowingGroupedConditionAndNode =
            new Condition<IConnector<IConditionStartGroupAndContextNode>>(xPathProcessor);
        _conditionRedirectedToConnectorAllowingGroupedCondition =
            new Condition<IConnector<IConditionStartGroupAndCondition>>(xPathProcessor);
        _conditionRedirectedToNodeAndConnectorAllowingGroupedCondition =
            new Condition<IContextNodeAndConnectorAndGroupedCondition>(xPathProcessor);

        // ConnectorBuilders
        _connectorRedirectedToConditionStartGroup = new Connector<ICondition<IConnectorAndConditionStartGroup>>(xPathProcessor);
        _connectorRedirectedToConditionEndGroup = new Connector<ICondition<IConnectorAndConditionEndGroup>>(xPathProcessor);
        _createTransitiveConnector = new Connector<ICondition<IContextNodeAndConnector>>(xPathProcessor);
        _connectorRedirectedToConditionStartGroupAllowingNode = new Connector<IConditionStartGroupAndContextNode>(xPathProcessor);
        _connectorRedirectedToConditionStartGroupAndCondition = new Connector<IConditionStartGroupAndCondition>(xPathProcessor);

        _node.Init(_contextNodeAndCondition);
        _contextNode.Init(_contextNodeAndCondition);
        _conditionGroup.Init(_conditionRedirectedToEndGroup, _contextNodeAndConnectorAndGroupedCondition);
        _contextNodeAndCondition.Init(_contextNode, _conditionRedirectedToNode, _conditionGroup);
        _contextNodeAndConnector.Init(_contextNode, _createTransitiveConnector, _conditionGroup);
        _connectorAndConditionStartGroup.Init(_connectorRedirectedToConditionStartGroup, _conditionGroup);
        _connectorAndConditionEndGroup.Init(_connectorRedirectedToConditionEndGroup, _conditionGroup);
        _conditionStartGroupAndCondition.Init(_conditionRedirectedToConnectorAllowingGroupedCondition, _conditionGroup);
        _conditionStartGroupAndContextNode.Init(_conditionRedirectedToNodeAndConnectorAllowingGroupedCondition, _conditionGroup);
        _contextNodeAndConnectorAndGroupedCondition.Init(_contextNode, _connectorRedirectedToConditionStartGroupAllowingNode);
        
        _conditionRedirectedToStartGroup.Init(_contextNode, _connectorAndConditionStartGroup);
        _conditionRedirectedToEndGroup.Init(_contextNode, _connectorAndConditionEndGroup);
        _conditionRedirectedToNode.Init(_contextNode, _contextNodeAndConnector);
        _conditionRedirectedToConnectorAllowingGroupedConditionAndNode.Init(_contextNode, _connectorRedirectedToConditionStartGroupAllowingNode);
        _conditionRedirectedToConnectorAllowingGroupedCondition.Init(_contextNode, _connectorRedirectedToConditionStartGroupAndCondition);
        _conditionRedirectedToNodeAndConnectorAllowingGroupedCondition.Init(_contextNode,
            _contextNodeAndConnectorAndGroupedCondition);
        
        _connectorRedirectedToConditionStartGroup.Init(_conditionRedirectedToStartGroup);
        _connectorRedirectedToConditionEndGroup.Init(_conditionRedirectedToEndGroup);
        _createTransitiveConnector.Init(_contextNodeAndCondition);
        _connectorRedirectedToConditionStartGroupAllowingNode.Init(_conditionStartGroupAndContextNode);
    }

    public INode CreateNodeComponent()
    {
        return _node;
    }

    public IContextNode CreateContextNodeComponent()
    {
        return _contextNode;
    }
}
