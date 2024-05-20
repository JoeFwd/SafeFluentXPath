using SafeFluentXPath.Api.Components;
using SafeFluentXPath.Api.Components.Composites;

namespace SafeFluentXPath.Implementation.Api.Components.Composites;

internal class ConditionStartGroupAndNode : IConditionStartGroupAndNode
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

    INodeAndConnectorAndGroupedCondition ICondition<INodeAndConnectorAndGroupedCondition>.HasName(string nodeName)
    {
        return _conditionAllowingNodeAndConnector.HasName(nodeName);
    }

    INodeAndConnectorAndGroupedCondition ICondition<INodeAndConnectorAndGroupedCondition>.ChildElementsAtSameLevel(params string[] elementNames)
    {
        return _conditionAllowingNodeAndConnector.ChildElementsAtSameLevel(elementNames);
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
