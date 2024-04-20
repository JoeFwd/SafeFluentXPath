namespace XpathBuilder.ReturnLogic;

public interface ICondition<out R>
{
    /**
     * <summary>
     * This method adds an attribute to the XPath.
     * </summary>
     * <param name="attributeName">The attribute name</param>
     * <param name="attributeValue">The attribute value</param>
     * <returns>The XPathBuilder instance.</returns>
     * <remarks>
     * If the attribute name is empty, then the method just returns the current instance.
     * </remarks>
     */
    R WithAttribute(string attributeName, string attributeValue);

    /**
     * <summary>
     * This method adds a position to the XPath.
     * </summary>
     * <param name="position">The position</param>
     * <returns>The XPathBuilder instance.</returns>
     */
    R AtPosition(int position);

    /**
     * <summary>
     * This method adds a condition checking whether the node has a specific name.
     * </summary>
     * <param name="nodeName">The node name</param>
     * <returns>The XPathBuilder instance.</returns>
     */
    R NodeHasName(string nodeName);

    /**
     * <summary>
     * This method adds child nodes to the XPath.
     * It means that the the xpath will get the given elements at the same node level.
     * It prefixes the element name with "/".
     * </summary>
     */
    R ChildNodesAtSameLevel(params string[] elementNames);
}
