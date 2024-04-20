namespace XpathBuilder.Components;

public class Condition : XPathComponent
{
    private readonly string _condition;

    public Condition(string condition)
    {
        _condition = condition;
    }

    public string Process(XPathComponent? previousComponent, XPathComponent? nextComponent)
    {
        switch (previousComponent, nextComponent)
        {
            case (null, _):
                throw new InvalidOperationException("A condition must be preceded by a node or an operator");
            case (Node, Node):
                return $"[{_condition}]";
            case (Node, Connector):
                return $"[{_condition}";
            case (Connector, Node):
            case (Connector, null):
                return $"{_condition}]";
            default:
                return _condition;
        }
    }
}
