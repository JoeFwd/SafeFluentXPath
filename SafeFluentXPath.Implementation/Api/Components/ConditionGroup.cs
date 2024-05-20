using SafeFluentXPath.Api.Components;
using SafeFluentXPath.Api.Components.Composites;
using SafeFluentXPath.Implementation.Api.Processors;
using SafeFluentXPath.Implementation.Api.Processors.Components;

namespace SafeFluentXPath.Implementation.Api.Components;

internal class ConditionGroup(XPathProcessor xPathProcessor) : IConditionStartGroup, IConditionEndGroup
{
    private ICondition<IConnectorAndConditionEndGroup> _conditionBuilder;

    private INodeAndConnectorAndGroupedCondition _nodeAndConnector;

    internal void Init(
        ICondition<IConnectorAndConditionEndGroup> conditionBuilder,
        INodeAndConnectorAndGroupedCondition nodeAndConnector)
    {
        _conditionBuilder = conditionBuilder;
        _nodeAndConnector = nodeAndConnector;
    }

    public ICondition<IConnectorAndConditionEndGroup> StartGroupCondition()
    {
        xPathProcessor.AddXPathComponent(new GroupedConditionStartProcessor());
        return _conditionBuilder;
    }

    public INodeAndConnectorAndGroupedCondition EndConditionGroup()
    {
        xPathProcessor.AddXPathComponent(new GroupedConditionEndProcessor());
        return _nodeAndConnector;
    }
}
