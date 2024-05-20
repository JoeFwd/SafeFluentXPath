using SafeFluentXPath.Api.Components;
using SafeFluentXPath.Api.Components.Composites;

namespace SafeFluentXPath.Api;

/// <summary>
/// Represents a base interface for XPath queries, which allows chaining with various nodes, conditions, and connectors.
/// </summary>
public interface IXPath : INode,
    IConnector<ICondition<IConnectorAndConditionEndGroup>>, IConditionStartGroup, IConditionEndGroup,
    ICondition<INodeAndConnector>, ICondition<IConnectorAndConditionEndGroup>,
    IConnector<ICondition<IConnectorAndConditionStartGroup>>
{
}
