using AdventOfCode.Year2020.Day02;
using NUnit.Framework;
using System.Text;

namespace AdventOfCode.Tests.Year2020.Day02;

[TestFixture]
public class ProblemTests
{
  [OneTimeSetUp]
  public void SetUp()
  {
    StringBuilder inputBuilder = new();
    inputBuilder.AppendLine("1-3 a: abcde");
    inputBuilder.AppendLine("1-3 b: cdefg");
    inputBuilder.AppendLine("2-9 c: ccccccccc");

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
    const string expected = "2";
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
    const string expected = "1";
    Assert.That(result, Is.EqualTo(expected));
  }
}
