namespace XpathBuilder.Components;

/**
 * Interface for XPath components
 */
public interface XPathComponent
{
    /**
     * <summary>
     * Process the component
     * </summary>
     * <param name="previousComponent">The previous component</param>
     * <param name="nextComponent">The next component</param>
     * <returns>The processed component</returns>
     * <throws>InvalidOperationException</throws>
     * if the type of the previous and next components can not be processed with the current component.
     */
    string Process(XPathComponent? previousComponent, XPathComponent? nextComponent);
}
