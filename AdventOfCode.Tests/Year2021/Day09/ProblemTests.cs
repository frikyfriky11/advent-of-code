using AdventOfCode.Year2021.Day09;
using NUnit.Framework;
using System.Text;

namespace AdventOfCode.Tests.Year2021.Day09;

[TestFixture]
public class ProblemTests
{
  [OneTimeSetUp]
  public void SetUp()
  {
    StringBuilder inputBuilder = new();
    inputBuilder.AppendLine("2199943210");
    inputBuilder.AppendLine("3987894921");
    inputBuilder.AppendLine("9856789892");
    inputBuilder.AppendLine("8767896789");
    inputBuilder.AppendLine("9899965678");

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
    const string expected = "15";
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
    const string expected = "1134";
    Assert.That(result, Is.EqualTo(expected));
  }
}
