using Task5.QustionsClasses;
using static Task5.Tools.QustionHelper;

namespace Task5.SysClases
{
    public class Doctor
    {
        private List<Qustion> _qustions;
        public Doctor(List<Qustion> qustions)
        {
            this._qustions = qustions;
            DoctorMenu();

        }





        public void DoctorMenu()
        {

            Console.WriteLine("Doctor Menu: \n1- Add Qustion\n2- Delete Qustion\n3- Update Qustion\n4- Back To Main Menu");
            byte chois = GetNumber();

            switch (chois)
            {
                case 1:
                    Console.Clear();
                    AddQustion();
                    return;

                case 2:
                    Console.Clear();
                    DeleteQustion();
                    return;

                case 3:
                    Console.Clear();
                    UpdateQustion();
                    return;

                case 4:
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine("invalid input, please try again !!!!");
                    DoctorMenu();
                    return;
            }
        }

        public void AddQustion()
        {
            Console.Clear();
            byte numberOfQustion = GetNumber();
            Console.Clear();

            for (int i = 0; i < numberOfQustion; i++)
            {
                EnQustionType type = GetQustionType();
                switch (type)
                {
                    case EnQustionType.TRUE_FALSE:
                        this._qustions.Add(new TrueOrFalseQustion());
                        break;
                    case EnQustionType.CHHOSE_ONE:
                        this._qustions.Add(new ChooseOneQustion());
                        break;
                    case EnQustionType.MULTIPLE_CHOICE:
                        this._qustions.Add(new MultipleChoiseQustion());
                        break;
                }

            }


        }

        public void DeleteQustion()
        {
            Console.WriteLine("===> Delete Method <===");
            if (this._qustions.Count != 0)
            {
                string header = GetQustionHeader();

                foreach (var item in this._qustions)
                {
                    if (item.Header == header)
                    {
                        do
                        {
                            Console.Write("You Will Delete this Qustion\nFor Confirm (Y / N) \nAre You Sure ? ");
                            if (char.TryParse(Console.ReadLine(), out char acceptDeletion))
                            {
                                if (acceptDeletion == 'Y' || acceptDeletion == 'y')
                                {
                                    this._qustions.Remove(item);
                                    Console.WriteLine("This item is succsusfly removed !!");
                                    Console.ReadKey();
                                    return;
                                }

                                if (acceptDeletion == 'N' || acceptDeletion == 'n')
                                {
                                    Console.WriteLine("Deletion is Canceled!!!");
                                    Console.ReadKey();
                                    return;
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid input Please Enter (Y / N ) For deletion  Confirm");
                            }
                        }
                        while (true);
                    }
                    else
                    {
                        Console.WriteLine("Qustion Not Foud !!");
                        Console.ReadKey();
                        return;
                    }
                }
            }
            else
            {
                Console.WriteLine("List Of Qustion Is Empty !!!");
                Console.ReadKey();
                return;
            }
        }

        public void UpdateQustion()
        {

            int  index = GetIndexOfQustion(this._qustions, GetQustionHeader());
          
            if (index >= 0) 
            {
                EnQustionType type = this._qustions[index].Type;
                
                switch (type)
                {
                    case EnQustionType.TRUE_FALSE:
                        this._qustions[index] = new TrueOrFalseQustion();
                        Console.WriteLine("Qustion Is Updated Successfuly Press Enter To Contnue .... !!");
                        Console.ReadKey();
                        return;

                    case EnQustionType.CHHOSE_ONE:
                        this._qustions[index] = new ChooseOneQustion();
                        Console.WriteLine("Qustion Is Updated Successfuly Press Enter To Contnue .... !!");
                        Console.ReadKey();
                        return;

                    case EnQustionType.MULTIPLE_CHOICE:
                        this._qustions[index] = new MultipleChoiseQustion();
                        Console.WriteLine("Qustion Is Updated Successfuly Press Enter To Contnue .... !!");
                        Console.ReadKey();
                        return;
                }
            }
            else
            {
                Console.WriteLine("You Can Not Update,  Please try Again !!!");
                Console.ReadKey();
                return;
            }

        }

    }
}
