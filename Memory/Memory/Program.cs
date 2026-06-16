using System;
using System.Threading;

class Program
{

    static int rows = 6;
    static int cols = 6;


    static string[,] field =
    {
        { "Schmetterling", "Glühbirne", "Kaffeetasse", "Regenbogen", "Windmühle", "Sternenhimmel" },
        { "Taschenlampe", "Sanduhr", "Wolkenbruch", "Federkissen", "Ziegelstein", "Wasserfall" },
        { "Fetzen", "Schmetterling", "Fahrradklingel", "Murmeltier", "Papierflieger", "Dinosaulia"},
        { "Fahrradklingel", "Glitzerstaub", "Taschenlampe", "Fetzen", "Glühbirne", "Sanduhr" },
        { "Glitzerstaub", "Wolkenbruch", "Kaffeetasse", "Murmeltier", "Federkissen", "Regenbogen" },
        { "Windmühle", "Ziegelstein", "Papierflieger", "Sternenhimmel", "Wasserfall", "Dinosaulia" }
    };


    static bool[,] revealed = new bool[6, 6];


    static int scorePlayer1 = 0;
    static int scorePlayer2 = 0;
    static int currentPlayer = 1;

    static void Main(string[] args)
    {

        field = rndfield(field);


        while (scorePlayer1 + scorePlayer2 < 18)
        {
            Console.Clear();
            Console.WriteLine($"=== MEMORY SPIEL ===");
            Console.WriteLine($"Spieler 1: {scorePlayer1} Paare | Spieler 2: {scorePlayer2} Paare");
            Console.WriteLine($"Es ist AM ZUG: Spieler {currentPlayer}\n");


            print(field);


            Console.WriteLine("\n--- Erste Karte auswählen ---");
            int r1 = GetValidCoordinate("Zeile (1-6): ") - 1;
            int c1 = GetValidCoordinate("Spalte (1-6): ") - 1;

            if (revealed[r1, c1])
            {
                Console.WriteLine("Diese Karte ist schon offen! Drücke Enter für einen neuen Versuch.");
                Console.ReadLine();
                continue;
            }

            revealed[r1, c1] = true;
            Console.Clear();
            print(field);


            Console.WriteLine("\n--- Zweite Karte auswählen ---");
            int r2 = GetValidCoordinate("Zeile (1-6): ") - 1;
            int c2 = GetValidCoordinate("Spalte (1-6): ") - 1;

            if (r1 == r2 && c1 == c2)
            {
                Console.WriteLine("Du kannst nicht dieselbe Karte zweimal wählen! Start von vorn.");
                revealed[r1, c1] = false;
                Console.ReadLine();
                continue;
            }

            if (revealed[r2, c2])
            {
                Console.WriteLine("Diese Karte ist schon offen! Start von vorn.");
                revealed[r1, c1] = false;
                Console.ReadLine();
                continue;
            }

            revealed[r2, c2] = true;
            Console.Clear();
            print(field);


            if (field[r1, c1] == field[r2, c2])
            {
                Console.WriteLine($"\nTreffer! '{field[r1, c1]}' ist ein Paar.");
                if (currentPlayer == 1) scorePlayer1++;
                else scorePlayer2++;


                Thread.Sleep(2000);
            }
            else
            {
                Console.WriteLine("\nKein Treffer. Karten werden wieder verdeckt...");
                Thread.Sleep(2500);


                revealed[r1, c1] = false;
                revealed[r2, c2] = false;


                currentPlayer = (currentPlayer == 1) ? 2 : 1;
            }
        }


        Console.Clear();
        Console.WriteLine("=== SPIEL ENDE ===");
        Console.WriteLine($"Endstand - Spieler 1: {scorePlayer1} | Spieler 2: {scorePlayer2}");

        if (scorePlayer1 > scorePlayer2) Console.WriteLine("Spieler 1 hat gewonnen!");
        else if (scorePlayer2 > scorePlayer1) Console.WriteLine("Spieler 2 hat gewonnen!");
        else Console.WriteLine("Unentschieden!");
    }


    static void print(string[,] currentField)
    {

        Console.Write("      ");
        for (int c = 1; c <= cols; c++) Console.Write($"[S{c}]".PadRight(16));
        Console.WriteLine("\n" + new string('-', 105));

        for (int i = 0; i < rows; i++)
        {

            Console.Write($"[Z{i + 1}] ");

            for (int j = 0; j < cols; j++)
            {
                if (revealed[i, j])
                {
                    Console.Write(currentField[i, j].PadRight(16));
                }
                else
                {
                    Console.Write("[ X ]".PadRight(16));
                }
            }

            Console.WriteLine();
        }
    }


    static string[,] rndfield(string[,] currentField)
    {
        Random rand = new Random();
        int totalElements = rows * cols;

        for (int i = totalElements - 1; i > 0; i--)
        {
            int j = rand.Next(i + 1);

            int rowI = i / cols;
            int colI = i % cols;

            int rowJ = j / cols;
            int colJ = j % cols;

            string temp = currentField[rowI, colI];
            currentField[rowI, colI] = currentField[rowJ, colJ];
            currentField[rowJ, colJ] = temp;
        }

        return currentField;
    }


    static int GetValidCoordinate(string text)
    {
        Console.Write(text);
        int cordinate = int.Parse(Console.ReadLine());
        
        
        if (cordinate >= 7)
        {
            return 0;
        }
        else
        {
            return cordinate;
        }
    }
}
 