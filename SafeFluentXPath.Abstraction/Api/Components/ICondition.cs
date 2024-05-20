namespace SafeFluentXPath.Abstraction.Api.Components;

public interface ICondition<out R>
{
    /**
     * <summary>
     * Adds an attribute to the XPath.
     * </summary>
     * <param name="attributeName">The attribute name</param>
     * <param name="attributeValue">The attribute value</param>
     * <returns>The current builder instance.</returns>
     * <remarks>
     * If the attribute name is empty, the method returns the current instance.
     * </remarks>
     */
    R WithAttribute(string attributeName, string attributeValue);

    /**
     * <summary>
     * Adds a position to the XPath.
     * </summary>
     * <param name="position">The position</param>
     * <returns>The current builder instance.</returns>
     */
    R AtPosition(int position);

    /**
     * <summary>
     * Adds a condition to check if the element has a specific name.
     * </summary>
     * <param name="elementName">The node name</param>
     * <returns>The current builder instance.</returns>
     */
    R HasName(string elementName);

    /**
     * <summary>
     * Adds child nodes at the same level in the XPath.
     * </summary>
     * <param name="elementNames">Names of the child elements</param>
     * <returns>The current builder instance.</returns>
     */
    R ChildElementsAtSameLevel(params string[] elementNames);
}
