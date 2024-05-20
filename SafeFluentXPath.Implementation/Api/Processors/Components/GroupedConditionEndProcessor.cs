namespace SafeFluentXPath.Implementation.Api.Processors.Components;

internal class GroupedConditionEndProcessor : IXPathComponentProcessor
{
    public string Process(IXPathComponentProcessor? previousComponent, IXPathComponentProcessor? nextComponent)
    {
        switch (previousComponent, nextComponent)
        {
            case (ConditionProcessor, NodeProcessor or null):
                return ")]";
            case (ConditionProcessor, ConnectorProcessor):
                return ")";
            default:
                throw new InvalidOperationException(
                    "A grouped condition end must be preceded by a condition and followed by a node " +
                    "or a connector or does not have to be followed by anything.");
        }
    }
}
