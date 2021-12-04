namespace AdventOfCode.Year2021.Day03;

public sealed class Problem : IProblem
{
  public string Name => "Binary Diagnostic";

  public string Part1(string input)
  {
    IEnumerable<string> lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

    List<Bit> bits = new();

    foreach (string line in lines)
    {
      for (int i = 0; i < line.Length; i++)
      {
        char c = line[i];
        bits.Add(new Bit(i, c));
      }
    }

    string gamma = new(bits
      .GroupBy(b => b.Position)
      .Select(x => new { Zeroes = x.Count(b => b.C == '0'), Ones = x.Count(b => b.C == '1') })
      .Select(x => x.Zeroes > x.Ones ? '0' : '1')
      .ToArray());

    string epsilon = new(gamma.Select(g => g == '0' ? '1' : '0').ToArray());

    long gammaDecimal = Convert.ToInt64(gamma, 2);
    long epsilonDecimal = Convert.ToInt64(epsilon, 2);

    return (gammaDecimal * epsilonDecimal).ToString();
  }

  public string Part2(string input)
  {
    IEnumerable<string> lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

    int lineLength = lines.First().Length;

    List<string> oxygens = lines.ToList();

    int currentPos = 0;

    do
    {
      List<string> itemZeroes = oxygens.Where(x => x[currentPos] == '0').ToList();
      List<string> itemOnes = oxygens.Where(x => x[currentPos] == '1').ToList();

      if (itemOnes.Count() >= itemZeroes.Count())
      {
        oxygens = itemOnes;
      }
      else
      {
        oxygens = itemZeroes;
      }

      if (oxygens.Count() == 1)
      {
        break;
      }

      currentPos++;
    } while (currentPos <= lineLength);

    long oxygenDecimal = Convert.ToInt64(oxygens.First(), 2);

    List<string> co2s = lines.ToList();

    currentPos = 0;

    do
    {
      List<string> itemZeroes = co2s.Where(x => x[currentPos] == '0').ToList();
      List<string> itemOnes = co2s.Where(x => x[currentPos] == '1').ToList();

      if (itemOnes.Count() >= itemZeroes.Count())
      {
        co2s = itemZeroes;
      }
      else
      {
        co2s = itemOnes;
      }

      if (co2s.Count() == 1)
      {
        break;
      }

      currentPos++;
    } while (currentPos <= lineLength);

    long co2Decimal = Convert.ToInt64(co2s.First(), 2);

    return (oxygenDecimal * co2Decimal).ToString();
  }

  private class Bit
  {
    public Bit(int position, char c)
    {
      Position = position;
      C = c;
    }

    public int Position { get; }
    public char C { get; }
  }
}
