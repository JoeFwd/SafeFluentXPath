namespace FluentXPath.Implementation.Api.Processors.Components;

public class NodeProcessor(string nodeName) : IXPathComponentProcessor
{
    public string Process(IXPathComponentProcessor? previousComponent, IXPathComponentProcessor? nextComponent)
    {
        return nodeName;
    }
}
