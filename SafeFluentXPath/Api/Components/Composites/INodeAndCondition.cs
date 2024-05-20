namespace SafeFluentXPath.Api.Components.Composites;

public interface INodeAndCondition : INode,
    ICondition<INodeAndConnector>, IConditionStartGroup
{
}
