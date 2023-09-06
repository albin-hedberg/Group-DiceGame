int[] player1 = new int[7];
int[] player2 = new int[7];
int[] player3 = new int[7];
int[] player4 = new int[7];

int DiceRoll()
{
    Random dice = new Random();
    int diceRoll = dice.Next(1, 7);

    return diceRoll;
}

void Game()
{
    for (int round = 0; round < 6; round++)
    {
        Console.WriteLine("Current Round: " + (round + 1));
        player1[round] = DiceRoll();
        player2[round] = DiceRoll();
        player3[round] = DiceRoll();
        player4[round] = DiceRoll();


        Console.WriteLine("Player1: " + player1[round]);
        Console.WriteLine("Player2: " + player2[round]);
        Console.WriteLine("Player3: " + player3[round]);
        Console.WriteLine("Player4: " + player4[round]);

        // TODO: Skriv ut resultat

        Console.WriteLine();
        Console.ReadKey();
    }
}


Game();