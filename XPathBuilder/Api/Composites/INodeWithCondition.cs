namespace XpathBuilder.Api.Composites;

public interface INodeWithCondition : INode,
    ICondition<INodeWithConnector>, IConditionStartGroup
{
}
