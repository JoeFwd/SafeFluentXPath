namespace XpathBuilder.ReturnLogic.Composites;

public interface IConnectorAndConditionEndGroup : IConnector<ICondition<IConnectorAndConditionEndGroup>>,
    IConditionEndGroup
{
}
