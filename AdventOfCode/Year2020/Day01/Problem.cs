namespace AdventOfCode.Year2020.Day01;

public sealed class Problem : IProblem
{
  public string Name => "Report Repair";

  public string Part1(string input)
  {
    IEnumerable<string> lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
    List<int> numbers = lines.Select(int.Parse).ToList();

    foreach (int firstNumber in numbers)
    {
      foreach (int secondNumber in numbers)
      {
        if (firstNumber + secondNumber == 2020)
        {
          return (firstNumber * secondNumber).ToString();
        }
      }
    }

    throw new InvalidOperationException();
  }

  public string Part2(string input)
  {
    IEnumerable<string> lines = input.Split("\n").Where(l => !string.IsNullOrWhiteSpace(l));
    List<int> numbers = lines.Select(int.Parse).ToList();

    foreach (int firstNumber in numbers)
    {
      foreach (int secondNumber in numbers)
      {
        foreach (int thirdNumber in numbers)
        {
          if (firstNumber + secondNumber + thirdNumber == 2020)
          {
            return (firstNumber * secondNumber * thirdNumber).ToString();
          } 
        }
      }
    }

    throw new InvalidOperationException();
  }
}
