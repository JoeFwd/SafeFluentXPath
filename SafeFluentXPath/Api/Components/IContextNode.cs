using SafeFluentXPath.Api.Components.Composites;

namespace SafeFluentXPath.Api.Components;

public interface IContextNode
{
    /// <summary>
    /// Adds a child node to the XPath.
    /// </summary>
    /// <param name="elementName">The child node name</param>
    /// <returns>The current builder instance.</returns>
    IContextNodeAndCondition ChildElement(string elementName);

    /// <summary>
    /// Adds a descendant to the XPath.
    /// </summary>
    /// <param name="descendant">The descendant name</param>
    /// <returns>The current builder instance.</returns>
    /// <remarks>
    /// If the descendant name is empty, the method returns the current instance.
    /// </remarks>
    IContextNodeAndCondition Descendant(string descendant);
}
