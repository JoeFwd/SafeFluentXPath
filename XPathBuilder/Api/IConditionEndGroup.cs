using XpathBuilder.Api.Composites;

namespace XpathBuilder.Api;

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
