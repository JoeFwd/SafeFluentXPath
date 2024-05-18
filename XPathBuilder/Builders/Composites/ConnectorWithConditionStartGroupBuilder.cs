using XpathBuilder.Api;
using XpathBuilder.Api.Composites;

namespace XpathBuilder.Builders.Composites;

public class ConnectorWithConditionStartGroupBuilder : IConnectorWithConditionStartGroup
{
    private IConnector<ICondition<IConnectorWithConditionStartGroup>> _connector;

    private IConditionStartGroup _conditionStartGroup;

    internal void Init(IConnector<ICondition<IConnectorWithConditionStartGroup>> connector, IConditionStartGroup conditionEndGroup)
    {
        _connector = connector;
        _conditionStartGroup = conditionEndGroup;
    }

    public ICondition<IConnectorWithConditionStartGroup> And()
    {
        return _connector.And();
    }

    public ICondition<IConnectorWithConditionStartGroup> Or()
    {
        return _connector.Or();
    }

    public ICondition<IConnectorWithConditionEndGroup> StartGroupCondition()
    {
        return _conditionStartGroup.StartGroupCondition();
    }
}
