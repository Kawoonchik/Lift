using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введіть число від 1 до 365 (1 < k < 365):");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int k) && k >= 1 && k <= 365)
        {
            int dayIndex = (k - 1) % 7;
            string dayName = "";
            
            switch (dayIndex)
            {
                case 0:
                    dayName = "Понеділок";
                    break;
                case 1:
                    dayName = "Вівторок";
                    break;
                case 2:
                    dayName = "Середа";
                    break;
                case 3:
                    dayName = "Четвер";
                    break;
                case 4:
                    dayName = "П'ятниця";
                    break;
                case 5:
                    dayName = "Субота";
                    break;
                case 6:
                    dayName = "Неділя";
                    break;
            }
            Console.WriteLine($"День тижня для числа {k}: {dayName}");
        }

        else
        {
            Console.WriteLine("Помилка, число за межами. (1 < k < 365)");
        }
    }
}