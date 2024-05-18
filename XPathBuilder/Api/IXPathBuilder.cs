using XpathBuilder.Api.Composites;

namespace XpathBuilder.Api;

public interface IXPathBuilder : INode,
    ICondition<INodeAndConnector>, ICondition<IConnectorAndConditionEndGroup>,
    IConnector<ICondition<IConnectorAndConditionStartGroup>>, IConnectorAndConditionEndGroup, IConditionStartGroupAndConditionAllowingNode
{
    
}