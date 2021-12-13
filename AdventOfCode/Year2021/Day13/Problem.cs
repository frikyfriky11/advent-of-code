using System.Text;

namespace AdventOfCode.Year2021.Day13;

public sealed class Problem : IProblem
{
  public string Name => "Transparent Origami";

  public string Part1(string input)
  {
    IEnumerable<string> lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

    (List<(int x, int y)> points, List<(char axis, int value)> folds) = ParsePointsAndFolds(lines.ToList());

    List<(int x, int y)> foldedPoints = Fold(folds, points, 1);

    return foldedPoints.Count.ToString();
  }

  public string Part2(string input)
  {
    IEnumerable<string> lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

    (List<(int x, int y)> points, List<(char axis, int value)> folds) = ParsePointsAndFolds(lines.ToList());

    List<(int x, int y)> foldedPoints = Fold(folds, points);

    char[][] map = Enumerable.Range(0, foldedPoints.Max(p => p.y + 1))
      .Select(_ => Enumerable.Repeat(' ', foldedPoints.Max(p => p.x + 1)).ToArray())
      .ToArray();

    foreach ((int x, int y) in foldedPoints)
    {
      map[y][x] = '#';
    }

    StringBuilder builder = new(Environment.NewLine);

    foreach (char[] mapLine in map)
    {
      builder.AppendLine(new string(mapLine));
    }

    return builder.ToString();
  }

  private static List<(int x, int y)> Fold(List<(char axis, int value)> folds, List<(int x, int y)> points, int? times = null)
  {
    foreach ((char axis, int value) fold in times == null ? folds : folds.Take(times.Value))
    {
      if (fold.axis == 'y')
      {
        List<(int x, int y)> pointsAbove = points.Where(p => p.y <= fold.value).ToList();
        List<(int x, int y)> pointsBelow = points.Where(p => p.y > fold.value).ToList();

        for (int i = 0; i < pointsBelow.Count; i++)
        {
          int newX = pointsBelow[i].x;
          int newY = Math.Abs(pointsBelow[i].y - fold.value * 2);

          if (!pointsAbove.Any(p => p.x == newX && p.y == newY))
          {
            pointsAbove.Add((newX, newY));
          }
        }

        points = pointsAbove;
      }
      else if (fold.axis == 'x')
      {
        List<(int x, int y)> pointsLeft = points.Where(p => p.x <= fold.value).ToList();
        List<(int x, int y)> pointsRight = points.Where(p => p.x > fold.value).ToList();

        for (int i = 0; i < pointsRight.Count; i++)
        {
          int newX = Math.Abs(pointsRight[i].x - fold.value * 2);
          int newY = pointsRight[i].y;

          if (!pointsLeft.Any(p => p.x == newX && p.y == newY))
          {
            pointsLeft.Add((newX, newY));
          }
        }

        points = pointsLeft;
      }
    }

    return points;
  }

  private static (List<(int x, int y)> points, List<(char axis, int value)> folds) ParsePointsAndFolds(List<string> lines)
  {
    List<(int x, int y)> points = new();

    foreach (string line in lines)
    {
      if (line.Contains(','))
      {
        string x = line.Split(',')[0];
        string y = line.Split(',')[1];

        points.Add((int.Parse(x), int.Parse(y)));
      }
    }

    List<(char axis, int value)> folds = new();

    foreach (string line in lines)
    {
      if (line.StartsWith("fold along"))
      {
        char axis = line.Split('=')[0][^1];
        int value = int.Parse(line.Split('=')[1]);
        folds.Add((axis, value));
      }
    }

    return (points, folds);
  }
}
