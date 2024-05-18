using FluentXPath.Api.Components;
using FluentXPath.Api.Components.Composites;
using FluentXPath.Implementation.Api.Processors;
using FluentXPath.Implementation.Api.Processors.Components;

namespace FluentXPath.Implementation.Api.Components;

public class ConditionGroup(XPathProcessor xPathProcessor) : IConditionStartGroup, IConditionEndGroup
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
