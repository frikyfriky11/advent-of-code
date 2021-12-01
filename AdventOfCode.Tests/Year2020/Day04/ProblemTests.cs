using AdventOfCode.Year2020.Day04;
using NUnit.Framework;
using System.Text;

namespace AdventOfCode.Tests.Year2020.Day04;

[TestFixture]
public class ProblemTests
{
  [OneTimeSetUp]
  public void SetUp()
  {
    StringBuilder inputBuilder = new();
    inputBuilder.AppendLine("ecl:gry pid:860033327 eyr:2020 hcl:#fffffd");
    inputBuilder.AppendLine("byr:1937 iyr:2017 cid:147 hgt:183cm");
    inputBuilder.AppendLine("");
    inputBuilder.AppendLine("iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884");
    inputBuilder.AppendLine("hcl:#cfa07d byr:1929");
    inputBuilder.AppendLine("");
    inputBuilder.AppendLine("hcl:#ae17e1 iyr:2013");
    inputBuilder.AppendLine("eyr:2024");
    inputBuilder.AppendLine("ecl:brn pid:760753108 byr:1931");
    inputBuilder.AppendLine("hgt:179cm");
    inputBuilder.AppendLine("");
    inputBuilder.AppendLine("hcl:#cfa07d eyr:2025 pid:166559648");
    inputBuilder.AppendLine("iyr:2011 ecl:brn hgt:59in");

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
    // // arrange
    // Problem problem = new();
    //
    // // act
    // string result = problem.Part2(_input);
    //
    // // assert
    // const string expected = "336";
    // Assert.That(result, Is.EqualTo(expected));
  }
}
