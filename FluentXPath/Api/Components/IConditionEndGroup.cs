using FluentXPath.Api.Components.Composites;

namespace FluentXPath.Api.Components;

public interface IConditionEndGroup
{
    /**
     * <summary>
     * Closes the XPath condition group.
     * </summary>
     * <returns>The builder allowing to add XPath nodes and connectors</returns>
     */
    INodeAndConnectorAndGroupedCondition EndConditionGroup();
}
