using XpathBuilder.Api.Composites;

namespace XpathBuilder.Api;

public interface IConditionStartGroup
{
    /**
     * Start a new condition group.
     * 
     */
    ICondition<IConnectorAndConditionEndGroup> StartGroupCondition();
}
