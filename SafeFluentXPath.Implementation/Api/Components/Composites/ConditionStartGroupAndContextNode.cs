using SafeFluentXPath.Abstraction.Api.Components;
using SafeFluentXPath.Abstraction.Api.Components.Composites;

namespace SafeFluentXPath.Implementation.Api.Components.Composites;

internal class ConditionStartGroupAndContextNode : IConditionStartGroupAndContextNode
{
    private ICondition<IContextNodeAndConnectorAndGroupedCondition> _conditionAllowingNodeAndConnector;
    private IConditionStartGroup _conditionStartGroup;

    public void Init(
        ICondition<IContextNodeAndConnectorAndGroupedCondition> conditionAllowingNodeAndConnector,
        IConditionStartGroup conditionStartGroup)
    {
        _conditionAllowingNodeAndConnector = conditionAllowingNodeAndConnector;
        _conditionStartGroup = conditionStartGroup;
    }
    
    IContextNodeAndConnectorAndGroupedCondition ICondition<IContextNodeAndConnectorAndGroupedCondition>.AtPosition(int position)
    {
        return _conditionAllowingNodeAndConnector.AtPosition(position);
    }

    IContextNodeAndConnectorAndGroupedCondition ICondition<IContextNodeAndConnectorAndGroupedCondition>.HasName(string elementName)
    {
        return _conditionAllowingNodeAndConnector.HasName(elementName);
    }

    IContextNodeAndConnectorAndGroupedCondition ICondition<IContextNodeAndConnectorAndGroupedCondition>.ChildElementsAtSameLevel(params string[] elementNames)
    {
        return _conditionAllowingNodeAndConnector.ChildElementsAtSameLevel(elementNames);
    }

    IContextNodeAndConnectorAndGroupedCondition ICondition<IContextNodeAndConnectorAndGroupedCondition>.WithAttribute(string attributeName, string attributeValue)
    {
        return _conditionAllowingNodeAndConnector.WithAttribute(attributeName, attributeValue);
    }

    public ICondition<IConnectorAndConditionEndGroup> StartGroupCondition()
    {
        return _conditionStartGroup.StartGroupCondition();
    }
}
