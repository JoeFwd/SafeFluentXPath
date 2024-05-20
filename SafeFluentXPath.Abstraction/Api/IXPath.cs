using SafeFluentXPath.Abstraction.Api.Components;

namespace SafeFluentXPath.Abstraction.Api;

/// <summary>
/// Represents a base interface for XPath queries, which allows chaining with various nodes, conditions, and connectors.
/// </summary>
public interface IXPath : INode, IContextNode
{
}
