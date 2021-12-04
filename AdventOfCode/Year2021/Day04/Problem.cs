namespace AdventOfCode.Year2021.Day04;

public sealed class Problem : IProblem
{
  public string Name => "Giant Squid";

  public string Part1(string input)
  {
    IEnumerable<string> lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

    List<int> extractedNumbers = lines.First().Split(',').Select(int.Parse).ToList();

    List<Board> boards = new();

    Board currentBoard = new();

    foreach (string line in lines.Skip(2))
    {
      if (string.IsNullOrWhiteSpace(line))
      {
        boards.Add(currentBoard);
        currentBoard = new Board();
        continue;
      }

      IEnumerable<int> row = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);

      currentBoard.BoardNumbers.Add(row.Select(r => new BoardNumber { Number = r }).ToList());
    }

    int winningNumber = 0;

    foreach (int extractedNumber in extractedNumbers)
    {
      foreach (Board board in boards)
      {
        foreach (List<BoardNumber> boardNumberRow in board.BoardNumbers)
        {
          foreach (BoardNumber boardNumber in boardNumberRow)
          {
            if (boardNumber.Number == extractedNumber)
            {
              boardNumber.Marked = true;
            }
          }
        }
      }

      if (boards.Any(b => b.Winner))
      {
        winningNumber = extractedNumber;
        break;
      }
    }

    Board winningBoard = boards.First(b => b.Winner);

    int unmarkedBoardNumbers = winningBoard.BoardNumbers.Sum(r => r.Where(c => !c.Marked).Sum(c => c.Number));

    return (unmarkedBoardNumbers * winningNumber).ToString();
  }

  public string Part2(string input)
  {
    IEnumerable<string> lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

    List<int> extractedNumbers = lines.First().Split(',').Select(int.Parse).ToList();

    List<Board> boards = new();

    Board currentBoard = new();

    foreach (string line in lines.Skip(2))
    {
      if (string.IsNullOrWhiteSpace(line))
      {
        boards.Add(currentBoard);
        currentBoard = new Board();
        continue;
      }

      IEnumerable<int> row = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);

      currentBoard.BoardNumbers.Add(row.Select(r => new BoardNumber { Number = r }).ToList());
    }

    int lastWinningNumber = 0;

    List<Board> winningBoards = new List<Board>();

    foreach (int extractedNumber in extractedNumbers)
    {
      foreach (Board board in boards)
      {
        foreach (List<BoardNumber> boardNumberRow in board.BoardNumbers)
        {
          foreach (BoardNumber boardNumber in boardNumberRow)
          {
            if (boardNumber.Number == extractedNumber)
            {
              boardNumber.Marked = true;
            }
          }
        }
      }

      List<Board> roundWinners = boards
        .Where(b => !winningBoards.Select(wb => wb.Id).Contains(b.Id))
        .Where(b => b.Winner)
        .ToList();

      if (roundWinners.Any())
      {
        lastWinningNumber = extractedNumber;
        winningBoards.AddRange(roundWinners);
      }

      if (winningBoards.Count() == boards.Count())
      {
        break;
      }
    }

    Board winningBoard = winningBoards.Last();

    int unmarkedBoardNumbers = winningBoard.BoardNumbers.Sum(r => r.Where(c => !c.Marked).Sum(c => c.Number));

    return (unmarkedBoardNumbers * lastWinningNumber).ToString();
  }

  private class Board
  {
    public Guid Id { get; } = Guid.NewGuid();

    public List<List<BoardNumber>> BoardNumbers { get; } = new();

    public bool Winner
    {
      get
      {
        if (BoardNumbers.Any(r => r.All(c => c.Marked)))
        {
          return true;
        }

        for (int col = 0; col < 5; col++)
        {
          int winningRows = 0;

          for (int row = 0; row < 5; row++)
          {
            winningRows += BoardNumbers[row][col].Marked ? 1 : 0;
          }

          if (winningRows == 5)
          {
            return true;
          }
        }

        return false;
      }
    }
  }

  private class BoardNumber
  {
    public int Number { get; set; }

    public bool Marked { get; set; }

    public override string ToString()
    {
      return $"{Number} - YES";
    }
  }
}
