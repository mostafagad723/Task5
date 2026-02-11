using System.Globalization;

namespace Task5.Tools
{

    public enum EnCharOfChoises
    {
        A,
        B,
        C,
        D
    }

    public interface IChoisesTools
    {
        static string GetChoise(EnCharOfChoises c)
        {

            do
            {
                Console.Write($"Enter Choise {c} => ");
                string? str = Console.ReadLine()?.ToLower();
                if (!string.IsNullOrWhiteSpace(str))
                {
                    if (int.TryParse(str, out int num))
                    {
                        Console.Clear();
                        Console.WriteLine($"Invalid input '{num}' , numbers are not allowed. Please try again !!!\"");
                        continue;
                    }
                    return str;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input please try again !!!");
                }

            }
            while (true);

        }

    }
}
