using XpathBuilder.Components;
using XpathBuilder.ReturnLogic;
using XpathBuilder.ReturnLogic.Composites;

namespace XpathBuilder.Builders;

public class ConditionGroupBuilder : IConditionStartGroup, IConditionEndGroup
{
    private readonly XPathProcessor _xPathProcessor;

    private ICondition<IConnectorAndConditionEndGroup> _conditionBuilder;

    private INodeAndConnector _nodeAndConnector;

    internal void Init(ICondition<IConnectorAndConditionEndGroup> conditionBuilder, INodeAndConnector nodeAndConnector)
    {
        _conditionBuilder = conditionBuilder;
        _nodeAndConnector = nodeAndConnector;
    }

    public ConditionGroupBuilder(XPathProcessor xPathProcessor)
    {
        _xPathProcessor = xPathProcessor;
    }

    public ICondition<IConnectorAndConditionEndGroup> StartGroupCondition()
    {
        _xPathProcessor.AddXPathComponent(new GroupedCondition());
        return _conditionBuilder;
    }

    public INodeAndConnector EndConditionGroup()
    {
        _xPathProcessor.AddXPathComponent(new GroupedCondition());
        return _nodeAndConnector;
    }
}
