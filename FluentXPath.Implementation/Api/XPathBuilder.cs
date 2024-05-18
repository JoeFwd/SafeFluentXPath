using FluentXPath.Api;
using FluentXPath.Api.Components;
using FluentXPath.Api.Components.Composites;
using FluentXPath.Implementation.Api.Factories;
using FluentXPath.Implementation.Api.Processors;

namespace FluentXPath.Implementation.Api;

public class XPathBuilder : IXPath
{
    private readonly XPathProcessor _xPathProcessor = new ();

    private readonly INode _node;

    private readonly IConnector<ICondition<IConnectorAndConditionStartGroup>>
        _connectorRedirectedToChainedCondition;

    private readonly IConnector<ICondition<IConnectorAndConditionEndGroup>>
        _connectorRedirectedToConditionEndGroup;

    private readonly IConditionStartGroup _conditionStartGroup;
    private readonly IConditionEndGroup _conditionEndGroup;
    private readonly ICondition<INodeAndConnector> _conditionRedirectedToNode;
    private readonly ICondition<IConnectorAndConditionEndGroup> _conditionRedirectedToEndGroup;

    public XPathBuilder()
    {
        var componentFactory = new ComponentFactory(_xPathProcessor);
        _node = componentFactory.CreateNodeComponent();
        _connectorRedirectedToChainedCondition = componentFactory.CreateConnectorAndConditionStartGroupComponent();
        _connectorRedirectedToConditionEndGroup = componentFactory.CreateConnectorAndConditionEndGroupComponent();
        _conditionStartGroup = componentFactory.CreateConditionStartGroupComponent();
        _conditionEndGroup = componentFactory.CreateConditionEndGroupComponent();
        _conditionRedirectedToNode = componentFactory.CreateConditionRedirectedToNodeComponent();
        _conditionRedirectedToEndGroup = componentFactory.CreateConditionRedirectedToEndGroupComponent();
    }

    public INodeAndCondition Root(string elementName)
    {
        return _node.Root(elementName);
    }

    public INodeAndCondition ChildNode(string elementName)
    {
        return _node.ChildNode(elementName);
    }

    public INodeAndCondition Descendant(string descendant)
    {
        return _node.Descendant(descendant);
    }

    public string Build()
    {
        return _xPathProcessor.Build();
    }

    ICondition<IConnectorAndConditionEndGroup> IConnector<ICondition<IConnectorAndConditionEndGroup>>.And()
    {
        return _connectorRedirectedToConditionEndGroup.And();
    }

    public ICondition<IConnectorAndConditionStartGroup> And()
    {
        return _connectorRedirectedToChainedCondition.And();
    }

    public ICondition<IConnectorAndConditionStartGroup> Or()
    {
        return _connectorRedirectedToChainedCondition.Or();
    }

    ICondition<IConnectorAndConditionEndGroup> IConnector<ICondition<IConnectorAndConditionEndGroup>>.Or()
    {
        return _connectorRedirectedToConditionEndGroup.Or();
    }

    public INodeAndConnector WithAttribute(string attributeName, string attributeValue)
    {
        return _conditionRedirectedToNode.WithAttribute(attributeName, attributeValue);
    }

    IConnectorAndConditionEndGroup ICondition<IConnectorAndConditionEndGroup>.AtPosition(
        int position)
    {
        return _conditionRedirectedToEndGroup.AtPosition(position);
    }

    IConnectorAndConditionEndGroup ICondition<IConnectorAndConditionEndGroup>.NodeHasName(
        string nodeName)
    {
        return _conditionRedirectedToEndGroup.NodeHasName(nodeName);
    }

    IConnectorAndConditionEndGroup ICondition<IConnectorAndConditionEndGroup>.ChildNodesAtSameLevel(
        params string[] elementNames)
    {
        return _conditionRedirectedToEndGroup.ChildNodesAtSameLevel(elementNames);
    }

    IConnectorAndConditionEndGroup ICondition<IConnectorAndConditionEndGroup>.WithAttribute(
        string attributeName, string attributeValue)
    {
        return _conditionRedirectedToEndGroup.WithAttribute(attributeName, attributeValue);
    }

    public INodeAndConnector AtPosition(int position)
    {
        return _conditionRedirectedToNode.AtPosition(position);
    }

    public INodeAndConnector NodeHasName(string nodeName)
    {
        return _conditionRedirectedToNode.NodeHasName(nodeName);
    }

    INodeAndConnector ICondition<INodeAndConnector>.ChildNodesAtSameLevel(params string[] elementNames)
    {
        return _conditionRedirectedToNode.ChildNodesAtSameLevel(elementNames);
    }

    public ICondition<IConnectorAndConditionEndGroup> StartGroupCondition()
    {
        return _conditionStartGroup.StartGroupCondition();
    }

    public INodeAndConnectorAndGroupedCondition EndConditionGroup()
    {
        return _conditionEndGroup.EndConditionGroup();
    }
}