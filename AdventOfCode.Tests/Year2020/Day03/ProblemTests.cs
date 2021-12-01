using AdventOfCode.Year2020.Day03;
using NUnit.Framework;
using System.Text;

namespace AdventOfCode.Tests.Year2020.Day03;

[TestFixture]
public class ProblemTests
{
  [OneTimeSetUp]
  public void SetUp()
  {
    StringBuilder inputBuilder = new();
    inputBuilder.AppendLine("..##.......");
    inputBuilder.AppendLine("#...#...#..");
    inputBuilder.AppendLine(".#....#..#.");
    inputBuilder.AppendLine("..#.#...#.#");
    inputBuilder.AppendLine(".#...##..#.");
    inputBuilder.AppendLine("..#.##.....");
    inputBuilder.AppendLine(".#.#.#....#");
    inputBuilder.AppendLine(".#........#");
    inputBuilder.AppendLine("#.##...#...");
    inputBuilder.AppendLine("#...##....#");
    inputBuilder.AppendLine(".#..#...#.#");

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
    const string expected = "336";
    Assert.That(result, Is.EqualTo(expected));
  }
}
