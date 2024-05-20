using SafeFluentXPath.Abstraction.Api.Components;
using SafeFluentXPath.Abstraction.Api.Components.Composites;

namespace SafeFluentXPath.Implementation.Api.Components.Composites;

internal class ContextNodeAndCondition : IContextNodeAndCondition
{
    private IContextNode _contextNode;

    private ICondition<IContextNodeAndConnector> _conditionRedirectedToNodeAndConnector;

    private IConditionStartGroup _conditionStartGroup;

    private IEnd _end;

    internal void Init(
        IContextNode contextNode,
        ICondition<IContextNodeAndConnector> conditionRedirectedToNodeAndConnector,
        IConditionStartGroup conditionStartGroup,
        IEnd end)
    {
        _contextNode = contextNode;
        _conditionRedirectedToNodeAndConnector = conditionRedirectedToNodeAndConnector;
        _conditionStartGroup = conditionStartGroup;
        _end = end;
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

    public IContextNodeAndConnector WithAttribute(string attributeName, string attributeValue)
    {
        return _conditionRedirectedToNodeAndConnector.WithAttribute(attributeName, attributeValue);
    }

    public IContextNodeAndConnector AtPosition(int position)
    {
        return _conditionRedirectedToNodeAndConnector.AtPosition(position);
    }

    public IContextNodeAndConnector HasName(string elementName)
    {
        return _conditionRedirectedToNodeAndConnector.HasName(elementName);
    }

    public ICondition<IConnectorAndConditionEndGroup> StartGroupCondition()
    {
        return _conditionStartGroup.StartGroupCondition();
    }

    public string Build()
    {
        return _end.Build();
    }
}
