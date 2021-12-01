namespace AdventOfCode.Year2021.Day01;

public sealed class Problem : IProblem
{
  public string Name => "Sonar Sweep";

  public string Part1(string input)
  {
    IEnumerable<string> lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
    List<int> numbers = lines.Select(int.Parse).ToList();

    int result = 0;

    int? previous = null;

    foreach (int number in numbers)
    {
      if (previous == null)
      {
        previous = number;
        continue;
      }

      if (number > previous)
      {
        result++;
      }

      previous = number;
    }

    return result.ToString();
  }

  public string Part2(string input)
  {
    IEnumerable<string> lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
    List<int> numbers = lines.Select(int.Parse).ToList();

    int result = 0;

    int? previous = null;

    for (int i = 0; i < numbers.Count - 2; i++)
    {
      int first = numbers[i];
      int second = numbers[i + 1];
      int third = numbers[i + 2];

      int sum = first + second + third;

      if (previous == null)
      {
        previous = sum;
        continue;
      }

      if (sum > previous)
      {
        result++;
      }

      previous = sum;
    }

    return result.ToString();
  }
}
