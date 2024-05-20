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
    private readonly IContextNode _contextNode;

    public XPathBuilder()
    {
        var componentFactory = new ComponentFactory(_xPathProcessor);
        _node = componentFactory.CreateNodeComponent();
        _contextNode = componentFactory.CreateContextNodeComponent();
    }

    public IContextNodeAndCondition Element(string elementName)
    {
        return _node.Element(elementName);
    }

    public IContextNodeAndCondition ChildElement(string elementName)
    {
        return _contextNode.ChildElement(elementName);
    }

    public IContextNodeAndCondition Descendant(string descendant)
    {
        return _contextNode.Descendant(descendant);
    }

    public string Build()
    {
        return _contextNode.Build();
    }
}