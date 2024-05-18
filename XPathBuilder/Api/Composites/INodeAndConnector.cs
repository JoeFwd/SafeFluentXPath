namespace XpathBuilder.Api.Composites;

public interface INodeAndConnector : INode,
    IConnector<ICondition<INodeAndConnector>>
{
}
