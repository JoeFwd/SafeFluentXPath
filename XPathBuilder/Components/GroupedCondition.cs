namespace XpathBuilder.Components;

public class GroupedCondition : XPathComponent
{
    public string Process(XPathComponent? previousComponent, XPathComponent? nextComponent)
    {
        switch (previousComponent, nextComponent)
        {
            case (Node, Condition):
            case (Connector, Condition):
                return "(";
            case (Condition, null):
            case (Condition, Node):
            case (Condition, Connector):
                return ")";
            default:
                throw new InvalidOperationException(
                    "A grouped condition must be preceded by a node or a connector and followed by a node " +
                    "or a connector or does not have to be followed by anything.");
        }
    }
}
