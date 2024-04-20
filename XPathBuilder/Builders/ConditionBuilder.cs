using XpathBuilder.Components;
using XpathBuilder.ReturnLogic;

namespace XpathBuilder.Builders;

public class ConditionBuilder<R> : ICondition<R>
{
    private readonly XPathProcessor _xPathProcessor;

    private readonly R _builderToReturn;

    private INode _node;

    internal void Init(NodeBuilder nodeBuilder)
    {
        _node = nodeBuilder;
    }

    public ConditionBuilder(XPathProcessor xPathProcessor, R builderToReturn)
    {
        _xPathProcessor = xPathProcessor;
        _builderToReturn = builderToReturn;
    }

    public R NodeHasName(string nodeName)
    {
        if (string.IsNullOrWhiteSpace(nodeName)) return _builderToReturn;

        string condition = $"name()='{nodeName}'";
        _xPathProcessor.AddXPathComponent(new Condition(condition));
        return _builderToReturn;
    }

    public R WithAttribute(string attributeName, string attributeValue)
    {
        if (string.IsNullOrEmpty(attributeName)) return _builderToReturn;

        string condition = $"@{attributeName}='{attributeValue ?? string.Empty}'";
        _xPathProcessor.AddXPathComponent(new Condition(condition));
        return _builderToReturn;
    }

    public R AtPosition(int position)
    {
        string condition = $"position()={position}";

        _xPathProcessor.AddXPathComponent(new Condition(condition));
        return _builderToReturn;
    }

    public R ChildNodesAtSameLevel(params string[] elementNames)
    {
        var validElementNames = elementNames.Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
        if (validElementNames.Count == 0) return _builderToReturn;

        var xpathBuilder = _node.ChildNode("*");

        for (int i = 0; i < validElementNames.Count; i++)
        {
            var xpathConditionBuilder = xpathBuilder.NodeHasName(validElementNames[i]);
            if (i < validElementNames.Count - 1)
            {
                xpathConditionBuilder.Or();
            }
        }
        return _builderToReturn;
    }
}
