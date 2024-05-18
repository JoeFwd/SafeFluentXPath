namespace XpathBuilder.Api.Composites;

public interface INodeWithConnector : INode,
    IConnector<ICondition<INodeWithConnector>>
{
}
