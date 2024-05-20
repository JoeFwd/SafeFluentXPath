namespace SafeFluentXPath.Abstraction.Api.Components.Composites;

public interface IContextNodeAndCondition :
    IContextNode,
    ICondition<IContextNodeAndConnector>,
    IConditionStartGroup,
    IEnd
{
}