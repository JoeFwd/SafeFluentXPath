namespace XpathBuilder.Api;

public interface IConnector<out TReturn>
{
    /**
     * <summary>
     * Adds the 'and' operator to the XPath.
     * </summary>
     * <returns>The current builder instance.</returns>
     */
    TReturn And();

    /**
     * <summary>
     * Adds the 'or' operator to the XPath.
     * </summary>
     * <returns>The current builder instance.</returns>
     */
    TReturn Or();
}
