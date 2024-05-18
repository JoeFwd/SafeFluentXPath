namespace XpathBuilder.Api.Composites;

public interface IConnectorAndConditionStartGroup : IConnector<ICondition<IConnectorAndConditionStartGroup>>,
    IConditionStartGroup
{
}
