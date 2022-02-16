namespace AdventOfCode.Day4
{
    public class Number
    {
        public Number(int value)
        {
            Value = value;
            IsMarked = false;
        }

        public int Value { get; }

        public bool IsMarked { get; private set; }

        public void Mark()
        {
            IsMarked = true;
        }

        public override string ToString()
        {
            return IsMarked ? "__" : $"{Value}";
        }
    }
}