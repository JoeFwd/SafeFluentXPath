namespace XpathBuilder.ReturnLogic;

public interface IConnector<out TReturn>
{

    /**
     * <summary>
     * This method adds the and operator to the XPath.
     * </summary>
     */
    TReturn And();

    /**
     * <summary>
     * This method adds the or operator to the XPath.
     * </summary>
     */
    TReturn Or();
}
