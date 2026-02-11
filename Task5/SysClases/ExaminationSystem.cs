using Task5.QustionsClasses;

namespace Task5.SysClases
{
    public enum EnMode
    {
        DOCTOR,
        STUDENT,
        EXIT
    }

    public class ExaminationSystem
    {

        protected List<Qustion> _qustions; // main list 
        protected EnMode Mode { get; set; }

        public ExaminationSystem() => this._qustions = new List<Qustion>(); 

        public void Start()
        {
            do
            {
                Console.Clear();
                this.Mode = GetMode();

                switch (Mode)
                {
                    case EnMode.DOCTOR:
                        Console.Clear();
                        Doctor doctor = new Doctor(this._qustions);
                        break;





                    case EnMode.STUDENT:
                        Console.Clear();
                        Student student = new Student(this._qustions);
                        break;



                    case EnMode.EXIT:
                        Console.Clear();
                        Console.WriteLine("Goodbay(-_-)!!");
                        return;
                }
            }
            while (true);
        }

        public static EnMode GetMode()
        {
            try
            {

                Console.WriteLine("Main menu :\n  1-Doctor mode\n  2-Student mode\n  3-Exit");
                Console.Write("Enter Number Of Mode => ");

                byte? mode = Convert.ToByte(Console.ReadLine());  // nullable 
                if (mode != null)
                {
                    switch (mode)
                    {
                        case 1:
                            return EnMode.DOCTOR;
                        case 2:
                            return EnMode.STUDENT;
                        case 3:
                            return EnMode.EXIT;
                        default:
                            Console.Clear();
                            Console.WriteLine("Invalid input please Try Again!!! ");
                            return GetMode();
                    }
                }
            }
            catch (FormatException ex)
            {
                Console.Clear();
                Console.WriteLine($"Message : {ex.Message}");
                Console.WriteLine("Please Try Agin !!!!!!");
            }
            catch (OverflowException ex)
            {
                Console.Clear();
                Console.WriteLine($"Message : {ex.Message}");
                Console.WriteLine("Please Try Agin !!!!!!");
            }

            return GetMode(); // recursion function 

        }

    }

}
