using SafeFluentXPath.Api.Components.Composites;

namespace SafeFluentXPath.Api.Components;

/// <summary>
/// This interface, `INode`, is the core component that allows users to select elements
/// </summary>
public interface INode
{
    /// <summary>
    /// Adds the root element to the XPath.
    /// </summary>
    /// <param name="elementName">The root element name</param>
    /// <returns>The current builder instance.</returns>
    IContextNodeAndCondition Element(string elementName);
}
