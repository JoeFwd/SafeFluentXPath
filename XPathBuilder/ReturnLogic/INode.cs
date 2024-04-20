using XpathBuilder.ReturnLogic.Composites;

namespace XpathBuilder.ReturnLogic;

public interface INode
{
    /**
     * <summary>
     * This method adds the root element to the XPath.
     * If the XPath is empty and the parameter is not empty, then the element name is added as the root element.
     * </summary>
     * <param name="elementName">The root element name</param>
     * <returns>The XPathBuilder instance.</returns>
     */
    INodeAndCondition Root(string elementName);

    /**
     * <summary>
     * This method adds a child node to the XPath.
     * This basically prefixes the descendant name with "/".
     * </summary>
     * <param name="elementName">The child node name</param>
     * <returns>The XPathBuilder instance.</returns>
     */
    INodeAndCondition ChildNode(string elementName);

    /**
     * <summary>
     * This method adds a descendant to the XPath.
     * This basically prefixes the descendant name with "//".
     * </summary>
     * <param name="descendant">The descendant name</param>
     * <returns>The XPathBuilder instance.</returns>
     * <remarks>
     * If the descendant name is empty, then the method just returns the current instance.
     * </remarks>
     */
    INodeAndCondition Descendant(string descendant);

    /**
     * <summary>
     * Returns the XPath string.
     * </summary>
     */
    string Build();
}
