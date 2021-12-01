using AdventOfCode;
using System.Reflection;

List<Type> problemTypes = Assembly
  .GetExecutingAssembly()
  .GetTypes()
  .Where(t => t.IsClass)
  .Where(t => t.IsAssignableTo(typeof(IProblem)))
  .OrderBy(t => t.Namespace)
  .ToList();

foreach (Type problemType in problemTypes)
{
  string[] namespaceParts = problemType.Namespace!.Split('.');

  string baseDir = Path.GetDirectoryName(problemType.Assembly.Location)!;

  string year = namespaceParts.First(x => x.StartsWith("Year"));
  int numericYear = int.Parse(year.Split("Year")[1]);

  string day = namespaceParts.First(x => x.StartsWith("Day"));
  int numericDay = int.Parse(day.Split("Day")[1]);

  string inputPath = Path.Combine(baseDir, year, day, "input.txt");

  string input = File.ReadAllText(inputPath);

  IProblem problem = (IProblem)Activator.CreateInstance(problemType)!;

  Console.ForegroundColor = ConsoleColor.White;
  Console.WriteLine($"AoC {numericYear} - Day {numericDay} - {problem.Name}");
  Console.ResetColor();

  try
  {
    string part1Solution = problem.Part1(input);
    Console.Write("Part 1 solution: ");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(part1Solution);
    Console.ResetColor();
  }
  catch (Exception ex)
  {
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Part 1 error: {ex}");
    Console.ResetColor();
  }

  try
  {
    string part2Solution = problem.Part2(input);
    Console.Write("Part 2 solution: ");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(part2Solution);
    Console.ResetColor();
  }
  catch (Exception ex)
  {
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Part 2 error: {ex}");
    Console.ResetColor();
  }
  
  Console.WriteLine("---");
}
