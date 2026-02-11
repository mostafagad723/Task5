using Task5.QustionsClasses;
using static Task5.Tools.QustionHelper;

namespace Task5.SysClases
{

    public enum EnExamType
    {
        PRACTICAL,
        FINAL
    }


    public class Student
    {
        private List<Qustion> _qustions;

        public Student(List<Qustion> qustions)
        {
            this._qustions = qustions;

            StudentMenu();
        }

        public void StudentMenu()
        {
            Console.WriteLine("Student Menu:\n1- Practical Exam \n2- Final Exam\n3- Back To Main Menu");
            int chois = GetNumber();

            switch (chois)
            {
                case 1:
                    Exam(EnExamType.PRACTICAL);
                    break;
                case 2:
                    Exam(EnExamType.FINAL);
                    break;
                case 3:
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine("invalid input, please try agin !!!!!");
                    StudentMenu();
                    return;
            }




        }

        public void Exam(EnExamType examType)
        {
            List<Qustion> examQustions = new List<Qustion>();

            if (this._qustions.Count > 0)
            {
                int defind = 0;
                switch (examType)
                {
                    case EnExamType.PRACTICAL:
                        defind = 1; break;
                    case EnExamType.FINAL:
                        if (examQustions.Count > 1)
                        {
                            defind = 2;
                        }
                        break;
                }



                EnQustionType type = GetQustionType();
                EnQustionLevel level = GetQustionLevel();


                for (int i = 0; i < this._qustions.Count; i++)
                {
                    if (this._qustions[i].Type == type && this._qustions[i].Level == level)
                    {
                        examQustions.Add(this._qustions[i]);
                    }
                }


                double score = 0;
                double AllMark = 0;



                for (int i = 0; i < examQustions.Count / defind; i++)
                {
                    Console.WriteLine($"Qustion {i + 1}:\n{examQustions[i].Header}");
                    switch (type)
                    {
                        case EnQustionType.TRUE_FALSE:
                            var qustionTF = (TrueOrFalseQustion)examQustions[i];
                            var studentAnswerTF = examQustions[i].GetAnswer<bool>();

                            if (studentAnswerTF == qustionTF.Answer)
                            {
                                score += qustionTF.Mark;
                                AllMark += qustionTF.Mark;

                            }
                            break;

                        case EnQustionType.CHHOSE_ONE:
                            var qustionCO = (ChooseOneQustion)examQustions[i];
                            ShowChoises(qustionCO.choises);
                            var studentAnswerCO = examQustions[i].GetAnswer<char>();

                            if (studentAnswerCO == qustionCO.Answer)
                            {
                                score += qustionCO.Mark;
                                AllMark -= qustionCO.Mark;
                            }
                            break;
                        case EnQustionType.MULTIPLE_CHOICE:
                            var qustionMC = (MultipleChoiseQustion)examQustions[i];
                            ShowChoises(qustionMC.choises);
                            var studentAnswerMC = examQustions[i].GetAnswer<List<char>>();

                            if (string.Join(',', qustionMC.Answers) == string.Join(',', studentAnswerMC))
                            {
                                score += qustionMC.Mark;
                                AllMark += qustionMC.Mark;
                            }
                            break;

                    }

                }
                Console.WriteLine($"Exam Finished! Your Score: {score}/{AllMark}");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("No Qustion In List Please try Again !!!!");
                Console.ReadKey();
            }

        }

    }

}
