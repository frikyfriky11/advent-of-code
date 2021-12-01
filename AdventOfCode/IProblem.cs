namespace AdventOfCode;

public interface IProblem
{
  string Name { get; }
  string Part1(string input);
  string Part2(string input);
}
