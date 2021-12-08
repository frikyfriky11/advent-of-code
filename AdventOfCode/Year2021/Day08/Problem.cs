namespace AdventOfCode.Year2021.Day08;

public sealed class Problem : IProblem
{
  public string Name => "Seven Segment Search";

  public string Part1(string input)
  {
    IEnumerable<string> lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

    int result = 0;

    foreach (string line in lines)
    {
      List<string> outputValues = line.Split(" | ")[1].Split(" ").ToList();

      // search for 2 3 4 and 7 segments
      result += outputValues.Count(x => x.Length is 2 or 3 or 4 or 7);
    }

    return result.ToString();
  }

  public string Part2(string input)
  {
    IEnumerable<string> lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

    var results = new List<long>();

    foreach (string line in lines)
    {
      List<string> signalPatterns = line.Split(" | ")[0].Split(" ").ToList();
      List<string> outputValues = line.Split(" | ")[1].Split(" ").ToList();


      /*
       *    0:      1:      2:      3:      4:
       *   aaaa    ....    aaaa    aaaa    .... 
       *  b    c  .    c  .    c  .    c  b    c 
       *  b    c  .    c  .    c  .    c  b    c 
       *   ....    ....    dddd    dddd    dddd 
       *  e    f  .    f  e    .  .    f  .    f 
       *  e    f  .    f  e    .  .    f  .    f 
       *   gggg    ....    gggg    gggg    .... 
       *
       *    5:      6:      7:      8:      9:
       *   aaaa    aaaa    aaaa    aaaa    aaaa
       *  b    .  b    .  .    c  b    c  b    c
       *  b    .  b    .  .    c  b    c  b    c
       *   dddd    dddd    ....    dddd    dddd
       *  .    f  e    f  .    f  e    f  .    f
       *  .    f  e    f  .    f  e    f  .    f
       *   gggg    gggg    ....    gggg    gggg
       */

      // numZero -> 6 segments
      string numOne = signalPatterns.First(s => s.Length == 2);
      // numTwo -> 5 segments
      // numThree -> 5 segments
      string numFour = signalPatterns.First(s => s.Length == 4);
      // numFive -> 5 segments
      // numSix -> 6 segments
      string numSeven = signalPatterns.First(s => s.Length == 3);
      string numEight = signalPatterns.First(s => s.Length == 7);
      // numNine -> 6 segments

      List<string> numZeroAndSixAndNine = signalPatterns.Where(s => s.Length == 6).ToList();

      string numSix = numZeroAndSixAndNine
        .First(s => new string(s.Except(numOne.ToCharArray()).ToArray()).Length == 5);

      // // a is what is not in number 7 from 1
      // char a = numSeven.Except(numOne.ToCharArray()).First();

      List<string> numTwoAndThreeAndFive = signalPatterns.Where(s => s.Length == 5).ToList();

      // number 3 is the five segment one that contains both c and f
      string numThree = numTwoAndThreeAndFive.First(x => x.Contains(numOne.First()) && x.Contains(numOne.Last()));

      // number 2 and 5 are the remainders
      List<string> numTwoOrFive = numTwoAndThreeAndFive.Where(x => x != numThree).ToList();

      char e = numTwoOrFive
        .Select(x => x.Except(numThree.ToCharArray()).Except(numFour.ToCharArray()))
        .First(x => x.Any())
        .First();

      string numTwo = numTwoOrFive.First(x => x.Contains(e));
      string numFive = numTwoOrFive.First(x => !x.Contains(e));

      string numZero = numZeroAndSixAndNine.Where(x => x != numSix).First(x => x.Contains(e));
      string numNine = numZeroAndSixAndNine.Where(x => x != numSix).First(x => !x.Contains(e));

      List<char> outputValuesDecoded = new();

      foreach (string outputValue in outputValues)
      {
        if (numOne.All(outputValue.Contains) && numOne.Length == outputValue.Length)
        {
          outputValuesDecoded.Add('1');
        }
        else if (numTwo.All(outputValue.Contains) && numTwo.Length == outputValue.Length)
        {
          outputValuesDecoded.Add('2');
        }
        else if (numThree.All(outputValue.Contains) && numThree.Length == outputValue.Length)
        {
          outputValuesDecoded.Add('3');
        }
        else if (numFour.All(outputValue.Contains) && numFour.Length == outputValue.Length)
        {
          outputValuesDecoded.Add('4');
        }
        else if (numFive.All(outputValue.Contains) && numFive.Length == outputValue.Length)
        {
          outputValuesDecoded.Add('5');
        }
        else if (numSix.All(outputValue.Contains) && numSix.Length == outputValue.Length)
        {
          outputValuesDecoded.Add('6');
        }
        else if (numSeven.All(outputValue.Contains) && numSeven.Length == outputValue.Length)
        {
          outputValuesDecoded.Add('7');
        }
        else if (numEight.All(outputValue.Contains) && numEight.Length == outputValue.Length)
        {
          outputValuesDecoded.Add('8');
        }
        else if (numNine.All(outputValue.Contains) && numNine.Length == outputValue.Length)
        {
          outputValuesDecoded.Add('9');
        }
        else if (numZero.All(outputValue.Contains) && numZero.Length == outputValue.Length)
        {
          outputValuesDecoded.Add('0');
        }
      }

      results.Add(int.Parse(new string(outputValuesDecoded.ToArray())));
    }

    return results.Sum().ToString();
  }
}
