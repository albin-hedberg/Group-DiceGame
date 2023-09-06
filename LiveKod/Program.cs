﻿//using System.Text;

//int[] player1 = new int[7];
//int[] player2 = new int[7];
//int[] player3 = new int[7];
//int[] player4 = new int[7];
//int[] dice = { 6, 5, 4, 3, 2, 1 };

//int DiceRoll()
//{
//    Random dice = new Random();
//    int diceRoll = dice.Next(1, 7);

//    return diceRoll;
//}

//int Winner(int player1, int player2, int player3, int player4)
//{
//    int winner = Math.Max(player1, Math.Max(player2, Math.Max(player3, player4)));
//    Console.WriteLine("1: " + winner);
//    int second = Math.Min(player1, Math.Max(player2, Math.Max(player3, player4)));
//    Console.WriteLine("2: " + second);
//    int third = Math.Min(player1, Math.Min(player2, Math.Max(player3, player4)));
//    Console.WriteLine("3: " + third);
//    int last = Math.Min(player1, Math.Min(player2, Math.Min(player3, player4)));
//    Console.WriteLine("4: " + last);

//    return Math.Max(player1, Math.Max(player2, Math.Max(player3, player4)));
//}

//void Game()
//{
//    for (int round = 0; round < 6; round++)
//    {
//        Console.WriteLine("Current Round: " + (round + 1));
//        player1[round] = DiceRoll();
//        player2[round] = DiceRoll();
//        player3[round] = DiceRoll();
//        player4[round] = DiceRoll();

//        // Skriv ut alla tärningskast
//        Console.WriteLine("Player1: " + player1[round]);
//        Console.WriteLine("Player2: " + player2[round]);
//        Console.WriteLine("Player3: " + player3[round]);
//        Console.WriteLine("Player4: " + player4[round]);

//        int w = Winner(player1[round], player2[round], player3[round], player4[round]);
//        //if (player1[round] == w)
//        //{
//        //    Console.WriteLine("First place: Player1");
//        //}
//        //if (player2[round] == w)
//        //{
//        //    Console.WriteLine("First place: Player2");
//        //}
//        //if (player3[round] == w)
//        //{
//        //    Console.WriteLine("First place: Player3");
//        //}
//        //if (player4[round] == w)
//        //{
//        //    Console.WriteLine("First place: Player4");
//        //}

//        Console.WriteLine();
//        Console.ReadKey();
//    }
//}

//Game();


//int[,] players = new int[4,6]; // Spelare + runda
//int highestRoll = 0;        // Högsta kastet/runda
//int highestRollIndex = -1;  // Index på spelare med högsta kastet

//// Loopa 6 rundor
//for (int round = 0; round < 6; round++)
//{
//    Console.WriteLine("Current Round: " + (round + 1));

//    // Loopa ett kast för varje spelare
//    for (int currentPlayer = 0; currentPlayer < 4; currentPlayer++)
//    {
//        Random dice2 = new Random();
//        int diceRoll = dice2.Next(1, 7);

//        // Spara kastet för den nuvarande spelaren
//        players[currentPlayer, round] = diceRoll;

//        if (diceRoll > highestRoll)
//        {
//            highestRoll = diceRoll;
//            highestRollIndex = currentPlayer;
//        }

//        Console.WriteLine("Player" + (currentPlayer + 1) + ": " + diceRoll);
//    }

//    Console.WriteLine("Highest roll: " + highestRoll + ", by Player" + (highestRollIndex + 1));

//    // Återställ variabler för nästa runda
//    highestRoll = 0;
//    highestRollIndex = -1;

//    Console.WriteLine();
//}

int[] players = new int[4]; // Spelare 1-4
int[] scores = new int[4];  // Poäng (har samma index som spelarna)
int[] places = new int[4];  // Plats (1:a index är spelaren med högst kast, 2:a index är med näst högst, etc.)

// "En metod för att genomföra en omgång"
void Round()
{
    for (int currentPlayer = 0; currentPlayer < players.Length; currentPlayer++)
    {
        Random dice = new Random();
        int diceRoll = dice.Next(1, 7);

        players[currentPlayer] = diceRoll;
        Console.WriteLine("Player" + (currentPlayer + 1) + ": " + diceRoll);
    }
}

// "En metod för att avgöra omgångspoäng"
void Score()
{
    int highestRoll = 0;        // Högsta kastet
    int highestRollIndex = -1;  // Index av spelare med högst kast

    // Loopa igenom alla platser (First, Second, Third, etc.)
    for (int place = 0; place < places.Length; place++)
    {
        // Loopa igenom alla spelare
        for (int currentPlayer = 0; currentPlayer < players.Length; currentPlayer++)
        {
            // Om det nuvarande kastet är det högsta
            if (players[currentPlayer] > highestRoll)
            {
                highestRoll = players[currentPlayer];   // Spara värdet av högsta kastet
                highestRollIndex = currentPlayer;       // Spara index av spelaren
            }
        }

        // Spara index av spelaren med högst kast på nuvarande position i arrayen 'places'
        places[place] = highestRollIndex;
        // Återställ sedan spelarens kast till 0 för att nästa iteration av loopen ska få fram 2:a & 3:e plats, o.s.v.
        players[highestRollIndex] = 0;
        highestRoll = 0;
    }

    // TODO: Loop för att räknu ut poängen
}

// "En metod för att avgöra segraren av spelet"
void Winner()
{
    int highestScore = 0;        // Högsta kastet
    int highestScoreIndex = -1;  // Index av spelare med högst kast

    // Loopa igenom alla platser (First, Second, Third, etc.)
    for (int place = 0; place < places.Length; place++)
    {
        // Loopa igenom alla spelare
        for (int currentPlayer = 0; currentPlayer < players.Length; currentPlayer++)
        {
            // Om det nuvarande kastet är det högsta
            if (players[currentPlayer] > highestScore)
            {
                highestScore = players[currentPlayer];   // Spara värdet av högsta kastet
                highestScoreIndex = currentPlayer;       // Spara index av spelaren
            }
        }

        // Spara index av spelaren med högst poäng på nuvarande position i arrayen 'places'
        places[place] = highestScoreIndex;
        // Återställ sedan spelarens poäng till 0 för att nästa iteration av loopen ska få fram 2:a & 3:e plats, o.s.v.
        players[highestScoreIndex] = 0;
        highestScore = 0;
    }
}

// Main loop för spelet
for (int round = 0; round < 6; round++)
{
    Console.WriteLine("Current Round: " + (round + 1));
    Round();
    Score();

    Console.WriteLine("\nPress any key to continue...");
    Console.ReadKey();
}

Winner();
