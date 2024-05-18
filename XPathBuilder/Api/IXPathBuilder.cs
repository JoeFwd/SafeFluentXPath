using XpathBuilder.Api.Composites;

namespace XpathBuilder.Api;

public interface IXPathBuilder : INode,
    IConnector<ICondition<IConnectorAndConditionEndGroup>>, IConditionStartGroup, IConditionEndGroup,
    ICondition<INodeAndConnector>, ICondition<IConnectorAndConditionEndGroup>,
    IConnector<ICondition<IConnectorAndConditionStartGroup>>
{
    
}