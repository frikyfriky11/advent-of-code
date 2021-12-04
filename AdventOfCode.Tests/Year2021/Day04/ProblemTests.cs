using AdventOfCode.Year2021.Day04;
using NUnit.Framework;
using System.Text;

namespace AdventOfCode.Tests.Year2021.Day04;

[TestFixture]
public class ProblemTests
{
  [OneTimeSetUp]
  public void SetUp()
  {
    StringBuilder inputBuilder = new();

    inputBuilder.AppendLine("7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1");
    inputBuilder.AppendLine("");
    inputBuilder.AppendLine("22 13 17 11  0");
    inputBuilder.AppendLine(" 8  2 23  4 24");
    inputBuilder.AppendLine("21  9 14 16  7");
    inputBuilder.AppendLine(" 6 10  3 18  5");
    inputBuilder.AppendLine(" 1 12 20 15 19");
    inputBuilder.AppendLine("");
    inputBuilder.AppendLine(" 3 15  0  2 22");
    inputBuilder.AppendLine(" 9 18 13 17  5");
    inputBuilder.AppendLine("19  8  7 25 23");
    inputBuilder.AppendLine("20 11 10 24  4");
    inputBuilder.AppendLine("14 21 16 12  6");
    inputBuilder.AppendLine("");
    inputBuilder.AppendLine("14 21 17 24  4");
    inputBuilder.AppendLine("10 16 15  9 19");
    inputBuilder.AppendLine("18  8 23 26 20");
    inputBuilder.AppendLine("22 11 13  6  5");
    inputBuilder.AppendLine(" 2  0 12  3  7");

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
    const string expected = "4512";
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
    const string expected = "1924";
    Assert.That(result, Is.EqualTo(expected));
  }
}
