using Task5.Tools;
using static Task5.Tools.QustionHelper;

namespace Task5.QustionsClasses
{

    public class ChooseOneQustion : Qustion, IChoisesTools
    {
        public char Answer { get; set; }

        public List<string> choises;

        public ChooseOneQustion()
        {
            this.Type = EnQustionType.CHHOSE_ONE;
            choises = new List<string>();
            Console.Clear();

            this.Level = GetQustionLevel();
            Console.Clear();

            this.Mark = GetMark();
            Console.Clear();

            this.Header = GetQustionHeader();
            Console.Clear();

            SetChoises(this.choises);


            this.Answer = GetAnswer<char>();
            Console.Clear();


        }


        public override T GetAnswer<T>()
        {
            // return (A, B, C, D)
            do
            {
                ShowChoises(this.choises);
                Console.Write("\nEnter The Corect Answer (A, B, C, D) => ");
                if (char.TryParse(Console.ReadLine()?.ToLower(), out char answer))
                {
                    switch (answer)
                    {
                        case 'a':
                        case 'b':
                        case 'c':
                        case 'd':
                            return (T)(object)answer;
                        default:
                            Console.Clear();
                            Console.WriteLine("Invalid Input Please Chose one of them (A, B, C, D)!!");
                            break;
                    }

                }
                else
                {
                    string str = Convert.ToString(answer);
                    Console.Clear();
                    Console.WriteLine("Your Input Is Invalid Please try Again !!!!!");
                }

            }
            while (true);
        }

        public override string ToString()
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


            return $"Type   : {this.Type}\n" +
                $"Level   : {this.Level}\n" +
                $"Header  : {this.Header}\n" +
                $"Mark    : {this.Mark}\n" +
                $"Choises : {choise}\n" +
                $"Answer  : {this.Answer}";
        }
    }
}
