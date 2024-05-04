namespace XpathBuilder.Components;

public class GroupedConditionEnd : XPathComponent
{
    public string Process(XPathComponent? previousComponent, XPathComponent? nextComponent)
    {
        switch (previousComponent, nextComponent)
        {
            case (Condition, Node or null):
                return ")]";
            case (Condition, Connector):
                return ")";
            default:
                throw new InvalidOperationException(
                    "A grouped condition end must be preceded by a condition and followed by a node " +
                    "or a connector or does not have to be followed by anything.");
        }
    }
}
