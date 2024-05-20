using SafeFluentXPath.Api.Components;
using SafeFluentXPath.Implementation.Api.Processors;
using SafeFluentXPath.Implementation.Api.Processors.Components;

namespace SafeFluentXPath.Implementation.Api.Components;

internal class Condition<TReturn>(XPathProcessor xPathProcessor) : ICondition<TReturn>
{
    private TReturn _returnApi;

    private INode _node;

    internal void Init(INode nodeBuilder, TReturn returnApi)
    {
        _node = nodeBuilder;
        _returnApi = returnApi;
        
    }

    public TReturn HasName(string nodeName)
    {
        if (string.IsNullOrWhiteSpace(nodeName)) return _returnApi;

        string condition = $"name()='{nodeName}'";
        xPathProcessor.AddXPathComponent(new ConditionProcessor(condition));
        return _returnApi;
    }

    public TReturn WithAttribute(string attributeName, string attributeValue)
    {
        if (string.IsNullOrEmpty(attributeName)) return _returnApi;

        string condition = $"@{attributeName}='{attributeValue ?? string.Empty}'";
        xPathProcessor.AddXPathComponent(new ConditionProcessor(condition));
        return _returnApi;
    }

    public TReturn AtPosition(int position)
    {
        string condition = $"position()={position}";

        xPathProcessor.AddXPathComponent(new ConditionProcessor(condition));
        return _returnApi;
    }

    public TReturn ChildElementsAtSameLevel(params string[] elementNames)
    {
        var validElementNames = elementNames.Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
        if (validElementNames.Count == 0) return _returnApi;

        var xpathBuilder = _node.ChildElement("*");

        for (int i = 0; i < validElementNames.Count; i++)
        {
            var xpathConditionBuilder = xpathBuilder.HasName(validElementNames[i]);
            if (i < validElementNames.Count - 1)
            {
                xpathConditionBuilder.Or();
            }
        }
        return _returnApi;
    }
}
