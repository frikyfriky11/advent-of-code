using AdventOfCode.Year2020.Day01;
using NUnit.Framework;
using System.Text;

namespace AdventOfCode.Tests.Year2020.Day01;

[TestFixture]
public class ProblemTests
{
  [OneTimeSetUp]
  public void SetUp()
  {
    StringBuilder inputBuilder = new();
    inputBuilder.AppendLine("1721");
    inputBuilder.AppendLine("979");
    inputBuilder.AppendLine("366");
    inputBuilder.AppendLine("299");
    inputBuilder.AppendLine("675");
    inputBuilder.AppendLine("1456");

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
    const string expected = "514579";
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
    const string expected = "241861950";
    Assert.That(result, Is.EqualTo(expected));
  }
}
