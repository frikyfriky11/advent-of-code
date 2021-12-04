namespace AdventOfCode.Year2021.Day02;

public sealed class Problem : IProblem
{
  public string Name => "Dive!";

  public string Part1(string input)
  {
    IEnumerable<string> lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
    var commands = lines.Select(x => new { Command = x.Split(" ")[0], Value = int.Parse(x.Split(" ")[1]) });

    int hor = 0;
    int depth = 0;

    foreach (var command in commands)
    {
      switch (command.Command)
      {
        case "forward":
          hor += command.Value;
          break;
        case "down":
          depth += command.Value;
          break;
        case "up":
          depth -= command.Value;
          break;
      }
    }

    return (hor * depth).ToString();
  }

  public string Part2(string input)
  {
    IEnumerable<string> lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
    var commands = lines.Select(x => new { Command = x.Split(" ")[0], Value = int.Parse(x.Split(" ")[1]) });

    int hor = 0;
    int depth = 0;
    int aim = 0;

    foreach (var command in commands)
    {
      switch (command.Command)
      {
        case "forward":
          hor += command.Value;
          depth += aim * command.Value;
          break;
        case "down":
          aim += command.Value;
          break;
        case "up":
          aim -= command.Value;
          break;
      }
    }

    return (hor * depth).ToString();
  }
}
