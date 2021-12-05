namespace AdventOfCode.Year2021.Day05;

public sealed class Problem : IProblem
{
  public string Name => "Hydrothermal Venture";

  public string Part1(string input)
  {
    IEnumerable<string> lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

    List<(int x, int y)> map = new();

    foreach (string line in lines)
    {
      string[] coords = line.Split(" -> ");
      int fromX = int.Parse(coords[0].Split(',')[0]);
      int fromY = int.Parse(coords[0].Split(',')[1]);
      int toX = int.Parse(coords[1].Split(',')[0]);
      int toY = int.Parse(coords[1].Split(',')[1]);

      if (fromX != toX && fromY != toY)
      {
        continue;
      }

      List<(int x, int y)> segments = new();

      if (fromX == toX)
      {
        int max = Math.Max(fromY, toY);
        int min = Math.Min(fromY, toY);

        for (int y = min; y <= max; y++)
        {
          segments.Add((fromX, y));
        }
      }

      if (fromY == toY)
      {
        int max = Math.Max(fromX, toX);
        int min = Math.Min(fromX, toX);

        for (int x = min; x <= max; x++)
        {
          segments.Add((x, fromY));
        }
      }

      map.AddRange(segments);
    }

    var overlaps = map.GroupBy(m => new { m.x, m.y });

    var result = overlaps.Where(x => x.Count() > 1);

    return result.Count().ToString();
  }

  public string Part2(string input)
  {
    IEnumerable<string> lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

    List<(int x, int y)> map = new();

    foreach (string line in lines)
    {
      string[] coords = line.Split(" -> ");
      int fromX = int.Parse(coords[0].Split(',')[0]);
      int fromY = int.Parse(coords[0].Split(',')[1]);
      int toX = int.Parse(coords[1].Split(',')[0]);
      int toY = int.Parse(coords[1].Split(',')[1]);

      List<(int x, int y)> segments = new();

      if (fromX != toX && fromY != toY)
      {
        if (fromX < toX)
        {
          // from left to right
          if (fromY < toY)
          {
            // from top to bottom
            for (int i = 0; i <= toY - fromY; i++)
            {
              segments.Add((fromX + i, fromY + i));
            }
          }
          else
          {
            // from bottom to top
            for (int i = 0; i <= fromY - toY; i++)
            {
              segments.Add((fromX + i, fromY - i));
            }
          }
        }
        else
        {
          // from right to left
          if (fromY < toY)
          {
            // from top to bottom
            for (int i = 0; i <= toY - fromY; i++)
            {
              segments.Add((fromX - i, fromY + i));
            }
          }
          else
          {
            // from bottom to top
            for (int i = 0; i <= fromY - toY; i++)
            {
              segments.Add((fromX - i, fromY - i));
            }
          }
        }
      }
      else if (fromX == toX)
      {
        int max = Math.Max(fromY, toY);
        int min = Math.Min(fromY, toY);

        for (int y = min; y <= max; y++)
        {
          segments.Add((fromX, y));
        }
      }
      else if (fromY == toY)
      {
        int max = Math.Max(fromX, toX);
        int min = Math.Min(fromX, toX);

        for (int x = min; x <= max; x++)
        {
          segments.Add((x, fromY));
        }
      }

      map.AddRange(segments);
    }

    var overlaps = map.GroupBy(m => new { m.x, m.y });

    var result = overlaps.Where(x => x.Count() > 1);

    return result.Count().ToString();
  }
}
