namespace AdventOfCode.Year2020.Day04;

public sealed class Problem : IProblem
{
  public string Name => "Passport Processing";

  private string? SplitOrNull(string input, string identifier)
  {
    var value = input.Split(identifier);

    return value.Length == 2 ? value[1].Split(' ')[0] : null;
  }

  public string Part1(string input)
  {
    string[] passportsLines = input.Split(new[] { "\r\n\r\n", "\r\r", "\n\n" }, StringSplitOptions.RemoveEmptyEntries).ToArray();

    List<Passport> passports = passportsLines
      .Select(p => new Passport
      {
        Byr = SplitOrNull(p, "byr"),
        Iyr = SplitOrNull(p, "iyr"),
        Eyr = SplitOrNull(p, "eyr"),
        Hgt = SplitOrNull(p, "hgt"),
        Hcl = SplitOrNull(p, "hcl"),
        Ecl = SplitOrNull(p, "ecl"),
        Pid = SplitOrNull(p, "pid"),
        Cid = SplitOrNull(p, "cid"),
      })
      .ToList();

    Func<Passport, bool> isValidPassport = passport =>
      passport.Byr != null &&
      passport.Iyr != null &&
      passport.Eyr != null &&
      passport.Hgt != null &&
      passport.Hcl != null &&
      passport.Ecl != null &&
      passport.Pid != null;

    return passports.Count(isValidPassport).ToString();
  }

  public string Part2(string input)
  {
    return "";
  }

  private class Passport
  {
    public string? Byr { get; set; }
    public string? Iyr { get; set; }
    public string? Eyr { get; set; }
    public string? Hgt { get; set; }
    public string? Hcl { get; set; }
    public string? Ecl { get; set; }
    public string? Pid { get; set; }
    public string? Cid { get; set; }
  }
}
