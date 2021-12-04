using AdventOfCode.Year2021.Day03;
using NUnit.Framework;
using System.Text;

namespace AdventOfCode.Tests.Year2021.Day03;

[TestFixture]
public class ProblemTests
{
  [OneTimeSetUp]
  public void SetUp()
  {
    StringBuilder inputBuilder = new();
    inputBuilder.AppendLine("00100");
    inputBuilder.AppendLine("11110");
    inputBuilder.AppendLine("10110");
    inputBuilder.AppendLine("10111");
    inputBuilder.AppendLine("10101");
    inputBuilder.AppendLine("01111");
    inputBuilder.AppendLine("00111");
    inputBuilder.AppendLine("11100");
    inputBuilder.AppendLine("10000");
    inputBuilder.AppendLine("11001");
    inputBuilder.AppendLine("00010");
    inputBuilder.AppendLine("01010");

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
    const string expected = "198";
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
    const string expected = "230";
    Assert.That(result, Is.EqualTo(expected));
  }
}
