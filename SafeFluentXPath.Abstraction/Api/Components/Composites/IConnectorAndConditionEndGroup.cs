namespace SafeFluentXPath.Abstraction.Api.Components.Composites;

public interface IConnectorAndConditionEndGroup : IConnector<ICondition<IConnectorAndConditionEndGroup>>,
    IConditionEndGroup
{
}
