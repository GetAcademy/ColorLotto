using System;

class Program
{
    static void Main()
    {
        // Opprett et array for kortene med tilsvarende farger
        ConsoleColor[] cards = new ConsoleColor[16];
        ConsoleColor[] cardColors = {
            ConsoleColor.Red, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Green,
            ConsoleColor.Blue, ConsoleColor.Blue, ConsoleColor.Yellow, ConsoleColor.Yellow,
            ConsoleColor.Magenta, ConsoleColor.Magenta, ConsoleColor.Cyan, ConsoleColor.Cyan,
            ConsoleColor.White, ConsoleColor.White, ConsoleColor.Gray, ConsoleColor.Gray
        };

        // Bland kortene
        Random rand = new Random();
        for (int i = cardColors.Length - 1; i > 0; i--)
        {
            int j = rand.Next(0, i + 1);
            ConsoleColor temp = cardColors[i];
            cardColors[i] = cardColors[j];
            cardColors[j] = temp;
        }

        // Opprett et array for å holde styr på om kortene er snudd eller ikke
        bool[] flippedCards = new bool[16];

        // Start hovedløkken
        while (true)
        {
            Console.Clear();
            DisplayBoard(cards, flippedCards);

            Console.WriteLine("Velg et kort å snu (1-16): ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= 16)
            {
                choice--; // Konverter til array-indeks
                if (!flippedCards[choice])
                {
                    // Snur kortet og vis fargen
                    cards[choice] = cardColors[choice];
                    flippedCards[choice] = true;

                    Console.Clear();
                    DisplayBoard(cards, flippedCards);

                    // Sjekk om alle kortene er snudd
                    if (Array.TrueForAll(flippedCards, card => card))
                    {
                        Console.WriteLine("Gratulerer! Du har snudd alle kortene!");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Kortet er allerede snudd. Velg et annet.");
                }
            }
            else
            {
                Console.WriteLine("Ugyldig inndata. Skriv inn et tall mellom 1 og 16.");
            }

            Console.WriteLine("Trykk Enter for å fortsette...");
            Console.ReadLine();
        }
    }

    static void DisplayBoard(ConsoleColor[] cards, bool[] flippedCards)
    {
        Console.WriteLine("Bildelotto:");
        for (int i = 0; i < cards.Length; i++)
        {
            if (flippedCards[i])
            {
                Console.BackgroundColor = cards[i];
                Console.Write("   ");
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Write($" {i + 1:D2}"); // Viser kortets nummer når det ikke er snudd
            }

            Console.ResetColor();

            if ((i + 1) % 4 == 0)
            {
                Console.WriteLine();
            }
        }
    }
}
