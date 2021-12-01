using AdventOfCode.Year2021.Day01;
using NUnit.Framework;
using System.Text;

namespace AdventOfCode.Tests.Year2021.Day01;

[TestFixture]
public class ProblemTests
{
  [OneTimeSetUp]
  public void SetUp()
  {
    StringBuilder inputBuilder = new();
    inputBuilder.AppendLine("199");
    inputBuilder.AppendLine("200");
    inputBuilder.AppendLine("208");
    inputBuilder.AppendLine("210");
    inputBuilder.AppendLine("200");
    inputBuilder.AppendLine("207");
    inputBuilder.AppendLine("240");
    inputBuilder.AppendLine("269");
    inputBuilder.AppendLine("260");
    inputBuilder.AppendLine("263");

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
    const string expected = "7";
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
    const string expected = "5";
    Assert.That(result, Is.EqualTo(expected));
  }
}
