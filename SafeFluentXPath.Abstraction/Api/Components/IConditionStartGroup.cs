using SafeFluentXPath.Abstraction.Api.Components.Composites;

namespace SafeFluentXPath.Abstraction.Api.Components;

/// <summary>
/// Represents an interface enabling the grouping of multiple conditions
/// <example>
/// Consider the following example where we want to select all House elements which have a valid address in the city of Paris:
/// 
/// ./House[(@address='' or @address='N/A') and @city='Paris']
///
/// With parentheses, we explicitly state that the OR operation should be performed first.
/// Without parentheses, the logical AND operation is applied first, altering the meaning of the query
/// </example>
/// </summary>
public interface IConditionStartGroup
{
    /// <summary>
    /// Starts a new condition group.
    /// </summary>
    /// <returns>The builder for adding conditions and connectors within the group.</returns>
    ICondition<IConnectorAndConditionEndGroup> StartGroupCondition();
}
