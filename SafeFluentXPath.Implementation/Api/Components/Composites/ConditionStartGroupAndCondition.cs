using SafeFluentXPath.Api.Components;
using SafeFluentXPath.Api.Components.Composites;

namespace SafeFluentXPath.Implementation.Api.Components.Composites;

internal class ConditionStartGroupAndCondition : IConditionStartGroupAndCondition
{
    private ICondition<IConnector<IConditionStartGroupAndCondition>> _conditionAllowingConnectorWithGroupedCondition;
    private IConditionStartGroup _conditionStartGroup;

    public void Init(
        ICondition<IConnector<IConditionStartGroupAndCondition>> conditionAllowingConnectorWithGroupedCondition,
        IConditionStartGroup conditionStartGroup)
    {
        _conditionAllowingConnectorWithGroupedCondition = conditionAllowingConnectorWithGroupedCondition;
        _conditionStartGroup = conditionStartGroup;
    }

    public IConnector<IConditionStartGroupAndCondition> WithAttribute(string attributeName, string attributeValue)
    {
        return _conditionAllowingConnectorWithGroupedCondition.WithAttribute(attributeName, attributeValue);
    }

    public IConnector<IConditionStartGroupAndCondition> AtPosition(int position)
    {
        return _conditionAllowingConnectorWithGroupedCondition.AtPosition(position);
    }

    public IConnector<IConditionStartGroupAndCondition> HasName(string nodeName)
    {
        return _conditionAllowingConnectorWithGroupedCondition.HasName(nodeName);
    }

    public IConnector<IConditionStartGroupAndCondition> ChildElementsAtSameLevel(params string[] elementNames)
    {
        return _conditionAllowingConnectorWithGroupedCondition.ChildElementsAtSameLevel(elementNames);
    }

    public ICondition<IConnectorAndConditionEndGroup> StartGroupCondition()
    {
        return _conditionStartGroup.StartGroupCondition();
    }
}
