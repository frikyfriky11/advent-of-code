namespace AdventOfCode.Year2021.Day10;

public sealed class Problem : IProblem
{
  public string Name => "Syntax Scoring";

  public string Part1(string input)
  {
    IEnumerable<string> lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

    int roundedBrackets = 0;
    int squareBrackets = 0;
    int curlyBrackets = 0;
    int angleBrackets = 0;

    foreach (string line in lines)
    {
      List<Token> tokens = new()
      {
        new Token(line[0]),
      };

      for (int i = 1; i < line.Length; i++)
      {
        char c = line[i];

        if (c is '(' or '[' or '{' or '<')
        {
          tokens.Add(new Token(c));
          continue;
        }

        Token lastToken = tokens.Last(x => x.End == null);

        if (c == ')' && lastToken.Start != '(')
        {
          roundedBrackets += 1;
          break;
        }

        if (c == ']' && lastToken.Start != '[')
        {
          squareBrackets += 1;
          break;
        }

        if (c == '}' && lastToken.Start != '{')
        {
          curlyBrackets += 1;
          break;
        }

        if (c == '>' && lastToken.Start != '<')
        {
          angleBrackets += 1;
          break;
        }

        lastToken.End = c;
      }
    }

    return (roundedBrackets * 3 + squareBrackets * 57 + curlyBrackets * 1197 + angleBrackets * 25137).ToString();
  }

  public string Part2(string input)
  {
    IEnumerable<string> lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

    List<long> lineScores = new();

    foreach (string line in lines)
    {
      List<Token> tokens = new()
      {
        new Token(line[0]),
      };

      bool corruptedLine = false;

      for (int i = 1; i < line.Length; i++)
      {
        char c = line[i];

        if (c is '(' or '[' or '{' or '<')
        {
          tokens.Add(new Token(c));
          continue;
        }

        Token lastToken = tokens.Last(x => x.End == null);

        if (c == ')' && lastToken.Start != '(')
        {
          corruptedLine = true;
          break;
        }

        if (c == ']' && lastToken.Start != '[')
        {
          corruptedLine = true;
          break;
        }

        if (c == '}' && lastToken.Start != '{')
        {
          corruptedLine = true;
          break;
        }

        if (c == '>' && lastToken.Start != '<')
        {
          corruptedLine = true;
          break;
        }

        lastToken.End = c;
      }

      if (corruptedLine)
      {
        continue;
      }

      long lineScore = 0;

      foreach (Token token in tokens.Where(x => x.End == null).Reverse())
      {
        if (token.Start == '(')
        {
          lineScore = lineScore * 5 + 1;
        }

        if (token.Start == '[')
        {
          lineScore = lineScore * 5 + 2;
        }

        if (token.Start == '{')
        {
          lineScore = lineScore * 5 + 3;
        }

        if (token.Start == '<')
        {
          lineScore = lineScore * 5 + 4;
        }
      }

      lineScores.Add(lineScore);
    }

    return lineScores.OrderBy(x => x).ToList()[lineScores.Count / 2].ToString();
  }

  private class Token
  {
    public Token(char start)
    {
      Start = start;
    }

    public char Start { get; }

    public char? End { get; set; }

    public override string ToString()
    {
      return $"Start: {Start} - End: {End?.ToString() ?? "none"}";
    }
  }
}
