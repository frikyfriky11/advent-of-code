namespace AdventOfCode.Year2020.Day02;

public sealed class Problem : IProblem
{
  public string Name => "Password Philosophy";

  public string Part1(string input)
  {
    IEnumerable<string> lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

    int validPasswords = 0;

    foreach (string line in lines)
    {
      int min = int.Parse(line.Split('-')[0]);
      int max = int.Parse(line.Split('-')[1].Split(' ')[0]);
      char letter = line.Split(' ')[1].Split(':')[0][0];
      string password = new(line.Split(':')[1].Skip(1).ToArray());

      int validLettersInPassword = password.Count(x => x == letter);

      if (validLettersInPassword >= min && validLettersInPassword <= max)
      {
        validPasswords++;
      }
    }

    return validPasswords.ToString();
  }

  public string Part2(string input)
  {
    IEnumerable<string> lines = input.Split("\n").Where(l => !string.IsNullOrWhiteSpace(l));

    int validPasswords = 0;

    foreach (string line in lines)
    {
      int pos1 = int.Parse(line.Split('-')[0]);
      int pos2 = int.Parse(line.Split('-')[1].Split(' ')[0]);
      char letter = line.Split(' ')[1].Split(':')[0][0];
      string password = new(line.Split(':')[1].Skip(1).ToArray());

      char pos1Char = password.ElementAt(pos1 - 1);
      char pos2Char = password.ElementAt(pos2 - 1);

      if ((pos1Char == letter) ^ (pos2Char == letter))
      {
        validPasswords++;
      }
    }

    return validPasswords.ToString();
  }
}
