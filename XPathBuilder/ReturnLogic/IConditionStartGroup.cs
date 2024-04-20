using XpathBuilder.ReturnLogic.Composites;

namespace XpathBuilder.ReturnLogic;

public interface IConditionStartGroup
{
    /**
     * Start a new condition group.
     * 
     */
    ICondition<IConnectorAndConditionEndGroup> StartGroupCondition();
}
