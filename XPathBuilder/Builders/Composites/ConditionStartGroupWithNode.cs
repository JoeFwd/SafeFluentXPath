using XpathBuilder.Api;
using XpathBuilder.Api.Composites;

namespace XpathBuilder.Builders.Composites;

public class ConditionStartGroupWithNode : IConditionStartGroupWithNode
{
    private ICondition<INodeAndConnectorWithGroupedCondition> _conditionAllowingNodeAndConnector;
    private IConditionStartGroup _conditionStartGroup;

    public void Init(
        ICondition<INodeAndConnectorWithGroupedCondition> conditionAllowingNodeAndConnector,
        IConditionStartGroup conditionStartGroup)
    {
        _conditionAllowingNodeAndConnector = conditionAllowingNodeAndConnector;
        _conditionStartGroup = conditionStartGroup;
    }
    
    INodeAndConnectorWithGroupedCondition ICondition<INodeAndConnectorWithGroupedCondition>.AtPosition(int position)
    {
        return _conditionAllowingNodeAndConnector.AtPosition(position);
    }

    INodeAndConnectorWithGroupedCondition ICondition<INodeAndConnectorWithGroupedCondition>.NodeHasName(string nodeName)
    {
        return _conditionAllowingNodeAndConnector.NodeHasName(nodeName);
    }

    INodeAndConnectorWithGroupedCondition ICondition<INodeAndConnectorWithGroupedCondition>.ChildNodesAtSameLevel(params string[] elementNames)
    {
        return _conditionAllowingNodeAndConnector.ChildNodesAtSameLevel(elementNames);
    }

    INodeAndConnectorWithGroupedCondition ICondition<INodeAndConnectorWithGroupedCondition>.WithAttribute(string attributeName, string attributeValue)
    {
        return _conditionAllowingNodeAndConnector.WithAttribute(attributeName, attributeValue);
    }

    public ICondition<IConnectorWithConditionEndGroup> StartGroupCondition()
    {
        return _conditionStartGroup.StartGroupCondition();
    }
}
