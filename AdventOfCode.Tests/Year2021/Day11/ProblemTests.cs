using AdventOfCode.Year2021.Day11;
using NUnit.Framework;
using System.Text;

namespace AdventOfCode.Tests.Year2021.Day11;

[TestFixture]
public class ProblemTests
{
  [OneTimeSetUp]
  public void SetUp()
  {
    StringBuilder inputBuilder = new();
    inputBuilder.AppendLine("5483143223");
    inputBuilder.AppendLine("2745854711");
    inputBuilder.AppendLine("5264556173");
    inputBuilder.AppendLine("6141336146");
    inputBuilder.AppendLine("6357385478");
    inputBuilder.AppendLine("4167524645");
    inputBuilder.AppendLine("2176841721");
    inputBuilder.AppendLine("6882881134");
    inputBuilder.AppendLine("4846848554");
    inputBuilder.AppendLine("5283751526");

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
    const string expected = "1656";
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
    const string expected = "195";
    Assert.That(result, Is.EqualTo(expected));
  }
}
