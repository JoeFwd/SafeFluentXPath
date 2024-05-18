﻿using XPathBuilder.Builders.Core;
using XpathBuilder.Components;
using XpathBuilder.Api;
using XpathBuilder.Api.Composites;

namespace XPathBuilder.Builders.Components;

public class ConditionGroupBuilder : IConditionStartGroup, IConditionEndGroup
{
    private readonly XPathProcessor _xPathProcessor;

    private ICondition<IConnectorAndConditionEndGroup> _conditionBuilder;

    private INodeAndConnectorAllowingGroupedCondition _nodeAndConnector;

    internal void Init(
        ICondition<IConnectorAndConditionEndGroup> conditionBuilder,
        INodeAndConnectorAllowingGroupedCondition nodeAndConnector)
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
        _xPathProcessor.AddXPathComponent(new GroupedConditionStart());
        return _conditionBuilder;
    }

    public INodeAndConnectorAllowingGroupedCondition EndConditionGroup()
    {
        _xPathProcessor.AddXPathComponent(new GroupedConditionEnd());
        return _nodeAndConnector;
    }
}
