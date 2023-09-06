using System.Text;

int[] player1 = new int[7];
int[] player2 = new int[7];
int[] player3 = new int[7];
int[] player4 = new int[7];
int[] dice = { 6, 5, 4, 3, 2, 1 };

int DiceRoll()
{
    Random dice = new Random();
    int diceRoll = dice.Next(1, 7);

    return diceRoll;
}

int Winner(int player1, int player2, int player3, int player4)
{

    return Math.Max(player1, Math.Max(player2, Math.Max(player3, player4)));
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

        int w = Winner(player1[round], player2[round], player3[round], player4[round]);
        if (player1[round] == w)
        {
            Console.WriteLine("First place: Player1");
        }
        if (player2[round] == w)
        {
            Console.WriteLine("First place: Player2");
        }
        if (player3[round] == w)
        {
            Console.WriteLine("First place: Player3");
        }
        if (player4[round] == w)
        {
            Console.WriteLine("First place: Player4");
        }

        Console.WriteLine();
        Console.ReadKey();
    }
}

Game();