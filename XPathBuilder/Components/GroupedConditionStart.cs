namespace XpathBuilder.Components;

public class GroupedConditionStart : XPathComponent
{
    public string Process(XPathComponent? previousComponent, XPathComponent? nextComponent)
    {
        switch (previousComponent, nextComponent)
        {
            case (Node, Condition):
                return "[(";
            case (Connector, Condition):
                return "(";
            default:
                throw new InvalidOperationException(
                    "A grouped condition start must be preceded by a node or a connector and followed by a condition.");
        }
    }
}
