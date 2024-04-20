namespace XpathBuilder.Components;

public class Connector : XPathComponent
{
    private readonly string _operator;

    public Connector(string @operator)
    {
        _operator = @operator;
    }

    public string Process(XPathComponent? previousComponent, XPathComponent? nextComponent)
    {
        return $" {_operator} ";
    }
}
