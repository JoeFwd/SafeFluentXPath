namespace SafeFluentXPath.Abstraction.Api.Components.Composites;

public interface IConnectorAndConditionStartGroup : IConnector<ICondition<IConnectorAndConditionStartGroup>>,
    IConditionStartGroup, IEnd
{
}
