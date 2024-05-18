namespace XpathBuilder.Api.Composites;

public interface INodeAndCondition : INode,
    ICondition<INodeAndConnector>, IConditionStartGroup
{
}
