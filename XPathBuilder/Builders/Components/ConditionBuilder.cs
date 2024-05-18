using XPathBuilder.Builders.Core;
using XpathBuilder.Components;
using XpathBuilder.Api;

namespace XPathBuilder.Builders.Components;

public class ConditionBuilder<TReturn> : ICondition<TReturn>
{
    private readonly XPathProcessor _xPathProcessor;

    private TReturn _returnApi;

    private INode _node;

    internal void Init(INode nodeBuilder, TReturn returnApi)
    {
        _node = nodeBuilder;
        _returnApi = returnApi;
    }

    public ConditionBuilder(XPathProcessor xPathProcessor)
    {
        _xPathProcessor = xPathProcessor;
    }

    public TReturn NodeHasName(string nodeName)
    {
        if (string.IsNullOrWhiteSpace(nodeName)) return _returnApi;

        string condition = $"name()='{nodeName}'";
        _xPathProcessor.AddXPathComponent(new Condition(condition));
        return _returnApi;
    }

    public TReturn WithAttribute(string attributeName, string attributeValue)
    {
        if (string.IsNullOrEmpty(attributeName)) return _returnApi;

        string condition = $"@{attributeName}='{attributeValue ?? string.Empty}'";
        _xPathProcessor.AddXPathComponent(new Condition(condition));
        return _returnApi;
    }

    public TReturn AtPosition(int position)
    {
        string condition = $"position()={position}";

        _xPathProcessor.AddXPathComponent(new Condition(condition));
        return _returnApi;
    }

    public TReturn ChildNodesAtSameLevel(params string[] elementNames)
    {
        var validElementNames = elementNames.Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
        if (validElementNames.Count == 0) return _returnApi;

        var xpathBuilder = _node.ChildNode("*");

        for (int i = 0; i < validElementNames.Count; i++)
        {
            var xpathConditionBuilder = xpathBuilder.NodeHasName(validElementNames[i]);
            if (i < validElementNames.Count - 1)
            {
                xpathConditionBuilder.Or();
            }
        }
        return _returnApi;
    }
}
