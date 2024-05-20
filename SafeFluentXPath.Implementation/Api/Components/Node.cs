using SafeFluentXPath.Abstraction.Api.Components;
using SafeFluentXPath.Abstraction.Api.Components.Composites;
using SafeFluentXPath.Implementation.Api.Processors;
using SafeFluentXPath.Implementation.Api.Processors.Components;

namespace SafeFluentXPath.Implementation.Api.Components;

/**
* <summary>
* This class provides a way to build an XPath.
* </summary>
*/
internal class Node(XPathProcessor xPathProcessor) : INode
{
    private IContextNodeAndCondition _contextNodeAndCondition;

    internal void Init(IContextNodeAndCondition nodeAndConditionBuilder)
    {
        _contextNodeAndCondition = nodeAndConditionBuilder;
    }

    public IContextNodeAndCondition Element(string elementName)
    {
        if (xPathProcessor.GetXPathComponentCount() == 0 && !string.IsNullOrWhiteSpace(elementName))
        {
            xPathProcessor.AddXPathComponent(new NodeProcessor($"{elementName}"));
        }

        return _contextNodeAndCondition;
    }
}
