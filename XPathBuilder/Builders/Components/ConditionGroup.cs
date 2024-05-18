using XPathBuilder.Builders.Core;
using XpathBuilder.Components;
using XpathBuilder.Api;
using XpathBuilder.Api.Composites;

namespace XPathBuilder.Builders.Components;

public class ConditionGroup : IConditionStartGroup, IConditionEndGroup
{
    private readonly XPathProcessor _xPathProcessor;

    private ICondition<IConnectorAndConditionEndGroup> _conditionBuilder;

    private INodeAndConnectorAndGroupedCondition _nodeAndConnector;

    internal void Init(
        ICondition<IConnectorAndConditionEndGroup> conditionBuilder,
        INodeAndConnectorAndGroupedCondition nodeAndConnector)
    {
        _conditionBuilder = conditionBuilder;
        _nodeAndConnector = nodeAndConnector;
    }

    public ConditionGroup(XPathProcessor xPathProcessor)
    {
        _xPathProcessor = xPathProcessor;
    }

    public ICondition<IConnectorAndConditionEndGroup> StartGroupCondition()
    {
        _xPathProcessor.AddXPathComponent(new GroupedConditionStart());
        return _conditionBuilder;
    }

    public INodeAndConnectorAndGroupedCondition EndConditionGroup()
    {
        _xPathProcessor.AddXPathComponent(new GroupedConditionEnd());
        return _nodeAndConnector;
    }
}
