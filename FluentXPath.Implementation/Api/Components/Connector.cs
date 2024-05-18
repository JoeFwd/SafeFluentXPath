using FluentXPath.Api.Components;
using FluentXPath.Implementation.Api.Processors;
using FluentXPath.Implementation.Api.Processors.Components;

namespace FluentXPath.Implementation.Api.Components;

public class Connector<TReturn>(XPathProcessor xPathProcessor) : IConnector<TReturn>
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
