namespace SafeFluentXPath.Api.Components.Composites;

public interface IContextNodeAndConnector : 
    IContextNode,
    IConnector<ICondition<IContextNodeAndConnector>>,
    IConditionStartGroup,
    IEnd
{
}
