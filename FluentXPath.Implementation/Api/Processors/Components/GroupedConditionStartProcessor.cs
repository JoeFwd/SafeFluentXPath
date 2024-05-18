namespace FluentXPath.Implementation.Api.Processors.Components;

public class GroupedConditionStartProcessor : IXPathComponentProcessor
{
    public string Process(IXPathComponentProcessor? previousComponent, IXPathComponentProcessor? nextComponent)
    {
        switch (previousComponent, nextComponent)
        {
            case (NodeProcessor, ConditionProcessor):
                return "[(";
            case (ConnectorProcessor, ConditionProcessor):
                return "(";
            default:
                throw new InvalidOperationException(
                    "A grouped condition start must be preceded by a node or a connector and followed by a condition.");
        }
    }
}
