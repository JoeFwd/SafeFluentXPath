namespace SafeFluentXPath.Api.Components;

/// <summary>
/// Represents a connector enabling to creation of conditional XPath expressions.
/// </summary>
/// <typeparam name="TReturn">The return type of the XPath expression.</typeparam>
public interface IConnector<out TReturn>
{
    /// <summary>
    /// Adds the 'and' operator to the XPath.
    /// </summary>
    /// <returns>The current builder instance.</returns>
    TReturn And();

     /// <summary>
     /// Adds the 'or' operator to the XPath.
     /// </summary>
     /// <returns>The current builder instance.</returns>
    TReturn Or();
}
