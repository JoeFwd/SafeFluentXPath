namespace SafeFluentXPath.Implementation.Api.Processors.Components;

internal class ConnectorProcessor(string @operator) : IXPathComponentProcessor
{
    public string Process(IXPathComponentProcessor? previousComponent, IXPathComponentProcessor? nextComponent)
    {
        return $" {@operator} ";
    }
}
