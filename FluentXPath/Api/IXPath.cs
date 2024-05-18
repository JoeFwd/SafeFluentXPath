using FluentXPath.Api.Components;
using FluentXPath.Api.Components.Composites;

namespace FluentXPath.Api;

public interface IXPath : INode,
    IConnector<ICondition<IConnectorAndConditionEndGroup>>, IConditionStartGroup, IConditionEndGroup,
    ICondition<INodeAndConnector>, ICondition<IConnectorAndConditionEndGroup>,
    IConnector<ICondition<IConnectorAndConditionStartGroup>>
{
}
