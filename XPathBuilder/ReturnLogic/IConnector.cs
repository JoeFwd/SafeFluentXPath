namespace XpathBuilder.ReturnLogic;

public interface IConnector<R>
{

    /**
     * <summary>
     * This method adds the and operator to the XPath.
     * Another condition is required after this method.
     * </summary>
     */
    ICondition<R> And();

    /**
     * <summary>
     * This method adds the or operator to the XPath.
     * Another condition is required after this method.
     * </summary>
     */
    ICondition<R> Or();
}
