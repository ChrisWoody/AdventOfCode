var input = File.ReadAllText("puzzle-input.txt");

var partOne = input.Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Split("\r\n").Select(int.Parse).Sum()).MaxBy(x => x);

Console.WriteLine($"Part 1: {partOne}");

var partTwo = input.Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Split("\r\n").Select(int.Parse).Sum()).OrderByDescending(x => x).Take(3).Sum();

Console.WriteLine($"Part 2: {partTwo}");