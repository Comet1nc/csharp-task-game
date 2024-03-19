// See https://aka.ms/new-console-template for more information
using BowlingGame;

var game = new Game();

while (true)
{
  Console.WriteLine("Enter number of pins:");
  int rolls = GetIntFromUser();
  if (game.Roll(rolls))
  {
    break;
  }
}
Console.WriteLine("Total Score: " + game.GetScore());

static int GetIntFromUser()
{
  string input = Console.ReadLine();
  int number = 0;
  int.TryParse(input, out number);
  return number;
}