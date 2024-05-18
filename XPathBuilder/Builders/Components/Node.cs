using XPathBuilder.Builders.Core;
using XpathBuilder.Components;
using XpathBuilder.Api;
using XpathBuilder.Api.Composites;

namespace XPathBuilder.Builders.Components;

/**
* <summary>
* This class provides a way to build an XPath.
* </summary>
*/
public class Node : INode
{
    private readonly XPathProcessor _xPathProcessor;

    private INodeAndCondition _nodeAndCondition;

    internal void Init(INodeAndCondition nodeAndConditionBuilder)
    {
        _nodeAndCondition = nodeAndConditionBuilder;
    }

    public Node(XPathProcessor xPathProcessor)
    {
        _xPathProcessor = xPathProcessor;
    }

    public INodeAndCondition Root(string elementName)
    {
        if (_xPathProcessor.GetXPathComponentCount() == 0 && !string.IsNullOrWhiteSpace(elementName))
        {
            _xPathProcessor.AddXPathComponent(new XpathBuilder.Components.Node($"{elementName}"));
        }

        return _nodeAndCondition;
    }

    public INodeAndCondition ChildNode(string elementName)
    {
        if (string.IsNullOrWhiteSpace(elementName)) return _nodeAndCondition;

        _xPathProcessor.AddXPathComponent(new XpathBuilder.Components.Node($"/{elementName}"));
        return _nodeAndCondition;
    }

    public INodeAndCondition Descendant(string descendant)
    {
        if (string.IsNullOrWhiteSpace(descendant)) return _nodeAndCondition;

        _xPathProcessor.AddXPathComponent(new XpathBuilder.Components.Node($"//{descendant}"));
        return _nodeAndCondition;
    }

    public string Build()
    {
        return _xPathProcessor.Build();
    }
}
