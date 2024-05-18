namespace FluentXPath.Api.Components.Composites;

public interface IConnectorAndConditionEndGroup : IConnector<ICondition<IConnectorAndConditionEndGroup>>,
    IConditionEndGroup
{
}
