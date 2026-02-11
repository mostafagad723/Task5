using static Task5.Tools.QustionHelper;

namespace Task5.QustionsClasses
{
    public class TrueOrFalseQustion : Qustion
    {
        public bool Answer { get; set; }
        public TrueOrFalseQustion()
        {
            this.Type = EnQustionType.TRUE_FALSE;
            Console.Clear();

            this.Level = GetQustionLevel();
            Console.Clear();

            this.Header = GetQustionHeader();
            Console.Clear();

            this.Mark = GetMark();
            Console.Clear();

            this.Answer = GetAnswer<bool>();
            Console.Clear();
        }
        public override T GetAnswer<T>()
        {
            do
            {
                Console.Write("Enter Your Answer  (True, False) => ");
                if (bool.TryParse(Console.ReadLine()?.ToLower(), out bool answer))
                {
                    // you must convert 'answer' to 'object' ===> FOR convert 'answer' to Generic type such as 'T'
                    //return (T)Convert.ChangeType(answer, typeof(T));
                    return (T)(object)answer;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input, please enter True or False!");

                }
            }
            while (true);
        }

        public override string ToString()
        {
            return $"Type   : {this.Type}\n" +
                $"Level   : {this.Level}\n" +
                $"Header  : {this.Header}\n" +
                $"Mark    : {this.Mark}\n" +
                $"Answer  : {this.Answer}";
        }
    }



}
