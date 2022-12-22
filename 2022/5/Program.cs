var input = File.ReadAllLines("puzzle-input.txt");

var stacks = Enumerable.Range(0, 9)
    .Select(y => new Stack<char>(Enumerable.Range(0, 8)
        .Select(x => input[x][y * 4 + 1]).Where(x => x != ' ').Reverse())).ToArray();

foreach (var line in input.Skip(10))
{
    var offset = line.Length == 19 ? 1 : 0;

    var count = int.Parse(line.Substring(5, 1 + offset).Trim());
    var oldStack = int.Parse(line[12 + offset].ToString()) - 1;
    var newStack = int.Parse(line[17 + offset].ToString()) - 1;

    for (var i = 0; i < count; i++)
        stacks[newStack].Push(stacks[oldStack].Pop());
}

var partOne = new string(stacks.Select(x => x.Peek()).ToArray());

Console.WriteLine($"Part 1: {partOne}");

stacks = Enumerable.Range(0, 9)
    .Select(y => new Stack<char>(Enumerable.Range(0, 8)
        .Select(x => input[x][y * 4 + 1]).Where(x => x != ' ').Reverse())).ToArray();


foreach (var line in input.Skip(10))
{
    var offset = line.Length == 19 ? 1 : 0;

    var count = int.Parse(line.Substring(5, 1 + offset).Trim());
    var oldStack = int.Parse(line[12 + offset].ToString()) - 1;
    var newStack = int.Parse(line[17 + offset].ToString()) - 1;

    var craneStack = new Stack<char>();
    for (var i = 0; i < count; i++)
        craneStack.Push(stacks[oldStack].Pop());

    for (var i = 0; i < count; i++)
        stacks[newStack].Push(craneStack.Pop());
}

var partTwo = new string(stacks.Select(x => x.Peek()).ToArray());

Console.WriteLine($"Part 2: {partTwo}");