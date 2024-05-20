# SafeFluentXPath

SafeFluentXPath is a library for building XPath expressions using a fluent API. It aims to provide a type-safe and intuitive way to construct complex XPath queries.

## Table of Contents
- [SafeFluentXPath](#safefluentxpath)
  - [Table of Contents](#table-of-contents)
  - [Installation](#installation)
  - [Usage](#usage)
    - [Building Simple XPath Expressions](#building-simple-xpath-expressions)
    - [Building Conditions](#building-conditions)
    - [Using Connectors](#using-connectors)
    - [Grouping Conditions](#grouping-conditions)
  - [Testing](#testing)
  - [Contributing](#contributing)
  - [License](#license)

## Installation

To install SafeFluentXPath, you can use NuGet Package Manager:

```sh
Install-Package SafeFluentXPath
```

## Usage

### Building Simple XPath Expressions

You can start building an XPath expression by creating an instance of XPathBuilder and then chaining methods to define elements and relationships.

```cs
using SafeFluentXPath.Abstraction.Api;
using SafeFluentXPath.Implementation.Api;

IXPath xPath = new XPathBuilder();

string xpath = xPath
    .Element("RootElement")
    .ChildElement("ChildElement")
    .Build();

Console.WriteLine(xpath); // Output: RootElement/ChildElement
```

### Building Conditions

You can add conditions to your XPath expressions to filter elements based on attributes, positions, or names.

```cs
string xpath = xPath
    .Element("RootElement")
    .ChildElement("ChildElement")
    .WithAttribute("attr", "value")
    .Build();

Console.WriteLine(xpath); // Output: RootElement/ChildElement[@attr='value']
```

### Using Connectors

Connectors (`And`, `Or`) can be used to combine multiple conditions.

```cs
string xpath = xPath
    .Element("RootElement")
    .ChildElement("ChildElement")
    .WithAttribute("attr1", "value1")
    .And()
    .WithAttribute("attr2", "value2")
    .Build();

Console.WriteLine(xpath); // Output: RootElement/ChildElement[@attr1='value1' and @attr2='value2']
```

### Grouping Conditions

You can group conditions using `StartGroupCondition` and `EndConditionGroup` methods to create complex logical expressions.

```cs
string xpath = xPath
    .Element("RootElement")
    .ChildElement("ChildElement")
    .StartGroupCondition()
    .WithAttribute("attr1", "value1")
    .Or()
    .WithAttribute("attr2", "value2")
    .EndConditionGroup()
    .Build();

Console.WriteLine(xpath); // Output: RootElement/ChildElement[(@attr1='value1' or @attr2='value2')]
```

## Testing

To run the tests for SafeFluentXPath, use the following command:
```sh
dotnet test
```

The tests are written using NUnit and can be found in the `XPathBuilderTests.cs` file.

## Contributing

Contributions are welcome! Please feel free to submit a pull request or open an issue.

1. Fork the repository.
2. Create your feature branch: git checkout -b feature/YourFeature.
3. Commit your changes: git commit -am 'Add some feature'.
4. Push to the branch: git push origin feature/YourFeature.
5. Open a pull request.

## License

This project is licensed under the MIT License. See the LICENSE file for details.