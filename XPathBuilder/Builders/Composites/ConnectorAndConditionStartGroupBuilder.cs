using XpathBuilder.ReturnLogic;
using XpathBuilder.ReturnLogic.Composites;

namespace XpathBuilder.Builders.Composites;

public class ConnectorAndConditionStartGroupBuilder : IConnectorAndConditionStartGroup
{
    private IConnector<IConnectorAndConditionStartGroup> _connector;

    private IConditionStartGroup _conditionStartGroup;

    internal void Init(IConnector<IConnectorAndConditionStartGroup> connector, IConditionStartGroup conditionEndGroup)
    {
        _connector = connector;
        _conditionStartGroup = conditionEndGroup;
    }

    public ICondition<IConnectorAndConditionStartGroup> And()
    {
        return _connector.And();
    }

    public ICondition<IConnectorAndConditionStartGroup> Or()
    {
        return _connector.Or();
    }

    public ICondition<IConnectorAndConditionEndGroup> StartGroupCondition()
    {
        return _conditionStartGroup.StartGroupCondition();
    }
}
