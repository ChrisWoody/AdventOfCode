var input = File.ReadAllLines("puzzle-input.txt");

var moves = input.Select(ParseMovesPartOne).Select(g => new {g.playerMove, g.opponentMove, Score = ComputeScorePartOne(g.opponentMove, g.playerMove)});

var partOne = moves.Sum(x => x.Score);

Console.WriteLine($"Part 1: {partOne}");

var partTwoMoves = input.Select(ParseMovesPartTwo).Select(g => ComputeScorePartTwo(g.opponentMove, g.result));

var partTwo = partTwoMoves.Sum();

Console.WriteLine($"Part 2: {partTwo}");

Move ParseMove(char c)
{
    return c switch
    {
        'A' => Move.Rock,
        'X' => Move.Rock,
        'B' => Move.Paper,
        'Y' => Move.Paper,
        'C' => Move.Scissors,
        'Z' => Move.Scissors,
        _ => throw new ArgumentException(nameof(c))
    };
}

(Move opponentMove, Move playerMove) ParseMovesPartOne(string game)
{
    return (ParseMove(game[0]), ParseMove(game[2]));
}

int ComputeScorePartOne(Move opponentMove, Move playerMove)
{
    if (playerMove == opponentMove)
        return (int) playerMove + 3;

    return playerMove switch
    {
        Move.Rock when opponentMove == Move.Paper => (int) Move.Rock,
        Move.Rock when opponentMove == Move.Scissors => (int) Move.Rock + 6,
        Move.Scissors when opponentMove == Move.Rock => (int) Move.Scissors,
        Move.Scissors when opponentMove == Move.Paper => (int) Move.Scissors + 6,
        Move.Paper when opponentMove == Move.Scissors => (int) Move.Paper,
        Move.Paper when opponentMove == Move.Rock => (int) Move.Paper + 6,
        _ => throw new ArgumentException(nameof(playerMove))
    };
}

(Move opponentMove, Result result) ParseMovesPartTwo(string game)
{
    return (ParseMove(game[0]), ParseResult(game[2]));
}

int ComputeScorePartTwo(Move opponentMove, Result result)
{
    if (result == Result.Draw)
        return (int) opponentMove + (int) result;

    var beforeResult = opponentMove switch
    {
        Move.Rock when result == Result.Lose => (int) Move.Scissors,
        Move.Rock when result == Result.Win => (int) Move.Paper,
        Move.Paper when result == Result.Lose => (int) Move.Rock,
        Move.Paper when result == Result.Win => (int) Move.Scissors,
        Move.Scissors when result == Result.Lose => (int) Move.Paper,
        Move.Scissors when result == Result.Win => (int) Move.Rock,
        _ => throw new ArgumentOutOfRangeException(nameof(opponentMove))
    };

    return beforeResult + (int) result;
}

Result ParseResult(char c)
{
    return c switch
    {
        'X' => Result.Lose,
        'Y' => Result.Draw,
        'Z' => Result.Win,
        _ => throw new ArgumentException(nameof(c))
    };
}

public enum Move
{
    Rock = 1,
    Paper = 2,
    Scissors = 3
}

public enum Result
{
    Lose = 0,
    Draw = 3,
    Win = 6
}