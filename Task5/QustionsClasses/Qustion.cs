namespace Task5.QustionsClasses
{
    public enum EnQustionType
    {
        TRUE_FALSE,
        CHHOSE_ONE,
        MULTIPLE_CHOICE
    }

    public enum EnQustionLevel
    {
        ESAY,
        MEDIM,
        HARD
    }

    public abstract class Qustion
    {
        public EnQustionType Type { get; set; }
        public EnQustionLevel? Level { get; set; }
        public string? Header { get; set; }
        public double Mark { get; set; }
        public abstract T GetAnswer<T>();
    }

}
