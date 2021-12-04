using AdventOfCode.Year2021.Day02;
using NUnit.Framework;
using System.Text;

namespace AdventOfCode.Tests.Year2021.Day02;

[TestFixture]
public class ProblemTests
{
  [OneTimeSetUp]
  public void SetUp()
  {
    StringBuilder inputBuilder = new();
    inputBuilder.AppendLine("forward 5");
    inputBuilder.AppendLine("down 5");
    inputBuilder.AppendLine("forward 8");
    inputBuilder.AppendLine("up 3");
    inputBuilder.AppendLine("down 8");
    inputBuilder.AppendLine("forward 2");

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
    const string expected = "150";
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
    const string expected = "900";
    Assert.That(result, Is.EqualTo(expected));
  }
}
