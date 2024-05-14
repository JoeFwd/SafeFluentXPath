using XpathBuilder.ReturnLogic.Composites;

namespace XpathBuilder.ReturnLogic;

public interface IXPathBuilder : INode,
    ICondition<INodeAndConnector>, ICondition<IConnectorAndConditionEndGroup>,
    IConnector<ICondition<IConnectorAndConditionStartGroup>>, IConnectorAndConditionEndGroup, IConditionStartGroupAndConditionAllowingNode
{
    
}