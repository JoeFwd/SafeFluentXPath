using XpathBuilder.Api;
using XpathBuilder.Api.Composites;

namespace XpathBuilder.Builders.Composites;

public class ConditionStartGroupWithCondition : IConditionStartGroupWithCondition
{
    private ICondition<IConnector<IConditionStartGroupWithCondition>> _conditionAllowingConnectorWithGroupedCondition;
    private IConditionStartGroup _conditionStartGroup;

    public void Init(
        ICondition<IConnector<IConditionStartGroupWithCondition>> conditionAllowingConnectorWithGroupedCondition,
        IConditionStartGroup conditionStartGroup)
    {
        _conditionAllowingConnectorWithGroupedCondition = conditionAllowingConnectorWithGroupedCondition;
        _conditionStartGroup = conditionStartGroup;
    }

    public IConnector<IConditionStartGroupWithCondition> WithAttribute(string attributeName, string attributeValue)
    {
        return _conditionAllowingConnectorWithGroupedCondition.WithAttribute(attributeName, attributeValue);
    }

    public IConnector<IConditionStartGroupWithCondition> AtPosition(int position)
    {
        return _conditionAllowingConnectorWithGroupedCondition.AtPosition(position);
    }

    public IConnector<IConditionStartGroupWithCondition> NodeHasName(string nodeName)
    {
        return _conditionAllowingConnectorWithGroupedCondition.NodeHasName(nodeName);
    }

    public IConnector<IConditionStartGroupWithCondition> ChildNodesAtSameLevel(params string[] elementNames)
    {
        return _conditionAllowingConnectorWithGroupedCondition.ChildNodesAtSameLevel(elementNames);
    }

    public ICondition<IConnectorWithConditionEndGroup> StartGroupCondition()
    {
        return _conditionStartGroup.StartGroupCondition();
    }
}
