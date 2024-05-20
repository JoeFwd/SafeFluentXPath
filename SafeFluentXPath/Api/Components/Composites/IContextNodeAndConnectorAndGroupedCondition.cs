namespace SafeFluentXPath.Api.Components.Composites;

public interface IContextNodeAndConnectorAndGroupedCondition :
    IContextNode,
    IConnector<IConditionStartGroupAndContextNode>,
    IEnd
{
}
