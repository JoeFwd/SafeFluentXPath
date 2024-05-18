namespace FluentXPath.Api.Components.Composites;

public interface IConnectorAndConditionStartGroup : IConnector<ICondition<IConnectorAndConditionStartGroup>>,
    IConditionStartGroup
{
}
