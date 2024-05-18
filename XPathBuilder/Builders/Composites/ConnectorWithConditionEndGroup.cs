using XpathBuilder.Api;
using XpathBuilder.Api.Composites;

namespace XpathBuilder.Builders.Composites;

public class ConnectorWithConditionEndGroup : IConnectorWithConditionEndGroup
{
    private IConnector<ICondition<IConnectorWithConditionEndGroup>> _connector;

    private IConditionEndGroup _conditionEndGroup;

    internal void Init(IConnector<ICondition<IConnectorWithConditionEndGroup>> connector, IConditionEndGroup conditionEndGroup)
    {
        _connector = connector;
        _conditionEndGroup = conditionEndGroup;
    }
    
    public ICondition<IConnectorWithConditionEndGroup> And()
    {
        return _connector.And();
    }

    public ICondition<IConnectorWithConditionEndGroup> Or()
    {
        return _connector.Or();
    }

    public INodeAndConnectorWithGroupedCondition EndConditionGroup()
    {
        return _conditionEndGroup.EndConditionGroup();
    }
}
