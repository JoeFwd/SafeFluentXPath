namespace XpathBuilder.Api.Composites;

public interface IConnectorWithConditionEndGroup : IConnector<ICondition<IConnectorWithConditionEndGroup>>,
    IConditionEndGroup
{
}
