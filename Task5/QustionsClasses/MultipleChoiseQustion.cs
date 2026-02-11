using static Task5.Tools.QustionHelper;

namespace Task5.QustionsClasses
{
    public class MultipleChoiseQustion : Qustion
    {
        public List<char> Answers { get; set; }
        public List<string> choises;

        public MultipleChoiseQustion()
        {


            this.Type = EnQustionType.CHHOSE_ONE;
            choises = new List<string>();
            this.Answers = new List<char>();
            Console.Clear();

            this.Level = GetQustionLevel();
            Console.Clear();

            this.Header = GetQustionHeader();
            Console.Clear();

            this.Mark = GetMark();
            Console.Clear();

            SetChoises(this.choises);

            Console.Clear();
            this.Answers = GetAnswer<List<char>>();

        }



        public override T GetAnswer<T>()
        {
            // GetChar_A_B_C_D();
            // must return (A , B, C, D)  And ('X') For Exit

            do
            {
                char answer = GetChar_A_B_C_D();
                Console.Clear();

                if (answer == '\0')
                {
                    break;
                }

                if (this.Answers.Contains(answer))
                {
                    Console.WriteLine("This Chois is already exist !!\n");
                    continue;
                }

                Answers.Add(answer);

            } while (true);

            return (T)(object)Answers;
        }




        public override string ToString()
        {
            string result = string.Join(",", Answers);


            return $"Type   : {this.Type}\n" +
                $"Level   : {this.Level}\n" +
                $"Header  : {this.Header}\n" +
                $"Mark    : {this.Mark}\n" +
                $"Answer  : {result}";
        }





    }


}
