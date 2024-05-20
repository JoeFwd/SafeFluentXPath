namespace SafeFluentXPath.Implementation.Api.Processors.Components;

internal class ConditionProcessor(string condition) : IXPathComponentProcessor
{
    public string Process(IXPathComponentProcessor? previousComponent, IXPathComponentProcessor? nextComponent)
    {
        switch (previousComponent, nextComponent)
        {
            case (null, _):
                throw new InvalidOperationException("A condition must be preceded by a node or an operator");
            case (NodeProcessor, null or NodeProcessor):
                return $"[{condition}]";
            case (NodeProcessor, ConnectorProcessor):
                return $"[{condition}";
            case (ConnectorProcessor, NodeProcessor or null):
                return $"{condition}]";
            case (GroupedConditionStartProcessor, _):
                return $"{condition}";
            case (_, GroupedConditionEndProcessor):
                return $"{condition}";
            default:
                return condition;
        }
    }
}
