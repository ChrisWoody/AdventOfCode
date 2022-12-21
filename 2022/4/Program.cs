var input = File.ReadAllLines("puzzle-input.txt");

var partOnes = input.Select(x =>
    {
        var split = x.Split(',', '-');
        var leftMin = int.Parse(split[0]);
        var leftMax = int.Parse(split[1]);
        var rightMin = int.Parse(split[2]);
        var rightMax = int.Parse(split[3]);

        var leftDiff = leftMax - leftMin;
        var rightDiff = rightMax - rightMin;
        return leftDiff < rightDiff
            ? leftMin >= rightMin && leftMax <= rightMax
            : rightMin >= leftMin && rightMax <= leftMax;
    })
    .ToArray();

var partOne = partOnes.Count(b => b);

Console.WriteLine($"Part 1: {partOne}");

var partTwos = input.Select(x =>
    {
        var split = x.Split(',', '-');
        var leftMin = int.Parse(split[0]);
        var leftMax = int.Parse(split[1]);
        var rightMin = int.Parse(split[2]);
        var rightMax = int.Parse(split[3]);

        return (leftMin >= rightMin && leftMin <= rightMax)
               || (leftMax >= rightMin && leftMax <= rightMax)
               || (rightMin >= leftMin && rightMin <= leftMax)
               || (rightMax >= leftMin && rightMax <= leftMax);
    })
    .ToArray();

var partTwo = partTwos.Count(b => b);

Console.WriteLine($"Part 2: {partTwo}");