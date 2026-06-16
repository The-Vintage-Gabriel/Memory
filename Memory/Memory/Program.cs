
    
    static bool isTurned = false;
    
    static string[] a = new string[] { "Schmetterling", "Glühbirne", "Kaffeetasse", "Regenbogen", "Windmühle", "Sternenhimmel" };
    static string[] b = new string[] { "Taschenlampe", "Sanduhr", "Wolkenbruch", "Federkissen", "Ziegelstein", "Wasserfall" };
    static string[] c = new string[] { "Fetzen", "Glitzerstaub", "Fahrradklingel", "Murmeltier", "Papierflieger", "Dinosauria" };
    static string[] d = new string[] { "Fahrradklingel", "Glitzerstaub", "Taschenlampe", "Fetzen", "Glühbirne", "Sanduhr" };
    static string[] e = new string[] { "Glitzerstaub", "Wolkenbruch", "Kaffeetasse", "Murmeltier", "Federkissen", "Regenbogen" };
    static string[] f = new string[] { "Windmühle", "Ziegelstein", "Papierflieger", "Sternenhimmel", "Wasserfall", "Dinosauria" };

   
    static string[,] field = {
        {"Schmetterling", "Glühbirne", "Kaffeetasse", "Regenbogen", "Windmühle", "Sternenhimmel"},
        {"Taschenlampe", "Sanduhr", "Wolkenbruch", "Federkissen", "Ziegelstein", "Wasserfall"},
        {"Fetzen", "Glitzerstaub", "Fahrradklingel", "Murmeltier", "Papierflieger", "Dinosauria"},
        {"Fahrradklingel", "Glitzerstaub", "Taschenlampe", "Fetzen", "Glühbirne", "Sanduhr"},
        {"Glitzerstaub", "Wolkenbruch", "Kaffeetasse", "Murmeltier", "Federkissen", "Regenbogen"},
        {"Windmühle", "Ziegelstein", "Papierflieger", "Sternenhimmel", "Wasserfall", "Dinosauria"}
    };

   
     
        Console.WriteLine("--- Ursprüngliches Spielfeld ---");
        print(field);

        Console.WriteLine("\n--- Zufällig gemischtes Spielfeld ---");
        field = rndfield(field);
        print(field);
    
    
    static void print(string[,] currentField)
    {
        int rows = currentField.GetLength(0);
        int cols = currentField.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
              
                Console.Write(currentField[i, j].PadRight(16));
            }
            Console.WriteLine();
        }
    }

    /
    static string[,] rndfield(string[,] currentField)
    {
        Random rand = new Random();
        int rows = currentField.GetLength(0);
        int cols = currentField.GetLength(1);
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

    
    static string[,] turned()
    {

        if (isTurned == true) 
        {
           
        }
        return field;
    }

    static string[,] testifturned()
    {
       
        return field;
    }

    static bool updateMemory() 
    {
        return false;
    }