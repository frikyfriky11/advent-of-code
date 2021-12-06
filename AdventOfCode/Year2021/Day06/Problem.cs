namespace AdventOfCode.Year2021.Day06;

public sealed class Problem : IProblem
{
  public string Name => "Hydrothermal Venture";

  public string Part1(string input)
  {
    IEnumerable<string> lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

    List<int> fishes = lines.First().Split(',').Select(int.Parse).ToList();

    for (int day = 0; day < 80; day++)
    {
      List<int> newFishes = new();

      for (int i = 0; i < fishes.Count; i++)
      {
        int fish = fishes[i];

        if (fish == 0)
        {
          newFishes.Add(8);
          fishes[i] = 6;
        }
        else
        {
          fishes[i] = fish - 1;
        }
      }

      fishes.AddRange(newFishes);
    }

    return fishes.Count().ToString();
  }

  public string Part2(string input)
  {
    IEnumerable<string> lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

    var fishes = lines
      .First()
      .Split(',')
      .Select(int.Parse)
      .GroupBy(l => l)
      .ToDictionary(g => g.Key, g => g.LongCount());

    for (int day = 0; day < 256; day++)
    {
      var newFishes = new Dictionary<int, long>();
      newFishes.Add(8, fishes.GetValueOrDefault(0));
      newFishes.Add(7, fishes.GetValueOrDefault(8));
      newFishes.Add(6, fishes.GetValueOrDefault(7) + fishes.GetValueOrDefault(0));
      newFishes.Add(5, fishes.GetValueOrDefault(6));
      newFishes.Add(4, fishes.GetValueOrDefault(5));
      newFishes.Add(3, fishes.GetValueOrDefault(4));
      newFishes.Add(2, fishes.GetValueOrDefault(3));
      newFishes.Add(1, fishes.GetValueOrDefault(2));
      newFishes.Add(0, fishes.GetValueOrDefault(1));

      fishes = newFishes;
    }

    return fishes.Values.Sum().ToString();
  }
}
