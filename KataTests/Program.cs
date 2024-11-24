// See https://aka.ms/new-console-template for more information
using KataTests;

Console.WriteLine("Noughts and Crosses, or Tic-Tac-Toe");
Console.WriteLine("------------------------------------------------");
Console.WriteLine();
KataMethods kataMethods = new KataMethods();
for (int i = 0; i < 10; i++)
{
    char c;
    if (i % 2 == 0)
        c = 'X';
    else c = 'O';
    int nextPosition = kataMethods.GetPosition();   
    while (kataMethods.board[nextPosition].HasValue)
    {
        nextPosition = kataMethods.GetPosition();
    }
    Console.WriteLine($"Checking pos {nextPosition} for {c}");
    kataMethods.board[nextPosition] = c;
    var displayBoard = kataMethods.DisplayBoard();
    foreach (string displayLine in displayBoard) {
        Console.WriteLine(displayLine);
            }
    var result = kataMethods.CheckBoard();
    if (result.HasValue)
    {
        Console.WriteLine($"The winning player is {result} in {i} goes");
        break;
    }
}
Console.ReadLine();