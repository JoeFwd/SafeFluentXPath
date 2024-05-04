namespace XpathBuilder.ReturnLogic.Composites;

public interface IConnectorAndConditionStartGroup : IConnector<ICondition<IConnectorAndConditionStartGroup>>,
    IConditionStartGroup
{
}
