Advent of Code
==============

# Quick tour of the repo

- Inside [/AdventOfCode][main] you'll find a folder for each Year, named `Year20xx`
- For each year, you'll find a folder for each day, named `Dayxx`
- For each day, you'll find the `Problem.cs` file and the `input.txt` file for that specific day and year challenge
- Every `Problem` class implements the [`IProblem` interface][iproblem]
- Implementing this interface allows the main Console application to discover the Problem and add it to the playlist
- For each day and year, there is a corresponding Test class in the [/AdventOfCode.Tests][tests] folder
- Each corresponding test has a `SetUp` method which configures the test input (taken directly from the challenge
  example) and executes the tests for both parts of the same day

# What is Advent of Code?

Directly from the [Advent of Code][aoc] website:

Advent of Code is an Advent calendar of small programming puzzles for a variety of skill sets and skill levels that can
be solved in any programming language you like. People use them as a speed contest, interview prep, company training,
university coursework, practice problems, or to challenge each other.

You don't need a computer science background to participate - just a little programming knowledge and some problem
solving skills will get you pretty far. Nor do you need a fancy computer; every problem has a solution that completes in
at most 15 seconds on ten-year-old hardware.

[main]: /AdventOfCode
[iproblem]: /AdventOfCode/IProblem.cs
[tests]: /AdventOfCode.Tests
[aoc]: https://adventofcode.com/