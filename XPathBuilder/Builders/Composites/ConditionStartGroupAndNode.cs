using XpathBuilder.Api;
using XpathBuilder.Api.Composites;

namespace XpathBuilder.Builders.Composites;

public class ConditionStartGroupAndNode : IConditionStartGroupAndNode
{
    private ICondition<INodeAndConnectorAndGroupedCondition> _conditionAllowingNodeAndConnector;
    private IConditionStartGroup _conditionStartGroup;

    public void Init(
        ICondition<INodeAndConnectorAndGroupedCondition> conditionAllowingNodeAndConnector,
        IConditionStartGroup conditionStartGroup)
    {
        _conditionAllowingNodeAndConnector = conditionAllowingNodeAndConnector;
        _conditionStartGroup = conditionStartGroup;
    }
    
    INodeAndConnectorAndGroupedCondition ICondition<INodeAndConnectorAndGroupedCondition>.AtPosition(int position)
    {
        return _conditionAllowingNodeAndConnector.AtPosition(position);
    }

    INodeAndConnectorAndGroupedCondition ICondition<INodeAndConnectorAndGroupedCondition>.NodeHasName(string nodeName)
    {
        return _conditionAllowingNodeAndConnector.NodeHasName(nodeName);
    }

    INodeAndConnectorAndGroupedCondition ICondition<INodeAndConnectorAndGroupedCondition>.ChildNodesAtSameLevel(params string[] elementNames)
    {
        return _conditionAllowingNodeAndConnector.ChildNodesAtSameLevel(elementNames);
    }

    INodeAndConnectorAndGroupedCondition ICondition<INodeAndConnectorAndGroupedCondition>.WithAttribute(string attributeName, string attributeValue)
    {
        return _conditionAllowingNodeAndConnector.WithAttribute(attributeName, attributeValue);
    }

    public ICondition<IConnectorAndConditionEndGroup> StartGroupCondition()
    {
        return _conditionStartGroup.StartGroupCondition();
    }
}
