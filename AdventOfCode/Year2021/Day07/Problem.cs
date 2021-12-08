namespace AdventOfCode.Year2021.Day07;

public sealed class Problem : IProblem
{
  public string Name => "The Treachery of Whales";

  public string Part1(string input)
  {
    IEnumerable<string> lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

    List<int> positions = lines.First().Split(',').Select(int.Parse).ToList();

    int min = positions.Min();
    int max = positions.Max();

    Dictionary<int, List<int>> fuels = new();

    for (int i = min; i <= max; i++)
    {
      List<int> fuelRequired = new();

      foreach (int position in positions)
      {
        if (i < position)
        {
          // 16 -> 2
          fuelRequired.Add(position - i);
        }
        else if (i > position)
        {
          // 0 -> 2
          fuelRequired.Add(i - position);
        }
      }

      fuels.Add(i, fuelRequired);
    }

    return fuels.Min(f => f.Value.Sum()).ToString();
  }

  public string Part2(string input)
  {
    IEnumerable<string> lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

    List<int> positions = lines.First().Split(',').Select(int.Parse).ToList();

    int min = positions.Min();
    int max = positions.Max();

    Dictionary<int, List<int>> fuels = new();

    for (int i = min; i <= max; i++)
    {
      List<int> fuelRequired = new();

      foreach (int position in positions)
      {
        if (i < position)
        {
          // 16 -> 2
          fuelRequired.Add(CalculateFuel(position - i));
        }
        else if (i > position)
        {
          // 0 -> 2
          fuelRequired.Add(CalculateFuel(i - position));
        }
      }

      fuels.Add(i, fuelRequired);
    }

    return fuels.Min(f => f.Value.Sum()).ToString();
  }

  private int CalculateFuel(int value)
  {
    int result = 0;

    for (int i = 0; i <= value; i++)
    {
      result += i;
    }

    return result;
  }
}
