using XpathBuilder.Api.Composites;

namespace XpathBuilder.Api;

public interface IXPathBuilder : INode,
    IConnector<ICondition<IConnectorWithConditionEndGroup>>, IConditionStartGroup, IConditionEndGroup,
    ICondition<INodeWithConnector>, ICondition<IConnectorWithConditionEndGroup>,
    IConnector<ICondition<IConnectorWithConditionStartGroup>>
{
}
