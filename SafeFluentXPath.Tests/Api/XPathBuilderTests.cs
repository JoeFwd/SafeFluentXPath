using NUnit.Framework;
using SafeFluentXPath.Abstraction.Api;
using SafeFluentXPath.Implementation.Api;

namespace SafeFluentXPath.Tests.Api;

public class XPathBuilderTests
{
    private IXPath _xPath = null!;

    [SetUp]
    public void Setup()
    {
        _xPath = new XPathBuilder();
    }

    [Test]
    public void BuildingElement_WithEmptyElement_CreatesEmptyXPath()
    {
        var xpathBuilder = _xPath.Element(string.Empty);

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo(string.Empty));
    }

    [Test]
    public void BuildingElement_WithNull_CreatesEmptyXPath()
    {
        var xpathBuilder = _xPath.Element(null);

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo(string.Empty));
    }

    [Test]
    public void BuildingElement_WithNonEmptyString_CreatesGivenString()
    {
        var xpathBuilder = _xPath.Element("RootElement");

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo("RootElement"));
    }

    [Test]
    public void BuildingChildElement_WithEmptyString_DoesNotAppendElement()
    {
        var xpathBuilder = _xPath
            .ChildElement(string.Empty);

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo(string.Empty));
    }

    [Test]
    public void BuildingChildElement_WithNull_DoesNotAppendElement()
    {
        var xpathBuilder = _xPath
            .ChildElement(null);

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo(string.Empty));
    }

    [Test]
    public void BuildingChildElement_WithNonEmptyString_AppendsElementWithAForwardSlash()
    {
        var xpathBuilder = _xPath
            .ChildElement("ChildElement");

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo("/ChildElement"));
    }

    [Test]
    public void BuildingChildElements_WithNonEmptyStrings_AppendsElementsWithForwardSlashes()
    {
        var xpathBuilder = _xPath
            .ChildElement("ChildElement")
            .ChildElement("SecondChildElement")
            .ChildElementsAtSameLevel();

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo("/ChildElement/SecondChildElement"));
    }

    [Test]
    public void BuildingDescendant_WithEmptyString_DoesNotAppendElement()
    {
        var xpathBuilder = _xPath
            .Descendant(string.Empty);

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo(string.Empty));
    }

    [Test]
    public void BuildingDescendant_WithNull_DoesNotAppendElement()
    {
        var xpathBuilder = _xPath
            .Descendant(null);

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo(string.Empty));
    }

    [Test]
    public void BuildingDescendant_WithNonEmptyString_AppendsElementWithDoubleForwardSlashes()
    {
        var xpathBuilder = _xPath
            .Descendant("DescendantElement");

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo("//DescendantElement"));
    }

    [Test]
    public void BuildingDescendants_WithNonEmptyStrings_AppendsElementsWithDoubleForwardSlashes()
    {
        var xpathBuilder = _xPath
            .Descendant("DescendantElement")
            .Descendant("SecondDescendantElement");

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo("//DescendantElement//SecondDescendantElement"));
    }

    [Test]
    public void BuildingSingleCondition_WithoutConnector_AppendsConditionWithoutOperator()
    {
        var xpathBuilder = _xPath
            .Element("RootElement")
            .ChildElement("ChildElement")
            .WithAttribute("attr1", "value1");

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo("RootElement/ChildElement[@attr1='value1']"));
    }

    [Test]
    public void BuildingMultipleConditions_WithAndConnector_AppendsConditionsWithAndOperator()
    {
        var xpathBuilder = _xPath
            .Element("RootElement")
            .ChildElement("ChildElement")
            .WithAttribute("attr1", "value1")
            .And()
            .AtPosition(2);

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo("RootElement/ChildElement[@attr1='value1' and position()=2]"));
    }

    [Test]
    public void BuildingMultipleConditions_WithOrConnector_AppendsConditionsWithOrOperator()
    {
        var xpathBuilder = _xPath
            .Element("RootElement")
            .ChildElement("ChildElement")
            .WithAttribute("attr1", "value1")
            .Or()
            .AtPosition(2);

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo("RootElement/ChildElement[@attr1='value1' or position()=2]"));
    }

    [Test]
    public void BuildingConditionGroup_WithAndConnector_AppendsGroupedConditionsWithAndOperator()
    {
        var xpathBuilder = _xPath
            .Element("RootElement")
            .ChildElement("ChildElement")
            .StartGroupCondition()
            .WithAttribute("attr1", "value1")
            .And()
            .AtPosition(2)
            .EndConditionGroup();

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo("RootElement/ChildElement[(@attr1='value1' and position()=2)]"));
    }

    [Test]
    public void BuildingConditionGroup_WithOrConnector_AppendsGroupedConditionsWithOrOperator()
    {
        var xpathBuilder = _xPath
            .Element("RootElement")
            .ChildElement("ChildElement")
            .StartGroupCondition()
            .WithAttribute("attr1", "value1")
            .Or()
            .AtPosition(2)
            .EndConditionGroup();

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo("RootElement/ChildElement[(@attr1='value1' or position()=2)]"));
    }

    [Test]
    public void BuildingMultipleConditionGroups_WithOrConnector_AppendsGroupedConditionsWithOrOperator()
    {
        var xpathBuilder = _xPath
            .Element("RootElement")
            .ChildElement("ChildElement")
            .StartGroupCondition()
            .AtPosition(1)
            .EndConditionGroup()
            .Or()
            .StartGroupCondition()
            .AtPosition(2)
            .EndConditionGroup();

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo("RootElement/ChildElement[(position()=1) or (position()=2)]"));
    }

    [Test]
    public void BuildingMultipleConditionGroups_WithAndConnector_AppendsGroupedConditionsWithAndOperator()
    {
        var xpathBuilder = _xPath
            .Element("RootElement")
            .ChildElement("ChildElement")
            .StartGroupCondition()
            .AtPosition(1)
            .EndConditionGroup()
            .And()
            .StartGroupCondition()
            .AtPosition(2)
            .EndConditionGroup();

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo("RootElement/ChildElement[(position()=1) and (position()=2)]"));
    }

    [Test]
    public void BuildingChildElementsAtSameLevel_AppendsChildElementsWithSlash()
    {
        var xpathBuilder = _xPath
            .Element("RootElement")
            .ChildElementsAtSameLevel("Node1", "Node2", "Node3");

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo("RootElement/*[name()='Node1' or name()='Node2' or name()='Node3']"));
    }
    
    [Test]
    public void BuildingChildElementsAtSameLevel_WithEmptyStrings_DoesNotIncludeEmptyElements()
    {
        var xpathBuilder = _xPath
            .Element("RootElement")
            .ChildElementsAtSameLevel("Node1", string.Empty, "Node3");

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo("RootElement/*[name()='Node1' or name()='Node3']"));
    }

    [Test]
    public void BuildingChildElementsAtSameLevel_WithNullValues_DoesNotIncludeNullElements()
    {
        var xpathBuilder = _xPath
            .Element("RootElement")
            .ChildElementsAtSameLevel("Node1", null, "Node3");

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo("RootElement/*[name()='Node1' or name()='Node3']"));
    }

    [Test]
    public void BuildingCondition_WithEmptyAttributeName_DoesNotIncludeCondition()
    {
        var xpathBuilder = _xPath
            .Element("RootElement")
            .ChildElement("ChildElement")
            .WithAttribute(string.Empty, "value1");

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo("RootElement/ChildElement"));
    }

    [Test]
    public void BuildingCondition_WithNullAttributeName_DoesNotIncludeCondition()
    {
        var xpathBuilder = _xPath
            .Element("RootElement")
            .ChildElement("ChildElement")
            .WithAttribute(null, "value1");

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo("RootElement/ChildElement"));
    }

    [Test]
    public void BuildingCondition_WithAttributeName_DoesIncludeCondition()
    {
        var xpathBuilder = _xPath
            .Element("RootElement")
            .ChildElement("ChildElement")
            .WithAttribute("attr", "value1");

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo("RootElement/ChildElement[@attr='value1']"));
    }

    [Test]
    public void BuildingCondition_WithNegativePosition_DoesIncludeCondition()
    {
        var xpathBuilder = _xPath
            .Element("RootElement")
            .ChildElement("ChildElement")
            .AtPosition(-2);

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo("RootElement/ChildElement[position()=-2]"));
    }

    [Test]
    public void BuildingCondition_WithZeroPosition_DoesIncludeCondition()
    {
        var xpathBuilder = _xPath
            .Element("RootElement")
            .ChildElement("ChildElement")
            .AtPosition(0);

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo("RootElement/ChildElement[position()=0]"));
    }

    [Test]
    public void BuildingCondition_WithEmptyNodeName_DoesNotIncludeCondition()
    {
        var xpathBuilder = _xPath
            .Element("RootElement")
            .ChildElement("ChildElement")
            .HasName(string.Empty);

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo("RootElement/ChildElement"));
    }

    [Test]
    public void BuildingCondition_WithNullNodeName_DoesNotIncludeCondition()
    {
        var xpathBuilder = _xPath
            .Element("RootElement")
            .ChildElement("ChildElement")
            .HasName(null);

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo("RootElement/ChildElement"));
    }

    [Test]
    public void BuildingCondition_WithNodeName_DoesIncludeCondition()
    {
        var xpathBuilder = _xPath
            .Element("*")
            .HasName("name");

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo("*[name()='name']"));
    }
}
