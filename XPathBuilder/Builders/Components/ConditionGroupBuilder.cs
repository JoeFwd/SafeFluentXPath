using XPathBuilder.Builders.Core;
using XpathBuilder.Components;
using XpathBuilder.Api;
using XpathBuilder.Api.Composites;

namespace XPathBuilder.Builders.Components;

public class ConditionGroupBuilder : IConditionStartGroup, IConditionEndGroup
{
    private readonly XPathProcessor _xPathProcessor;

    private ICondition<IConnectorWithConditionEndGroup> _conditionBuilder;

    private INodeAndConnectorWithGroupedCondition _nodeAndConnector;

    internal void Init(
        ICondition<IConnectorWithConditionEndGroup> conditionBuilder,
        INodeAndConnectorWithGroupedCondition nodeAndConnector)
    {
        _conditionBuilder = conditionBuilder;
        _nodeAndConnector = nodeAndConnector;
    }

    public ConditionGroupBuilder(XPathProcessor xPathProcessor)
    {
        _xPathProcessor = xPathProcessor;
    }

    public ICondition<IConnectorWithConditionEndGroup> StartGroupCondition()
    {
        _xPathProcessor.AddXPathComponent(new GroupedConditionStart());
        return _conditionBuilder;
    }

    public INodeAndConnectorWithGroupedCondition EndConditionGroup()
    {
        _xPathProcessor.AddXPathComponent(new GroupedConditionEnd());
        return _nodeAndConnector;
    }
}
