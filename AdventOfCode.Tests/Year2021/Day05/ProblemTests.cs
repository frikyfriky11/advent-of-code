using AdventOfCode.Year2021.Day05;
using NUnit.Framework;
using System.Text;

namespace AdventOfCode.Tests.Year2021.Day05;

[TestFixture]
public class ProblemTests
{
  [OneTimeSetUp]
  public void SetUp()
  {
    StringBuilder inputBuilder = new();
    inputBuilder.AppendLine("0,9 -> 5,9");
    inputBuilder.AppendLine("8,0 -> 0,8");
    inputBuilder.AppendLine("9,4 -> 3,4");
    inputBuilder.AppendLine("2,2 -> 2,1");
    inputBuilder.AppendLine("7,0 -> 7,4");
    inputBuilder.AppendLine("6,4 -> 2,0");
    inputBuilder.AppendLine("0,9 -> 2,9");
    inputBuilder.AppendLine("3,4 -> 1,4");
    inputBuilder.AppendLine("0,0 -> 8,8");
    inputBuilder.AppendLine("5,5 -> 8,2");

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
    const string expected = "5";
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
    const string expected = "12";
    Assert.That(result, Is.EqualTo(expected));
  }
}
