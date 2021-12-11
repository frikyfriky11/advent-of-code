namespace AdventOfCode.Year2021.Day11;

public sealed class Problem : IProblem
{
  public string Name => "Dumbo Octopus";

  public string Part1(string input)
  {
    IEnumerable<string> lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

    List<List<int>> map = lines.Select(l => l.Select(c => int.Parse(c.ToString())).ToList()).ToList();

    List<Octopus> octopuses = new();

    for (int row = 0; row < map.Count; row++)
    {
      for (int col = 0; col < map[row].Count; col++)
      {
        Octopus octopus = new()
        {
          Level = map[row][col],
          PosX = col,
          PosY = row,
        };

        octopuses.Add(octopus);
      }
    }

    int flashes = 0;

    for (int i = 0; i < 100; i++)
    {
      foreach (Octopus octopus in octopuses)
      {
        octopus.Level++;

        if (octopus.Level == 10)
        {
          IncreaseAdjacentOctopuses(octopus, octopuses);
        }
      }

      int currentStepFlashes = octopuses.Count(o => o.Level > 9);
      flashes += currentStepFlashes;

      foreach (Octopus octopus in octopuses.Where(octopus => octopus.Level > 9))
      {
        octopus.Level = 0;
      }
    }

    return flashes.ToString();
  }

  public string Part2(string input)
  {
    IEnumerable<string> lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

    List<List<int>> map = lines.Select(l => l.Select(c => int.Parse(c.ToString())).ToList()).ToList();

    List<Octopus> octopuses = new();

    for (int row = 0; row < map.Count; row++)
    {
      for (int col = 0; col < map[row].Count; col++)
      {
        Octopus octopus = new()
        {
          Level = map[row][col],
          PosX = col,
          PosY = row,
        };

        octopuses.Add(octopus);
      }
    }

    int? fullFlashingStep = null;

    int i = 0;

    while (true)
    {
      foreach (Octopus octopus in octopuses)
      {
        octopus.Level++;

        if (octopus.Level == 10)
        {
          IncreaseAdjacentOctopuses(octopus, octopuses);
        }
      }

      int currentStepFlashes = octopuses.Count(o => o.Level > 9);

      if (fullFlashingStep == null && currentStepFlashes == octopuses.Count)
      {
        fullFlashingStep = i + 1;
        break;
      }

      foreach (Octopus octopus in octopuses.Where(octopus => octopus.Level > 9))
      {
        octopus.Level = 0;
      }

      i++;
    }

    return fullFlashingStep.ToString()!;
  }

  private void IncreaseAdjacentOctopuses(Octopus octopus, List<Octopus> octopuses)
  {
    Octopus? topLeft = octopuses.FirstOrDefault(o => o.PosX == octopus.PosX - 1 && o.PosY == octopus.PosY - 1);
    Octopus? top = octopuses.FirstOrDefault(o => o.PosX == octopus.PosX && o.PosY == octopus.PosY - 1);
    Octopus? topRight = octopuses.FirstOrDefault(o => o.PosX == octopus.PosX + 1 && o.PosY == octopus.PosY - 1);
    Octopus? right = octopuses.FirstOrDefault(o => o.PosX == octopus.PosX + 1 && o.PosY == octopus.PosY);
    Octopus? bottomRight = octopuses.FirstOrDefault(o => o.PosX == octopus.PosX + 1 && o.PosY == octopus.PosY + 1);
    Octopus? bottom = octopuses.FirstOrDefault(o => o.PosX == octopus.PosX && o.PosY == octopus.PosY + 1);
    Octopus? bottomLeft = octopuses.FirstOrDefault(o => o.PosX == octopus.PosX - 1 && o.PosY == octopus.PosY + 1);
    Octopus? left = octopuses.FirstOrDefault(o => o.PosX == octopus.PosX - 1 && o.PosY == octopus.PosY);

    if (topLeft != null)
    {
      topLeft.Level++;

      if (topLeft.Level == 10)
      {
        IncreaseAdjacentOctopuses(topLeft, octopuses);
      }
    }

    if (top != null)
    {
      top.Level++;

      if (top.Level == 10)
      {
        IncreaseAdjacentOctopuses(top, octopuses);
      }
    }

    if (topRight != null)
    {
      topRight.Level++;

      if (topRight.Level == 10)
      {
        IncreaseAdjacentOctopuses(topRight, octopuses);
      }
    }

    if (right != null)
    {
      right.Level++;

      if (right.Level == 10)
      {
        IncreaseAdjacentOctopuses(right, octopuses);
      }
    }

    if (bottomRight != null)
    {
      bottomRight.Level++;

      if (bottomRight.Level == 10)
      {
        IncreaseAdjacentOctopuses(bottomRight, octopuses);
      }
    }

    if (bottom != null)
    {
      bottom.Level++;

      if (bottom.Level == 10)
      {
        IncreaseAdjacentOctopuses(bottom, octopuses);
      }
    }

    if (bottomLeft != null)
    {
      bottomLeft.Level++;

      if (bottomLeft.Level == 10)
      {
        IncreaseAdjacentOctopuses(bottomLeft, octopuses);
      }
    }

    if (left != null)
    {
      left.Level++;

      if (left.Level == 10)
      {
        IncreaseAdjacentOctopuses(left, octopuses);
      }
    }
  }

  public class Octopus
  {
    public int Level { get; set; }

    public int PosX { get; set; }

    public int PosY { get; set; }

    public override string ToString()
    {
      return $"Level {Level} - X: {PosX} Y: {PosY}";
    }
  }
}
