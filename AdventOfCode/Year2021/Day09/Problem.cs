namespace AdventOfCode.Year2021.Day09;

public sealed class Problem : IProblem
{
  public string Name => "Smoke Basin";

  public string Part1(string input)
  {
    IEnumerable<string> lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

    int[][] matrix = lines.Select(l => l.Select(c => int.Parse(c.ToString())).ToArray()).ToArray();

    List<int> lowPoints = new();

    for (int row = 0; row < matrix.Length; row++)
    {
      for (int col = 0; col < matrix[row].Length; col++)
      {
        int current = matrix[row][col];

        int? top = row == 0 ? null : matrix[row - 1][col];
        int? bottom = row == matrix.Length - 1 ? null : matrix[row + 1][col];
        int? left = col == 0 ? null : matrix[row][col - 1];
        int? right = col == matrix[row].Length - 1 ? null : matrix[row][col + 1];

        bool lowerThanTop = current < (top ?? 10);
        bool lowerThanBottom = current < (bottom ?? 10);
        bool lowerThanLeft = current < (left ?? 10);
        bool lowerThanRight = current < (right ?? 10);

        if (lowerThanTop && lowerThanBottom && lowerThanLeft && lowerThanRight)
        {
          lowPoints.Add(current);
        }
      }
    }

    return lowPoints.Select(x => x + 1).Sum().ToString();
  }

  public string Part2(string input)
  {
    IEnumerable<string> lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

    int[][] matrix = lines.Select(l => l.Select(c => int.Parse(c.ToString())).ToArray()).ToArray();

    List<List<(int row, int col, int value)>> basins = new();
    List<(int row, int col, int value)> basinValues = new();

    void FloodFill(int value, int row, int col)
    {
      if (value == 9)
      {
        return;
      }

      if (basinValues.Any(x => x.row == row && x.col == col))
      {
        return;
      }

      basinValues.Add((row, col, value));

      int? top = row == 0 ? null : matrix[row - 1][col];
      int? bottom = row == matrix.Length - 1 ? null : matrix[row + 1][col];
      int? left = col == 0 ? null : matrix[row][col - 1];
      int? right = col == matrix[row].Length - 1 ? null : matrix[row][col + 1];

      if (top != null)
      {
        FloodFill(top.Value, row - 1, col);
      }

      if (bottom != null)
      {
        FloodFill(bottom.Value, row + 1, col);
      }

      if (left != null)
      {
        FloodFill(left.Value, row, col - 1);
      }

      if (right != null)
      {
        FloodFill(right.Value, row, col + 1);
      }
    }

    for (int row = 0; row < matrix.Length; row++)
    {
      for (int col = 0; col < matrix[row].Length; col++)
      {
        if (basins.Any(x => x.Any(y => y.row == row && y.col == col)))
        {
          continue;
        }

        FloodFill(matrix[row][col], row, col);

        basins.Add(basinValues);
        basinValues = new List<(int row, int col, int value)>();
      }
    }

    IEnumerable<List<(int row, int col, int value)>> top3Basins = basins.OrderByDescending(x => x.Count).Take(3);

    int result = 1;

    foreach (List<(int row, int col, int value)> top3Basin in top3Basins)
    {
      result *= top3Basin.Count;
    }

    return result.ToString();
  }
}
