namespace SafeFluentXPath.Api.Components.Composites;

public interface IConnectorAndConditionStartGroup : IConnector<ICondition<IConnectorAndConditionStartGroup>>,
    IConditionStartGroup, IEnd
{
}
