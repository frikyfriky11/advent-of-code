using AdventOfCode.Year2021.Day12;
using NUnit.Framework;
using System.Text;

namespace AdventOfCode.Tests.Year2021.Day12;

[TestFixture]
public class ProblemTests
{
  [OneTimeSetUp]
  public void SetUp()
  {
    StringBuilder inputBuilder = new();
    inputBuilder.AppendLine("start-A");
    inputBuilder.AppendLine("start-b");
    inputBuilder.AppendLine("A-c");
    inputBuilder.AppendLine("A-b");
    inputBuilder.AppendLine("b-d");
    inputBuilder.AppendLine("A-end");
    inputBuilder.AppendLine("b-end");

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
    const string expected = "10";
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
    const string expected = "36";
    Assert.That(result, Is.EqualTo(expected));
  }
}
