using XpathBuilder.ReturnLogic;
using XpathBuilder.ReturnLogic.Composites;

namespace XpathBuilder.Builders.Composites;

public class ConditionStartGroupAndConditionAllowingNodeBuilder : IConditionStartGroupAndConditionAllowingNode
{
    private ICondition<INodeAndConnectorAllowingGroupedCondition> _conditionAllowingNodeAndConnector;
    private IConditionStartGroup _conditionStartGroup;

    public void Init(
        ICondition<INodeAndConnectorAllowingGroupedCondition> conditionAllowingNodeAndConnector,
        IConditionStartGroup conditionStartGroup)
    {
        _conditionAllowingNodeAndConnector = conditionAllowingNodeAndConnector;
        _conditionStartGroup = conditionStartGroup;
    }
    
    INodeAndConnectorAllowingGroupedCondition ICondition<INodeAndConnectorAllowingGroupedCondition>.AtPosition(int position)
    {
        return _conditionAllowingNodeAndConnector.AtPosition(position);
    }

    INodeAndConnectorAllowingGroupedCondition ICondition<INodeAndConnectorAllowingGroupedCondition>.NodeHasName(string nodeName)
    {
        return _conditionAllowingNodeAndConnector.NodeHasName(nodeName);
    }

    INodeAndConnectorAllowingGroupedCondition ICondition<INodeAndConnectorAllowingGroupedCondition>.ChildNodesAtSameLevel(params string[] elementNames)
    {
        return _conditionAllowingNodeAndConnector.ChildNodesAtSameLevel(elementNames);
    }

    INodeAndConnectorAllowingGroupedCondition ICondition<INodeAndConnectorAllowingGroupedCondition>.WithAttribute(string attributeName, string attributeValue)
    {
        return _conditionAllowingNodeAndConnector.WithAttribute(attributeName, attributeValue);
    }

    public ICondition<IConnectorAndConditionEndGroup> StartGroupCondition()
    {
        return _conditionStartGroup.StartGroupCondition();
    }
}
