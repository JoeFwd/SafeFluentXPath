using SafeFluentXPath.Api.Components;
using SafeFluentXPath.Api.Components.Composites;
using SafeFluentXPath.Implementation.Api.Processors;
using SafeFluentXPath.Implementation.Api.Processors.Components;

namespace SafeFluentXPath.Implementation.Api.Components;

internal class ContextNode(XPathProcessor xPathProcessor) : IContextNode
{
    private IContextNodeAndCondition _contextNodeAndCondition;

    internal void Init(IContextNodeAndCondition nodeAndConditionBuilder)
    {
        _contextNodeAndCondition = nodeAndConditionBuilder;
    }

    public IContextNodeAndCondition ChildElement(string elementName)
    {
        if (string.IsNullOrWhiteSpace(elementName)) return _contextNodeAndCondition;

        xPathProcessor.AddXPathComponent(new NodeProcessor($"/{elementName}"));
        return _contextNodeAndCondition;
    }

    public IContextNodeAndCondition Descendant(string descendant)
    {
        if (string.IsNullOrWhiteSpace(descendant)) return _contextNodeAndCondition;

        xPathProcessor.AddXPathComponent(new NodeProcessor($"//{descendant}"));
        return _contextNodeAndCondition;
    }
}
