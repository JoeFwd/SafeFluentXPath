using SafeFluentXPath.Abstraction.Api.Components;
using SafeFluentXPath.Abstraction.Api.Components.Composites;
using SafeFluentXPath.Implementation.Api.Processors;
using SafeFluentXPath.Implementation.Api.Processors.Components;

namespace SafeFluentXPath.Implementation.Api.Components;

internal class ConditionGroup(XPathProcessor xPathProcessor) : IConditionStartGroup, IConditionEndGroup
{
    private ICondition<IConnectorAndConditionEndGroup> _conditionBuilder;

    private IContextNodeAndConnectorAndGroupedCondition _contextNodeAndConnector;

    internal void Init(
        ICondition<IConnectorAndConditionEndGroup> conditionBuilder,
        IContextNodeAndConnectorAndGroupedCondition contextNodeAndConnector)
    {
        _conditionBuilder = conditionBuilder;
        _contextNodeAndConnector = contextNodeAndConnector;
    }

    public ICondition<IConnectorAndConditionEndGroup> StartGroupCondition()
    {
        xPathProcessor.AddXPathComponent(new GroupedConditionStartProcessor());
        return _conditionBuilder;
    }

    public IContextNodeAndConnectorAndGroupedCondition EndConditionGroup()
    {
        xPathProcessor.AddXPathComponent(new GroupedConditionEndProcessor());
        return _contextNodeAndConnector;
    }
}
