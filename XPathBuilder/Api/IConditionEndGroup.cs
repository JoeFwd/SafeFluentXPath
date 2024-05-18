using XpathBuilder.Api.Composites;

namespace XpathBuilder.Api;

public interface IConditionEndGroup
{
    /**
     * <summary>
     * This method closes the xpath condition group.
     * </summary>
     * <returns>The builder allowing to add xpath nodes and xpath connectors</returns>
     */
    INodeAndConnectorAllowingGroupedCondition EndConditionGroup();
}
