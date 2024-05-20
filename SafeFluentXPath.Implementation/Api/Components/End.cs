using SafeFluentXPath.Api.Components;
using SafeFluentXPath.Implementation.Api.Processors;

namespace SafeFluentXPath.Implementation.Api.Components;

internal class End(XPathProcessor xPathProcessor) : IEnd
{
    public string Build()
    {
        return xPathProcessor.Build();
    }
}
