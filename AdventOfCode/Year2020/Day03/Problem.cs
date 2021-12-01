namespace AdventOfCode.Year2020.Day03;

public sealed class Problem : IProblem
{
  public string Name => "Toboggan Trajectory";

  public string Part1(string input)
  {
    return CountTrees(input, 3, 1).ToString();
  }

  public string Part2(string input)
  {
    long a = CountTrees(input, 1, 1);
    long b = CountTrees(input, 3, 1);
    long c = CountTrees(input, 5, 1);
    long d = CountTrees(input, 7, 1);
    long e = CountTrees(input, 1, 2);

    long result = a * b * c * d * e;

    return result.ToString();
  }

  private static long CountTrees(string input, int x, int y)
  {
    string[] map = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries).ToArray();

    // total line width before repetition occurs
    int lineWidth = map[0].Length;

    // total number of lines
    int totalLines = map.Length;

    // number of trees found
    long trees = 0;

    // save the last position visited on the map
    (int x, int y) lastPos = (0, 0);

    do
    {
      // search the map scanning by line and "pacman-style" column
      char field = map[lastPos.y][lastPos.x % lineWidth];

      // it is a tree only if it is a hash sign
      bool isTree = field == '#';

      if (isTree)
      {
        // count the tree
        trees++;
      }

      lastPos.x += x;
      lastPos.y += y;
    } while (lastPos.y < totalLines);

    return trees;
  }
}
