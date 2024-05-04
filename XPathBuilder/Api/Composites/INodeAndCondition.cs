namespace XpathBuilder.ReturnLogic.Composites;

public interface INodeAndCondition : INode,
    ICondition<INodeAndConnector>, IConditionStartGroup
{
}
