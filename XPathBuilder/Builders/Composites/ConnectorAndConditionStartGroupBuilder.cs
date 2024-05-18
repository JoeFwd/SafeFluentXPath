using XpathBuilder.Api;
using XpathBuilder.Api.Composites;

namespace XpathBuilder.Builders.Composites;

public class ConnectorAndConditionStartGroupBuilder : IConnectorAndConditionStartGroup
{
    private IConnector<ICondition<IConnectorAndConditionStartGroup>> _connector;

    private IConditionStartGroup _conditionStartGroup;

    internal void Init(IConnector<ICondition<IConnectorAndConditionStartGroup>> connector, IConditionStartGroup conditionEndGroup)
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
