namespace AdventOfCode.Year2021.Day12;

public sealed class Problem : IProblem
{
  public string Name => "Passage Pathing";

  public string Part1(string input)
  {
    IEnumerable<string> lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

    Graph graph = new();

    foreach (string line in lines)
    {
      string from = line.Split('-')[0];
      string to = line.Split('-')[1];

      graph.AddEdge(from, to);
      graph.AddEdge(to, from);
    }

    List<List<string>> paths = graph.FindPaths(new List<string> { "start" });

    return paths.Count.ToString();
  }

  public string Part2(string input)
  {
    IEnumerable<string> lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

    Graph graph = new();

    foreach (string line in lines)
    {
      string from = line.Split('-')[0];
      string to = line.Split('-')[1];

      graph.AddEdge(from, to);
      graph.AddEdge(to, from);
    }

    graph.AdjacencyList = graph.AdjacencyList.ToDictionary(x => x.Key, x => x.Value.OrderBy(l => l).ToList());

    int paths = graph.CountPaths(new Stack<string>(new[] { "start" }), new Dictionary<string, int>());

    return paths.ToString();
  }

  private class Graph
  {
    public Dictionary<string, List<string>> AdjacencyList = new();

    public void AddEdge(string v1, string v2)
    {
      if (!AdjacencyList.ContainsKey(v1))
      {
        AdjacencyList[v1] = new List<string>();
      }

      AdjacencyList[v1].Add(v2);
    }

    // inspired by other player solution https://github.com/Heleor/aoc-2020/commit/80020f0b481b63bca3856640cb7ccf8a063c474a#diff-0344284f47f6167f5a7fc348fee61e523661ec6229816c923653f190f33062c1
    public List<List<string>> FindPaths(List<string> root)
    {
      List<List<string>> paths = new();

      string connection = root[^1];

      if (connection == "end")
      {
        return new List<List<string>> { root };
      }

      foreach (string i in AdjacencyList[connection])
      {
        if (i.All(char.IsUpper) || root.IndexOf(i) == -1)
        {
          foreach (List<string> path in FindPaths(new List<string>(root) { i }))
          {
            paths.Add(path);
          }
        }
      }

      return paths;
    }

    // inspired by other player solution https://github.com/Heleor/aoc-2020/commit/9087e968f4ed35f96b91ca5e091922bd6d6a7c06#
    public int CountPaths(Stack<string> prefix, Dictionary<string, int> counts)
    {
      int count = 0;

      string connection = prefix.First();

      if (connection == "end")
      {
        return 1;
      }

      foreach (string i in AdjacencyList[connection])
      {
        if (i == "start")
        {
          continue;
        }

        if (CanVisit(counts, i))
        {
          counts[i] = (counts.ContainsKey(i) ? counts[i] : 0) + 1;
          prefix.Push(i);
          count += CountPaths(prefix, counts);
          prefix.Pop();
          counts[i] = (counts.ContainsKey(i) ? counts[i] : 0) - 1;
        }
      }

      return count;
    }

    private bool CanVisit(Dictionary<string, int> counts, string node)
    {
      if (node.All(char.IsUpper))
      {
        return true;
      }

      if ((counts.ContainsKey(node) ? counts[node] : 0) == 0)
      {
        return true;
      }

      foreach (KeyValuePair<string, int> i in counts)
      {
        if (!i.Key.All(char.IsUpper) && counts[i.Key] > 1)
        {
          return false;
        }
      }

      return true;
    }
  }
}
