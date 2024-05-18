using XpathBuilder.Api.Composites;

namespace XpathBuilder.Api;

public interface IConditionStartGroup
{
    /**
     * <summary>
     * Starts a new condition group.
     * </summary>
     * <returns>The builder for adding conditions and connectors within the group.</returns>
     */
    ICondition<IConnectorAndConditionEndGroup> StartGroupCondition();
}
