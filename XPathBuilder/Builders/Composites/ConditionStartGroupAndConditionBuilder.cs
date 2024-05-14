using XpathBuilder.ReturnLogic;
using XpathBuilder.ReturnLogic.Composites;

namespace XpathBuilder.Builders.Composites;

public class ConditionStartGroupAndConditionBuilder : IConditionStartGroupAndCondition
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

    public IConnector<IConditionStartGroupAndCondition> NodeHasName(string nodeName)
    {
        return _conditionAllowingConnectorWithGroupedCondition.NodeHasName(nodeName);
    }

    public IConnector<IConditionStartGroupAndCondition> ChildNodesAtSameLevel(params string[] elementNames)
    {
        return _conditionAllowingConnectorWithGroupedCondition.ChildNodesAtSameLevel(elementNames);
    }

    public ICondition<IConnectorAndConditionEndGroup> StartGroupCondition()
    {
        return _conditionStartGroup.StartGroupCondition();
    }
}
