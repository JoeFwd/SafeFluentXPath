using SafeFluentXPath.Api.Components.Composites;

namespace SafeFluentXPath.Api.Components;

/// <summary>
/// Represents an interface allowing the end of of condition group
/// <example>
/// Consider the following example where we want to select all House elements which have a valid address in the city of Paris:
/// 
/// ./House[(@address='' or @address='N/A') and @city='Paris']
///
/// With parentheses, we explicitly state that the OR operation should be performed first.
/// Without parentheses, the logical AND operation is applied first, altering the meaning of the query
/// </example>
/// </summary>
public interface IConditionEndGroup
{
    /**
     * <summary>
     * Closes the XPath condition group.
     * </summary>
     * <returns>The builder allowing to add XPath nodes and connectors</returns>
     */
    IContextNodeAndConnectorAndGroupedCondition EndConditionGroup();
}
