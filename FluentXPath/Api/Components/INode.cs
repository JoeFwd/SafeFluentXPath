using FluentXPath.Api.Components.Composites;

namespace FluentXPath.Api.Components;

public interface INode
{
    /**
     * <summary>
     * Adds the root element to the XPath.
     * </summary>
     * <param name="elementName">The root element name</param>
     * <returns>The current builder instance.</returns>
     */
    INodeAndCondition Root(string elementName);

    /**
     * <summary>
     * Adds a child node to the XPath.
     * </summary>
     * <param name="elementName">The child node name</param>
     * <returns>The current builder instance.</returns>
     */
    INodeAndCondition ChildNode(string elementName);

    /**
     * <summary>
     * Adds a descendant to the XPath.
     * </summary>
     * <param name="descendant">The descendant name</param>
     * <returns>The current builder instance.</returns>
     * <remarks>
     * If the descendant name is empty, the method returns the current instance.
     * </remarks>
     */
    INodeAndCondition Descendant(string descendant);

    /**
     * <summary>
     * Builds and returns the XPath string.
     * </summary>
     * <returns>The constructed XPath string.</returns>
     */
    string Build();
}
