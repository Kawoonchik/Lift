using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введіть текст англіською(r,k,t):");
        string input = Console.ReadLine();
        Char[] text = input.ToCharArray();

        int CountR = 0, CountK = 0, CountT = 0;

        foreach (char c in text)
        {
            switch (char.ToLower(c))
            {
                case 'r':
                    CountR++;
                    break;
                case 'k':
                    CountK++;
                    break;
                case 't':
                    CountT++;
                    break;
            }
        }

        Console.WriteLine("Результае:");
        Console.WriteLine($"Кількість r: {CountR}");    
        Console.WriteLine($"Кількість k: {CountK}");
        Console.WriteLine($"Кількість t: {CountT}");
    }
}   