using RockPaperScissors;
using System;
using System.Linq;
using System.Security.Cryptography;

///////// debug /////////
//if (args.Length == 0)
//{
//    args = new string[] { "rock", "paper", "scissors", "lizard", "spock" };
//}
//////////////////////////

if (!isOddOrEmpty(args) || !isDistinct(args))
    return;

bool bEnd = false;

while (!bEnd)
{
    var crypt = new GenerateHMAC();
    var aiTurn = new Random().Next(args.Length);
    var hmacKey = crypt.HMACKey();
    var hmac = crypt.HMACValue(args[aiTurn], hmacKey);
    var helpTable = new GenerateTable(args);

    Console.WriteLine("HMAC: " + hmac + "\n");
    Console.WriteLine("Available Moves:");
    for (int i = 0; i < args.Length; i++)
    {
        Console.WriteLine(i + 1 + " - " + args[i]);
    }
    Console.WriteLine("0 - Exit");
    Console.WriteLine("? - Help");
    Console.Write("Enter your move: ");
    var userTurn = Console.ReadLine();

    if (userTurn == "0")
    {
        bEnd = true;
        continue;
    }
    if (userTurn == "?")
    {
        helpTable.PrintTable();
        continue;
    }

    if (!int.TryParse(userTurn, out int userTurnInt) || userTurnInt < 1 || userTurnInt > args.Length)
    {
        Console.WriteLine("Invalid input. Try again.");
        Console.WriteLine();
        continue;
    }

    Console.WriteLine("Your move: " + args[userTurnInt - 1]);
    Console.WriteLine("Computer move: " + args[aiTurn]);
    var calcResult = new CalcResult(args.Length);
    var result = calcResult.CalculatingResult(aiTurn, userTurnInt - 1);
    Console.WriteLine("\n" + result + "\n");


    Console.WriteLine("HMAC key: " + hmacKey + "\n");
    Console.WriteLine("Press any key to play again");
    Console.ReadKey();
    Console.Clear();

}
bool isOddOrEmpty(string[] args)
{
    if (args.Length < 3)
    {
        Console.WriteLine("Believe me, this game is not played with so few options. Write more!");
        return false;
    }

    if (args.Length % 2 == 0)
    {
        Console.WriteLine("No, it doesn't work that way. I need an odd number of options!");
        return false;
    }

    return true;
}

bool isDistinct(string[] args)
{
    if (args.Length != args.Distinct().Count())
    {
        Console.WriteLine("Error. Data must not be repeated.");
        return false;
    }
    return true;
} 
