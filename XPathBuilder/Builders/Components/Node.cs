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

    private INodeWithCondition _nodeWithCondition;

    internal void Init(INodeWithCondition nodeWithConditionBuilder)
    {
        _nodeWithCondition = nodeWithConditionBuilder;
    }

    public Node(XPathProcessor xPathProcessor)
    {
        _xPathProcessor = xPathProcessor;
    }

    public INodeWithCondition Root(string elementName)
    {
        if (_xPathProcessor.GetXPathComponentCount() == 0 && !string.IsNullOrWhiteSpace(elementName))
        {
            _xPathProcessor.AddXPathComponent(new XpathBuilder.Components.Node($"{elementName}"));
        }

        return _nodeWithCondition;
    }

    public INodeWithCondition ChildNode(string elementName)
    {
        if (string.IsNullOrWhiteSpace(elementName)) return _nodeWithCondition;

        _xPathProcessor.AddXPathComponent(new XpathBuilder.Components.Node($"/{elementName}"));
        return _nodeWithCondition;
    }

    public INodeWithCondition Descendant(string descendant)
    {
        if (string.IsNullOrWhiteSpace(descendant)) return _nodeWithCondition;

        _xPathProcessor.AddXPathComponent(new XpathBuilder.Components.Node($"//{descendant}"));
        return _nodeWithCondition;
    }

    public string Build()
    {
        return _xPathProcessor.Build();
    }
}
