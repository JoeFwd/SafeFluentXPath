﻿using SafeFluentXPath.Abstraction.Api.Components;
using SafeFluentXPath.Abstraction.Api.Components.Composites;

namespace SafeFluentXPath.Implementation.Api.Components.Composites;

internal class ConnectorAndConditionEndGroup : IConnectorAndConditionEndGroup
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

    public IContextNodeAndConnectorAndGroupedCondition EndConditionGroup()
    {
        return _conditionEndGroup.EndConditionGroup();
    }
}
