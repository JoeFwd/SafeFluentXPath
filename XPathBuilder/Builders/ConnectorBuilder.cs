using XpathBuilder.Components;
using XpathBuilder.ReturnLogic;

namespace XpathBuilder.Builders;

public class ConnectorBuilder<R> : IConnector<R>
{
    private readonly XPathProcessor _xPathProcessor;
    private ICondition<R> _conditionBuilder;

    internal void Init(ICondition<R> conditionBuilder)
    {
        _conditionBuilder = conditionBuilder;
    }

    public ConnectorBuilder(XPathProcessor xPathProcessor)
    {
        _xPathProcessor = xPathProcessor;
    }

    public ICondition<R> And()
    {
        _xPathProcessor.AddXPathComponent(new Connector("and"));
        return _conditionBuilder;
    }

    public ICondition<R> Or()
    {
        _xPathProcessor.AddXPathComponent(new Connector("or"));
        return _conditionBuilder;
    }
}
