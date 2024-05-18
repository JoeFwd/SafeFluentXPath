using XPathBuilder.Builders.Core;
using XpathBuilder.Components;
using XpathBuilder.Api;

namespace XPathBuilder.Builders.Components;

public class Connector<TReturn> : IConnector<TReturn>
{
    private readonly XPathProcessor _xPathProcessor;
    private TReturn _conditionBuilder;

    internal void Init(TReturn conditionBuilder)
    {
        _conditionBuilder = conditionBuilder;
    }

    public Connector(XPathProcessor xPathProcessor)
    {
        _xPathProcessor = xPathProcessor;
    }

    public TReturn And()
    {
        _xPathProcessor.AddXPathComponent(new Connector("and"));
        return _conditionBuilder;
    }

    public TReturn Or()
    {
        _xPathProcessor.AddXPathComponent(new Connector("or"));
        return _conditionBuilder;
    }
}
