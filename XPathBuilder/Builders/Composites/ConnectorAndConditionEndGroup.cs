using XpathBuilder.Api;
using XpathBuilder.Api.Composites;

namespace XpathBuilder.Builders.Composites;

public class ConnectorAndConditionEndGroup : IConnectorAndConditionEndGroup
{
    private IConnector<ICondition<IConnectorAndConditionEndGroup>> _connector;

    private IConditionEndGroup _conditionEndGroup;

    internal void Init(IConnector<ICondition<IConnectorAndConditionEndGroup>> connector, IConditionEndGroup conditionEndGroup)
    {
        _connector = connector;
        _conditionEndGroup = conditionEndGroup;
    }
    
    public ICondition<IConnectorAndConditionEndGroup> And()
    {
        return _connector.And();
    }

    public ICondition<IConnectorAndConditionEndGroup> Or()
    {
        return _connector.Or();
    }

    public INodeAndConnectorAndGroupedCondition EndConditionGroup()
    {
        return _conditionEndGroup.EndConditionGroup();
    }
}
