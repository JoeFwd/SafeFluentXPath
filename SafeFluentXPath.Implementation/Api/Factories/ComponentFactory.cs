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
    
    public ComponentFactory(XPathProcessor xPathProcessor)
    {
        _node = new Node(xPathProcessor);
        _contextNode = new ContextNode(xPathProcessor);
        var conditionGroup = new ConditionGroup(xPathProcessor);

        // CompositeBuilders
        var contextNodeAndCondition = new ContextNodeAndCondition();
        var contextNodeAndConnector = new ContextNodeAndConnector();
        var connectorAndConditionStartGroup = new ConnectorAndConditionStartGroup();
        var connectorAndConditionEndGroup = new ConnectorAndConditionEndGroup();
        var conditionStartGroupAndCondition = new ConditionStartGroupAndCondition();
        var conditionStartGroupAndContextNode = new ConditionStartGroupAndContextNode();
        var contextNodeAndConnectorAndGroupedCondition = new ContextNodeAndConnectorAndGroupedCondition();

        // ConditionBuilders
        var conditionRedirectedToStartGroup = new Condition<IConnectorAndConditionStartGroup>(xPathProcessor);
        var conditionRedirectedToEndGroup = new Condition<IConnectorAndConditionEndGroup>(xPathProcessor);
        var conditionRedirectedToNode = new Condition<IContextNodeAndConnector>(xPathProcessor);
        var conditionRedirectedToConnectorAllowingGroupedConditionAndNode =
            new Condition<IConnector<IConditionStartGroupAndContextNode>>(xPathProcessor);
        var conditionRedirectedToConnectorAllowingGroupedCondition =
            new Condition<IConnector<IConditionStartGroupAndCondition>>(xPathProcessor);
        var conditionRedirectedToNodeAndConnectorAllowingGroupedCondition =
            new Condition<IContextNodeAndConnectorAndGroupedCondition>(xPathProcessor);

        // ConnectorBuilders
        var connectorRedirectedToConditionStartGroup = new Connector<ICondition<IConnectorAndConditionStartGroup>>(xPathProcessor);
        var connectorRedirectedToConditionEndGroup = new Connector<ICondition<IConnectorAndConditionEndGroup>>(xPathProcessor);
        var createTransitiveConnector = new Connector<ICondition<IContextNodeAndConnector>>(xPathProcessor);
        var connectorRedirectedToConditionStartGroupAllowingNode = new Connector<IConditionStartGroupAndContextNode>(xPathProcessor);
        var connectorRedirectedToConditionStartGroupAndCondition = new Connector<IConditionStartGroupAndCondition>(xPathProcessor);

        _node.Init(contextNodeAndCondition);
        _contextNode.Init(contextNodeAndCondition);
        conditionGroup.Init(conditionRedirectedToEndGroup, contextNodeAndConnectorAndGroupedCondition);
        contextNodeAndCondition.Init(_contextNode, conditionRedirectedToNode, conditionGroup);
        contextNodeAndConnector.Init(_contextNode, createTransitiveConnector, conditionGroup);
        connectorAndConditionStartGroup.Init(connectorRedirectedToConditionStartGroup, conditionGroup);
        connectorAndConditionEndGroup.Init(connectorRedirectedToConditionEndGroup, conditionGroup);
        conditionStartGroupAndCondition.Init(conditionRedirectedToConnectorAllowingGroupedCondition, conditionGroup);
        conditionStartGroupAndContextNode.Init(conditionRedirectedToNodeAndConnectorAllowingGroupedCondition, conditionGroup);
        contextNodeAndConnectorAndGroupedCondition.Init(_contextNode, connectorRedirectedToConditionStartGroupAllowingNode);
        
        conditionRedirectedToStartGroup.Init(_contextNode, connectorAndConditionStartGroup);
        conditionRedirectedToEndGroup.Init(_contextNode, connectorAndConditionEndGroup);
        conditionRedirectedToNode.Init(_contextNode, contextNodeAndConnector);
        conditionRedirectedToConnectorAllowingGroupedConditionAndNode.Init(_contextNode, connectorRedirectedToConditionStartGroupAllowingNode);
        conditionRedirectedToConnectorAllowingGroupedCondition.Init(_contextNode, connectorRedirectedToConditionStartGroupAndCondition);
        conditionRedirectedToNodeAndConnectorAllowingGroupedCondition.Init(_contextNode,
            contextNodeAndConnectorAndGroupedCondition);
        
        connectorRedirectedToConditionStartGroup.Init(conditionRedirectedToStartGroup);
        connectorRedirectedToConditionEndGroup.Init(conditionRedirectedToEndGroup);
        createTransitiveConnector.Init(contextNodeAndCondition);
        connectorRedirectedToConditionStartGroupAllowingNode.Init(conditionStartGroupAndContextNode);
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
