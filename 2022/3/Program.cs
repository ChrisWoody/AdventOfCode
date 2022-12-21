var input = File.ReadAllLines("puzzle-input.txt");

var partOnePriorities = input
    .SelectMany(x => x[..(x.Length / 2)].Intersect(x.Substring(x.Length / 2, x.Length / 2)).Distinct())
    .Select(GetPriority)
    .ToArray();

var partOne = partOnePriorities.Sum();

Console.WriteLine($"Part 1: {partOne}");

var partTwoPriorities = input
    .Chunk(3)
    .Select(x => x.First().Intersect(x.Skip(1).First()).Intersect(x.Skip(2).First())
        .Distinct()
        .GroupBy(e => e)
        .OrderByDescending(e => e.Count()).First().Key)
    .Select(GetPriority)
    .ToArray();

var partTwo = partTwoPriorities.Sum();

Console.WriteLine($"Part 2: {partTwo}");

static int GetPriority(char c)
{
    if (char.IsLower(c))
    {
        return c - 'a' + 1;
    }

    return c - 'A' + 27;
}