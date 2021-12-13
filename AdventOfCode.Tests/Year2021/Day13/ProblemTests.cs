using AdventOfCode.Year2021.Day13;
using NUnit.Framework;
using System;
using System.Text;

namespace AdventOfCode.Tests.Year2021.Day13;

[TestFixture]
public class ProblemTests
{
  [OneTimeSetUp]
  public void SetUp()
  {
    StringBuilder inputBuilder = new();
    inputBuilder.AppendLine("6,10");
    inputBuilder.AppendLine("0,14");
    inputBuilder.AppendLine("9,10");
    inputBuilder.AppendLine("0,3");
    inputBuilder.AppendLine("10,4");
    inputBuilder.AppendLine("4,11");
    inputBuilder.AppendLine("6,0");
    inputBuilder.AppendLine("6,12");
    inputBuilder.AppendLine("4,1");
    inputBuilder.AppendLine("0,13");
    inputBuilder.AppendLine("10,12");
    inputBuilder.AppendLine("3,4");
    inputBuilder.AppendLine("3,0");
    inputBuilder.AppendLine("8,4");
    inputBuilder.AppendLine("1,10");
    inputBuilder.AppendLine("2,14");
    inputBuilder.AppendLine("8,10");
    inputBuilder.AppendLine("9,0");
    inputBuilder.AppendLine("");
    inputBuilder.AppendLine("fold along y=7");
    inputBuilder.AppendLine("fold along x=5");

    _input = inputBuilder.ToString();
  }

  private string _input = string.Empty;

  [Test]
  public void Part1Example()
  {
    // arrange
    Problem problem = new();

    // act
    string result = problem.Part1(_input);

    // assert
    const string expected = "17";
    Assert.That(result, Is.EqualTo(expected));
  }

  [Test]
  public void Part2Example()
  {
    // arrange
    Problem problem = new();

    // act
    string result = problem.Part2(_input);

    // assert
    StringBuilder builder = new(Environment.NewLine);
    builder.AppendLine("#####");
    builder.AppendLine("#   #");
    builder.AppendLine("#   #");
    builder.AppendLine("#   #");
    builder.AppendLine("#####");
    string expected = builder.ToString();
    Assert.That(result, Is.EqualTo(expected));
  }
}
