var input = File.ReadAllText("puzzle-input.txt");

var index = GetFirstStartOfMarkerIndex(input, 4);

var partOne = index;

Console.WriteLine($"Part 1: {partOne}");

index = GetFirstStartOfMarkerIndex(input, 14);

var partTwo = index;

Console.WriteLine($"Part 2: {partTwo}");

// mimic receiving chars one at a time, could use queue too
int GetFirstStartOfMarkerIndex(string stream, int uniqueCharacterCount)
{
    var chars = new char[uniqueCharacterCount];
    var initialised = false;
    var index1 = 1;

    foreach (var received in stream)
    {
        if (!initialised)
        {
            for (var i = 0; i < chars.Length; i++) chars[i] = received;
            initialised = true;
        }

        for (var i = 0; i < chars.Length; i++)
        {
            if (i + 1 >= chars.Length)
                chars[i] = received;
            else
                chars[i] = chars[i + 1];
        }

        if (chars.Distinct().Count() == uniqueCharacterCount)
            break;

        index1++;
    }

    return index1;
}