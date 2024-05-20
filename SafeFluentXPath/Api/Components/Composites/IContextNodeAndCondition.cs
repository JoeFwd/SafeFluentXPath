namespace SafeFluentXPath.Api.Components.Composites;

public interface IContextNodeAndCondition :
    IContextNode,
    ICondition<IContextNodeAndConnector>,
    IConditionStartGroup,
    IEnd
{
}