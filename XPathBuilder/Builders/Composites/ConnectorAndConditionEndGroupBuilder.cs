using XpathBuilder.ReturnLogic;
using XpathBuilder.ReturnLogic.Composites;

namespace XpathBuilder.Builders.Composites;

public class ConnectorAndConditionEndGroupBuilder : IConnectorAndConditionEndGroup
{
    private IConnector<IConnectorAndConditionEndGroup> _connector;

    private IConditionEndGroup _conditionEndGroup;

    internal void Init(IConnector<IConnectorAndConditionEndGroup> connector, IConditionEndGroup conditionEndGroup)
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

    public INodeAndConnector EndConditionGroup()
    {
        return _conditionEndGroup.EndConditionGroup();
    }
}
