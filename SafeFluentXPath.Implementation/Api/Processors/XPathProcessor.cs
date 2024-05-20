using SafeFluentXPath.Implementation.Api.Processors.Components;

namespace SafeFluentXPath.Implementation.Api.Processors;
internal class XPathProcessor
{
    private readonly List<IXPathComponentProcessor> _xPathComponents = new ();

    public void AddXPathComponent(IXPathComponentProcessor ixPathComponent)
    {
        _xPathComponents.Add(ixPathComponent);
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

