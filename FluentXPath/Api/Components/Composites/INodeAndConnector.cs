namespace FluentXPath.Api.Components.Composites;

public interface INodeAndConnector : INode,
    IConnector<ICondition<INodeAndConnector>>
{
}
