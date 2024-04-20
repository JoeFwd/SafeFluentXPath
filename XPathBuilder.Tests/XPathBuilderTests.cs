namespace XPathBuilder.Tests;

public class XPathBuilderTests
{
    private XpathBuilder.Builders.XPathBuilder _xPathBuilder;

    [SetUp]
    public void Setup()
    {
        _xPathBuilder = new();
    }

    [Test]
    public void Building_WithNoOptions_CreatesEmptyXPath()
    {
        var xpath = _xPathBuilder.Build();

        Assert.That(xpath, Is.EqualTo(string.Empty));
    }

    [Test]
    public void BuildingRoot_WithEmptyElement_CreatesEmptyXPath()
    {
        var xpath = _xPathBuilder.Root(string.Empty).Build();

        Assert.That(xpath, Is.EqualTo(string.Empty));
    }

    [Test]
    public void BuildingRoot_WithNull_CreatesEmptyXPath()
    {
        var xpath = _xPathBuilder.Root(null).Build();

        Assert.That(xpath, Is.EqualTo(string.Empty));
    }

    [Test]
    public void BuildingRoot_WithNonEmptyString_CreatesGivenString()
    {
        var xpath = _xPathBuilder.Root("RootElement").Build();

        Assert.That(xpath, Is.EqualTo("RootElement"));
    }

    [Test]
    public void BuildingChildNode_WithEmptyString_DoesNotAppendElement()
    {
        var xpath = _xPathBuilder
            .Root("RootElement")
            .ChildNode(string.Empty)
            .Build();

        Assert.That(xpath, Is.EqualTo("RootElement"));
    }

    [Test]
    public void BuildingChildNode_WithNull_DoesNotAppendElement()
    {
        var xpath = _xPathBuilder
            .Root("RootElement")
            .ChildNode(null)
            .Build();

        Assert.That(xpath, Is.EqualTo("RootElement"));
    }

    [Test]
    public void BuildingChildNode_WithNonEmptyString_AppendsElementWithAForwardSlash()
    {
        var xpath = _xPathBuilder
            .Root("RootElement")
            .ChildNode("ChildElement")
            .Build();

        Assert.That(xpath, Is.EqualTo("RootElement/ChildElement"));
    }

    [Test]
    public void BuildingChainedChildNodes_WithNonEmptyStrings_AppendsElementsWithForwardSlashes()
    {
        var xpath = _xPathBuilder
            .Root("RootElement")
            .ChildNode("ChildElement")
            .ChildNode("SecondChildElement")
            .ChildNodesAtSameLevel()
            .Build();

        Assert.That(xpath, Is.EqualTo("RootElement/ChildElement/SecondChildElement"));
    }

    [Test]
    public void BuildingDescendant_WithEmptyString_DoesNotAppendElement()
    {
        var xpath = _xPathBuilder
            .Root("RootElement")
            .Descendant(string.Empty)
            .Build();

        Assert.That(xpath, Is.EqualTo("RootElement"));
    }

    [Test]
    public void BuildingDescendant_WithNull_DoesNotAppendElement()
    {
        var xpath = _xPathBuilder
            .Root("RootElement")
            .Descendant(null)
            .Build();

        Assert.That(xpath, Is.EqualTo("RootElement"));
    }

    [Test]
    public void BuildingDescendant_WithNonEmptyString_AppendsElementWithDoubleForwardSlashes()
    {
        var xpath = _xPathBuilder
            .Root("RootElement")
            .Descendant("DescendantElement")
            .Build();

        Assert.That(xpath, Is.EqualTo("RootElement//DescendantElement"));
    }

    [Test]
    public void BuildingChainedDescendants_WithNonEmptyStrings_AppendsElementsWithDoubleForwardSlashes()
    {
        var xpath = _xPathBuilder
            .Root("RootElement")
            .Descendant("DescendantElement")
            .Descendant("SecondDescendantElement")
            .Build();

        Assert.That(xpath, Is.EqualTo("RootElement//DescendantElement//SecondDescendantElement"));
    }

    [Test]
    public void
        BuildingChainedDescendants_WithNonEmptyStringsAndChildNodesAtSameLevel_AppendsElementsWithDoubleForwardSlashes()
    {
        var xpath = _xPathBuilder
            .Root("RootElement")
            .Descendant("DescendantElement")
            .Descendant("SecondDescendantElement")
            .ChildNodesAtSameLevel("ChildElement", "SecondChildElement")
            .Build();

        Assert.That(xpath,
            Is.EqualTo("RootElement//DescendantElement//SecondDescendantElement/ChildElement|SecondChildElement"));
    }

    [Test]
    public void
        BuildingChainedDescendants_WithNonEmptyStringsAndChildNodesAtSameLevelAndAttributes_AppendsElementsWithDoubleForwardSlashes()
    {
        var xpath = _xPathBuilder
            .Root("RootElement")
            .Descendant("DescendantElement")
            .Descendant("SecondDescendantElement")
            .WithAttribute("Attribute", "Value")
            .Build();

        Assert.That(xpath,
            Is.EqualTo(
                "RootElement//DescendantElement//SecondDescendantElement/ChildElement|SecondChildElement[@Attribute='Value']"));
    }

    [Test]

    public void
        BuildingChainedDescendants_WithNonEmptyStringsAndChildNodesAtSameLevelAndAttributesAndPosition_AppendsElementsWithDoubleForwardSlashes()
    {
        var xpath = _xPathBuilder
            .Root("RootElement")
            .Descendant("DescendantElement")
            .Descendant("SecondDescendantElement")
            .ChildNodesAtSameLevel("ChildElement", "SecondChildElement")
            .And()
            .WithAttribute("Attribute", "Value")
            .And()
            .
            .AtPosition(1)
            .Build();

        Assert.That(xpath,
            Is.EqualTo(
                "RootElement//DescendantElement//SecondDescendantElement/ChildElement|SecondChildElement[@Attribute='Value'][1]"));
    }

    [Test]
    public void
        BuildingChainedDescendants_WithNonEmptyStringsAndChildNodesAtSameLevelAndAttributesAndPositionAndNodeName_AppendsElementsWithDoubleForwardSlashes()
    {
        var xpath = _xPathBuilder
            .Root("RootElement")
            .Descendant("DescendantElement")
            .Descendant("SecondDescendantElement")
            .ChildNodesAtSameLevel("ChildElement", "SecondChildElement")
            .And()
            .WithAttribute("Attribute", "Value")
            .AtPosition(1)
            .And()
            .NodeHasName("NodeName")
            .Build();

        Assert.That(xpath,
            Is.EqualTo(
                "RootElement//DescendantElement//SecondDescendantElement/ChildElement|SecondChildElement[@Attribute='Value'][1][NodeName]"));
    }
}
