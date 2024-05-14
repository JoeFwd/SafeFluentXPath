using XpathBuilder.Builders;

namespace XPathBuilder.Tests;

public class XPathBuilderTests
{
    private XpathBuilder.Builders.XPathBuilder _xPathBuilder = null!;

    [SetUp]
    public void Setup()
    {
        _xPathBuilder = new ();
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
        var xpathBuilder = _xPathBuilder.Root(string.Empty);

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo(string.Empty));
    }

    [Test]
    public void BuildingRoot_WithNull_CreatesEmptyXPath()
    {
        var xpathBuilder = _xPathBuilder.Root(null);

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo(string.Empty));
    }

    [Test]
    public void BuildingRoot_WithNonEmptyString_CreatesGivenString()
    {
        var xpathBuilder = _xPathBuilder.Root("RootElement");

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo("RootElement"));
    }

    [Test]
    public void BuildingChildNode_WithEmptyString_DoesNotAppendElement()
    {
        var xpathBuilder = _xPathBuilder
            .Root("RootElement")
            .ChildNode(string.Empty);

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo("RootElement"));
    }

    [Test]
    public void BuildingChildNode_WithNull_DoesNotAppendElement()
    {
        var xpathBuilder = _xPathBuilder
            .Root("RootElement")
            .ChildNode(null);

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo("RootElement"));
    }

    [Test]
    public void BuildingChildNode_WithNonEmptyString_AppendsElementWithAForwardSlash()
    {
        var xpathBuilder = _xPathBuilder
            .Root("RootElement")
            .ChildNode("ChildElement");

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo("RootElement/ChildElement"));
    }

    [Test]
    public void BuildingChildNodes_WithNonEmptyStrings_AppendsElementsWithForwardSlashes()
    {
        var xpathBuilder = _xPathBuilder
            .Root("RootElement")
            .ChildNode("ChildElement")
            .ChildNode("SecondChildElement")
            .ChildNodesAtSameLevel();

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo("RootElement/ChildElement/SecondChildElement"));
    }

    [Test]
    public void BuildingDescendant_WithEmptyString_DoesNotAppendElement()
    {
        var xpathBuilder = _xPathBuilder
            .Root("RootElement")
            .Descendant(string.Empty);

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo("RootElement"));
    }

    [Test]
    public void BuildingDescendant_WithNull_DoesNotAppendElement()
    {
        var xpathBuilder = _xPathBuilder
            .Root("RootElement")
            .Descendant(null);

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo("RootElement"));
    }

    [Test]
    public void BuildingDescendant_WithNonEmptyString_AppendsElementWithDoubleForwardSlashes()
    {
        var xpathBuilder = _xPathBuilder
            .Root("RootElement")
            .Descendant("DescendantElement");

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo("RootElement//DescendantElement"));
    }

    [Test]
    public void BuildingDescendants_WithNonEmptyStrings_AppendsElementsWithDoubleForwardSlashes()
    {
        var xpathBuilder = _xPathBuilder
            .Root("RootElement")
            .Descendant("DescendantElement")
            .Descendant("SecondDescendantElement");

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo("RootElement//DescendantElement//SecondDescendantElement"));
    }

    [Test]
    public void BuildingSingleCondition_WithoutConnector_AppendsConditionWithoutOperator()
    {
        var xpathBuilder = _xPathBuilder
            .Root("RootElement")
            .ChildNode("ChildElement")
            .WithAttribute("attr1", "value1");

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo("RootElement/ChildElement[@attr1='value1']"));
    }

    [Test]
    public void BuildingMultipleConditions_WithAndConnector_AppendsConditionsWithAndOperator()
    {
        var xpathBuilder = _xPathBuilder
            .Root("RootElement")
            .ChildNode("ChildElement")
            .WithAttribute("attr1", "value1")
            .And()
            .AtPosition(2);

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo("RootElement/ChildElement[@attr1='value1' and position()=2]"));
    }

    [Test]
    public void BuildingMultipleConditions_WithOrConnector_AppendsConditionsWithOrOperator()
    {
        var xpathBuilder = _xPathBuilder
            .Root("RootElement")
            .ChildNode("ChildElement")
            .WithAttribute("attr1", "value1")
            .Or()
            .AtPosition(2);

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo("RootElement/ChildElement[@attr1='value1' or position()=2]"));
    }

    [Test]
    public void BuildingConditionGroup_WithAndConnector_AppendsGroupedConditionsWithAndOperator()
    {
        var xpathBuilder = _xPathBuilder
            .Root("RootElement")
            .ChildNode("ChildElement")
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
        var xpathBuilder = _xPathBuilder
            .Root("RootElement")
            .ChildNode("ChildElement")
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
        var xpathBuilder = _xPathBuilder
            .Root("RootElement")
            .ChildNode("ChildElement")
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
        var xpathBuilder = _xPathBuilder
            .Root("RootElement")
            .ChildNode("ChildElement")
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
    public void BuildingChildNodesAtSameLevel_AppendsChildNodesWithSlash()
    {
        var xpathBuilder = _xPathBuilder
            .Root("RootElement")
            .ChildNodesAtSameLevel("Node1", "Node2", "Node3");

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo("RootElement/*[name()='Node1' or name()='Node2' or name()='Node3']"));
    }

    
    
    
    [Test]
    public void BuildingChildNodesAtSameLevel_WithEmptyStrings_DoesNotIncludeEmptyElements()
    {
        var xpathBuilder = _xPathBuilder
            .Root("RootElement")
            .ChildNodesAtSameLevel("Node1", string.Empty, "Node3");

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo("RootElement/*[name()='Node1' or name()='Node3']"));
    }

    [Test]
    public void BuildingChildNodesAtSameLevel_WithNullValues_DoesNotIncludeNullElements()
    {
        var xpathBuilder = _xPathBuilder
            .Root("RootElement")
            .ChildNodesAtSameLevel("Node1", null, "Node3");

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo("RootElement/*[name()='Node1' or name()='Node3']"));
    }

    [Test]
    public void BuildingCondition_WithEmptyAttributeName_DoesNotIncludeCondition()
    {
        var xpathBuilder = _xPathBuilder
            .Root("RootElement")
            .ChildNode("ChildElement")
            .WithAttribute(string.Empty, "value1");

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo("RootElement/ChildElement"));
    }

    [Test]
    public void BuildingCondition_WithNullAttributeName_DoesNotIncludeCondition()
    {
        var xpathBuilder = _xPathBuilder
            .Root("RootElement")
            .ChildNode("ChildElement")
            .WithAttribute(null, "value1");

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo("RootElement/ChildElement"));
    }

    [Test]
    public void BuildingCondition_WithNegativePosition_DoesIncludeCondition()
    {
        var xpathBuilder = _xPathBuilder
            .Root("RootElement")
            .ChildNode("ChildElement")
            .AtPosition(-2);

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo("RootElement/ChildElement[position()=-2]"));
    }

    [Test]
    public void BuildingCondition_WithZeroPosition_DoesIncludeCondition()
    {
        var xpathBuilder = _xPathBuilder
            .Root("RootElement")
            .ChildNode("ChildElement")
            .AtPosition(0);

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo("RootElement/ChildElement[position()=0]"));
    }

    [Test]
    public void BuildingCondition_WithEmptyNodeName_DoesNotIncludeCondition()
    {
        var xpathBuilder = _xPathBuilder
            .Root("RootElement")
            .ChildNode("ChildElement")
            .NodeHasName(string.Empty);

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo("RootElement/ChildElement"));
    }

    [Test]
    public void BuildingCondition_WithNullNodeName_DoesNotIncludeCondition()
    {
        var xpathBuilder = _xPathBuilder
            .Root("RootElement")
            .ChildNode("ChildElement")
            .NodeHasName(null);

        var xpath = xpathBuilder.Build();

        Assert.That(xpath, Is.EqualTo("RootElement/ChildElement"));
    }
}
