namespace SafeFluentXPath.Implementation.Api.Processors.Components;

internal class NodeProcessor(string nodeName) : IXPathComponentProcessor
{
    public string Process(IXPathComponentProcessor? previousComponent, IXPathComponentProcessor? nextComponent)
    {
        return nodeName;
    }
}
