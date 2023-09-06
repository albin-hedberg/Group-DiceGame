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

        // Poäng:
        // 1:a = 5p
        // 2:a = 3p
        // 3:a = 1p
        // 4:a = 0p
        switch (place)
        {
            case 0:
                scores[highestRollIndex] += 5;
                break;
            case 1:
                scores[highestRollIndex] += 3;
                break;
            case 2:
                scores[highestRollIndex] += 1;
                break;
            case 3:
                scores[highestRollIndex] += 0;
                break;
            default:
                break;
        }

        // Återställ sedan spelarens kast till 0 för att nästa iteration av loopen ska få fram 2:a & 3:e plats, o.s.v.
        players[highestRollIndex] = 0;
        highestRollIndex = -1;
        highestRoll = 0;
    }

    for(int i = 0; i < scores.Length; i++)
    {
        Console.WriteLine("Player" + (i + 1) + " points: " + scores[i]);
    }
}

// "En metod för att avgöra segraren av spelet"
void Winner()
{
    Console.WriteLine("Winner: ");
}

// Main loop för spelet
for (int round = 0; round < 6; round++)
{
    Console.WriteLine("Current Round: " + (round + 1));
    Round();
    Score();

    Console.WriteLine();
    //Console.WriteLine("\nPress any key to continue...");
    //Console.ReadKey();
}

Winner();
