using SafeFluentXPath.Abstraction.Api.Components;
using SafeFluentXPath.Implementation.Api.Processors;
using SafeFluentXPath.Implementation.Api.Processors.Components;

namespace SafeFluentXPath.Implementation.Api.Components;

internal class Connector<TReturn>(XPathProcessor xPathProcessor) : IConnector<TReturn>
{
    private TReturn _conditionBuilder;

    internal void Init(TReturn conditionBuilder)
    {
        _conditionBuilder = conditionBuilder;
    }

    public TReturn And()
    {
        xPathProcessor.AddXPathComponent(new ConnectorProcessor("and"));
        return _conditionBuilder;
    }

    public TReturn Or()
    {
        xPathProcessor.AddXPathComponent(new ConnectorProcessor("or"));
        return _conditionBuilder;
    }
}
