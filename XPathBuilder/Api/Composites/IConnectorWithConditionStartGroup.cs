namespace XpathBuilder.Api.Composites;

public interface IConnectorWithConditionStartGroup : IConnector<ICondition<IConnectorWithConditionStartGroup>>,
    IConditionStartGroup
{
}
