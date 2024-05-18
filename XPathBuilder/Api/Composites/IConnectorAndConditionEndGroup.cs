namespace XpathBuilder.Api.Composites;

public interface IConnectorAndConditionEndGroup : IConnector<ICondition<IConnectorAndConditionEndGroup>>,
    IConditionEndGroup
{
}
