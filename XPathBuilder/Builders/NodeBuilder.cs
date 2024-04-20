using XpathBuilder.Builders.Composites;
using XpathBuilder.Components;
using XpathBuilder.ReturnLogic;
using XpathBuilder.ReturnLogic.Composites;

namespace XpathBuilder.Builders;

/**
* <summary>
* This class provides a way to build an XPath.
* </summary>
*/
public class NodeBuilder : INode
{
    private readonly XPathProcessor _xPathProcessor;

    private INodeAndCondition _nodeAndCondition;

    internal void Init(NodeAndConditionBuilder nodeAndConditionBuilder)
    {
        _nodeAndCondition = nodeAndConditionBuilder;
    }

    public NodeBuilder(XPathProcessor xPathProcessor)
    {
        _xPathProcessor = xPathProcessor;
    }

    public INodeAndCondition Root(string elementName)
    {
        if (_xPathProcessor.GetXPathComponentCount() == 0 && !string.IsNullOrWhiteSpace(elementName))
        {
            _xPathProcessor.AddXPathComponent(new Node($"{elementName}"));
        }

        return _nodeAndCondition;
    }

    public INodeAndCondition ChildNode(string elementName)
    {
        if (string.IsNullOrWhiteSpace(elementName)) return _nodeAndCondition;

        _xPathProcessor.AddXPathComponent(new Node($"/{elementName}"));
        return _nodeAndCondition;
    }

    public INodeAndCondition Descendant(string descendant)
    {
        if (string.IsNullOrWhiteSpace(descendant)) return _nodeAndCondition;

        _xPathProcessor.AddXPathComponent(new Node($"//{descendant}"));
        return _nodeAndCondition;
    }

    public string Build()
    {
        return _xPathProcessor.Build();
    }
}
