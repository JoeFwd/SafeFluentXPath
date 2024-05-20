using SafeFluentXPath.Api.Components;
using SafeFluentXPath.Api.Components.Composites;
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
    private INodeAndCondition _nodeAndCondition;

    internal void Init(INodeAndCondition nodeAndConditionBuilder)
    {
        _nodeAndCondition = nodeAndConditionBuilder;
    }

    public INodeAndCondition Root(string elementName)
    {
        if (xPathProcessor.GetXPathComponentCount() == 0 && !string.IsNullOrWhiteSpace(elementName))
        {
            xPathProcessor.AddXPathComponent(new NodeProcessor($"{elementName}"));
        }

        return _nodeAndCondition;
    }

    public INodeAndCondition ChildNode(string elementName)
    {
        if (string.IsNullOrWhiteSpace(elementName)) return _nodeAndCondition;

        xPathProcessor.AddXPathComponent(new NodeProcessor($"/{elementName}"));
        return _nodeAndCondition;
    }

    public INodeAndCondition Descendant(string descendant)
    {
        if (string.IsNullOrWhiteSpace(descendant)) return _nodeAndCondition;

        xPathProcessor.AddXPathComponent(new NodeProcessor($"//{descendant}"));
        return _nodeAndCondition;
    }

    public string Build()
    {
        return xPathProcessor.Build();
    }
}
