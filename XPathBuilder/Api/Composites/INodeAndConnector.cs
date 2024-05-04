namespace XpathBuilder.ReturnLogic.Composites;

public interface INodeAndConnector : INode,
    IConnector<ICondition<INodeAndConnector>>
{
}
