using SafeFluentXPath.Api;
using SafeFluentXPath.Api.Components;
using SafeFluentXPath.Api.Components.Composites;
using SafeFluentXPath.Implementation.Api.Factories;
using SafeFluentXPath.Implementation.Api.Processors;

namespace SafeFluentXPath.Implementation.Api;

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

    public INodeAndCondition Element(string elementName)
    {
        return _node.Element(elementName);
    }

    public INodeAndCondition ChildElement(string elementName)
    {
        return _node.ChildElement(elementName);
    }

    public INodeAndCondition Descendant(string descendant)
    {
        return _node.Descendant(descendant);
    }

    public string Build()
    {
        return _xPathProcessor.Build();
    }
}