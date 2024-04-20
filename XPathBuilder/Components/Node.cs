namespace XpathBuilder.Components;

public class Node : XPathComponent
{
    private readonly string _nodeName;

    public Node(string nodeName)
    {
        _nodeName = nodeName;
    }

    public string Process(XPathComponent? previousComponent, XPathComponent? nextComponent)
    {
        return _nodeName;
    }
}
