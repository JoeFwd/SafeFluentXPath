namespace SafeFluentXPath.Abstraction.Api.Components.Composites;

public interface IContextNodeAndConnectorAndGroupedCondition :
    IContextNode,
    IConnector<IConditionStartGroupAndContextNode>,
    IEnd
{
}
