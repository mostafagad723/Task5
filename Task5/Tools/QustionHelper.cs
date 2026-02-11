using Task5.QustionsClasses;

namespace Task5.Tools
{
    public class QustionHelper
    {
        // GetType method
        public static EnQustionType GetQustionType()
        {
            try
            {
                Console.WriteLine("Chose Type: \n   1- True OR False\n   2- Chose One\n   3- Multiple Choise");
                Console.Write("Enter Type => ");
                byte? chose = Convert.ToByte(Console.ReadLine());

                if (chose != null)
                {
                    switch (chose)
                    {
                        case 1:
                            return EnQustionType.TRUE_FALSE;
                        case 2:
                            return EnQustionType.CHHOSE_ONE;
                        case 3:
                            return EnQustionType.MULTIPLE_CHOICE;
                        default:
                            Console.Clear();
                            Console.WriteLine("Please Try Agin !!");
                            return GetQustionType();
                    }
                }

            }

            catch (FormatException ex)
            {
                Console.Clear();
                Console.WriteLine($"Message : {ex.Message}");
                Console.WriteLine("Please Try Agin !!");
            }
            catch (OverflowException ex)
            {
                Console.Clear();
                Console.WriteLine($"Message : {ex.Message}");
                Console.WriteLine("Please Try Agin !!");
            }
            return GetQustionType();
        }

        // GetLevel Method
        public static EnQustionLevel GetQustionLevel()
        {
            do
            {
                Console.WriteLine("Chose Level: \n   1- Esay\n   2- Medim\n   3- Hard");
                Console.Write("Enter Level => ");

                if (byte.TryParse(Console.ReadLine(), out byte level))
                {
                    switch (level)
                    {
                        case 1:
                            return EnQustionLevel.ESAY;
                        case 2:
                            return EnQustionLevel.MEDIM;
                        case 3:
                            return EnQustionLevel.HARD;
                        default:
                            Console.Clear();
                            Console.WriteLine("Invalid choice, please try again!");
                            break;

                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input, please enter a number!");

                }
            } while (true);
        }

        // GetHeader Method
        public static string GetQustionHeader()
        {
            Console.Write("Enter Header => ");
            string? header = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(header))
            {
                header = header.Trim().ToLower();
                if (header.Contains("?"))
                {
                    return header;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Your Qustion Header Dose Not Contain Qustion Mark -> '?' <- !!!!");
                    return GetQustionHeader();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You Insertion Is Invalid !!!");
                return GetQustionHeader();
            }
        }

        // GetMark Method
        public static double GetMark()
        {
            do
            {
                Console.Write("Enter Qustion Mark (0 : 20) => ");
                if (double.TryParse(Console.ReadLine(), out double mark) && mark > 0 && mark <= 20)
                {
                    return mark;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Input Please Try Again !!!!");
                }
            }
            while (true);
        }

        public static char GetChar_A_B_C_D()
        {

            do
            {
                Console.Write("Which is Corect Answers (A, B, C, D )\nyou can chose one or more chois\nAnd  For Exit ( 'X' ) \n\nEnter Your Answer => ");

                if (char.TryParse(Console.ReadLine()?.ToLower(), out char ch)) // 
                {
                    switch (ch)
                    {
                        case 'a':
                            return 'a';
                        case 'b':
                            return 'b';
                        case 'c':
                            return 'c';
                        case 'd':
                            return 'd';
                        case 'x':
                            return '\0';
                        default:
                            Console.Clear();
                            Console.WriteLine("Invalid Input Char (A, B, C, D) And  For Exit ( 'X' )");
                            break;
                    }
                }

            }
            while (true);

        }


        public static byte GetNumber()
        {
            do
            {
                Console.Write("Enter Number  => ");
                if (byte.TryParse(Console.ReadLine(), out byte number))
                {
                    return number;
                }
                else
                {
                    //Console.Clear();
                    Console.WriteLine("Invalid Input Please Try Again !!!!");
                }


            }
            while (true);
        }

        public static void SetChoises(List<string> choises)
        {
            string choise;
            EnCharOfChoises C = EnCharOfChoises.A;

            for (int i = 0; i < 4; i++)
            {
                choise = IChoisesTools.GetChoise(C);

                choises.Add(choise);
                Console.Clear();
                C++;
            }
        }

        public static void ShowChoises(List<string> choises)
        {
            EnCharOfChoises C = EnCharOfChoises.A;
            string choise = "";

            int counter = 1;
            foreach (var item in choises)
            {
                choise += $"{C}- " + item;
                if (counter < choises.Count)
                {
                    choise += ", ";
                }
                counter++;
                C++;
            }
            Console.WriteLine(choise);
        }


        public static EnQustionType DefinedType(List<Qustion>qustions)
        {
            do
            {
                Console.WriteLine("===> Defined the type of Qustion <===");
                string header = GetQustionHeader();

                foreach (var item in qustions)
                {
                    if (item.Header == header)
                    {
                        return item.Type;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Header Not Found !!!");
                        Console.WriteLine("Please Try Again !!!");
                        continue;
                    }

                }
            }
            while (true);
        }




        // return -1 if Qustion not found
        public static int GetIndexOfQustion(List<Qustion>qustions, string header)
        {
            for (int i = 0; i < qustions.Count; i++)
            {
                if (qustions[i].Header == header)
                {
                    return i;
                }
            }
            return -1;
        }
        
    }
}
