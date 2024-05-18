namespace FluentXPath.Implementation.Api.Processors.Components;

public class ConnectorProcessor(string @operator) : IXPathComponentProcessor
{
    public string Process(IXPathComponentProcessor? previousComponent, IXPathComponentProcessor? nextComponent)
    {
        return $" {@operator} ";
    }
}
