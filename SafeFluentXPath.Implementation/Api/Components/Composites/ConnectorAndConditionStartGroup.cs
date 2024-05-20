using SafeFluentXPath.Abstraction.Api.Components;
using SafeFluentXPath.Abstraction.Api.Components.Composites;

namespace SafeFluentXPath.Implementation.Api.Components.Composites;

internal class ConnectorAndConditionStartGroup : IConnectorAndConditionStartGroup
{
    private IConnector<ICondition<IConnectorAndConditionStartGroup>> _connector;

    private IConditionStartGroup _conditionStartGroup;

    private IEnd _end;

    internal void Init(
        IConnector<ICondition<IConnectorAndConditionStartGroup>> connector,
        IConditionStartGroup conditionEndGroup,
        IEnd end)
    {
        _connector = connector;
        _conditionStartGroup = conditionEndGroup;
        _end = end;
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

    public string Build()
    {
        return _end.Build();
    }
}
