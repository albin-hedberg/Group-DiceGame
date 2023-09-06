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

int Winner(int x, int y, int z, int w)
{
    int winner = Math.Max(w, Math.Max(x, Math.Max(y, z)));
    return winner;
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

        // Skriv ut alla tärningskast
        Console.WriteLine("Player1: " + player1[round]);
        Console.WriteLine("Player2: " + player2[round]);
        Console.WriteLine("Player3: " + player3[round]);
        Console.WriteLine("Player4: " + player4[round]);

        Console.WriteLine(Winner(player1[round], player2[round], player3[round], player4[round]));

        Console.WriteLine();
        Console.ReadKey();
    }
}


Game();