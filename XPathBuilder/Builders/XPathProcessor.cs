using XpathBuilder.Components;

namespace XpathBuilder.Builders;
public class XPathProcessor
{
    private readonly List<XPathComponent> _xPathComponents = new();

    public void AddXPathComponent(XPathComponent xPathComponent)
    {
        _xPathComponents.Add(xPathComponent);
    }

    public int GetXPathComponentCount()
    {
        return _xPathComponents.Count;
    }

    public string Build()
    {
        return string.Join(string.Empty, _xPathComponents.Select((xpathComponent, index) =>
        {
            var previousComponent = index > 0 ? _xPathComponents[index - 1] : null;
            var nextComponent = index < _xPathComponents.Count - 1 ? _xPathComponents[index + 1] : null;
            return xpathComponent.Process(previousComponent, nextComponent);
        }));
    }
}

