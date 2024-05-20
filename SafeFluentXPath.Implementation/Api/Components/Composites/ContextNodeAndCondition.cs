using SafeFluentXPath.Api.Components;
using SafeFluentXPath.Api.Components.Composites;

namespace SafeFluentXPath.Implementation.Api.Components.Composites;

internal class ContextNodeAndCondition : IContextNodeAndCondition
{
    private IContextNode _contextNode;

    private ICondition<IContextNodeAndConnector> _conditionRedirectedToNodeAndConnector;

    private IConditionStartGroup _conditionStartGroup;

    internal void Init(IContextNode contextNode, ICondition<IContextNodeAndConnector> conditionRedirectedToNodeAndConnector,
        IConditionStartGroup conditionStartGroup)
    {
        _contextNode = contextNode;
        _conditionRedirectedToNodeAndConnector = conditionRedirectedToNodeAndConnector;
        _conditionStartGroup = conditionStartGroup;
    }

    public IContextNodeAndCondition ChildElement(string elementName)
    {
        return _contextNode.ChildElement(elementName);
    }

    public IContextNodeAndCondition Descendant(string descendant)
    {
        return _contextNode.Descendant(descendant);
    }

    public IContextNodeAndConnector ChildElementsAtSameLevel(params string[] elementNames)
    {
        return _conditionRedirectedToNodeAndConnector.ChildElementsAtSameLevel(elementNames);
    }

    public string Build()
    {
        return _contextNode.Build();
    }

    public IContextNodeAndConnector WithAttribute(string attributeName, string attributeValue)
    {
        return _conditionRedirectedToNodeAndConnector.WithAttribute(attributeName, attributeValue);
    }

    public IContextNodeAndConnector AtPosition(int position)
    {
        return _conditionRedirectedToNodeAndConnector.AtPosition(position);
    }

    public IContextNodeAndConnector HasName(string nodeName)
    {
        return _conditionRedirectedToNodeAndConnector.HasName(nodeName);
    }

    public ICondition<IConnectorAndConditionEndGroup> StartGroupCondition()
    {
        return _conditionStartGroup.StartGroupCondition();
    }
}
