namespace Aviva.FizzBuzz.BusinessLayer
{
    using Interface;

    public class Number : IFizzBuzz
    {
        public Number(int number) { Message = number.ToString(); }

        public bool IsDivisible(int number)
        {
            return false;
        }

        public string Message { get; }

        public string MessageColor => string.Empty;

        public void SetMessage(bool isSpecificDay)
        {
        }
    }
}