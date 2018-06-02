namespace Aviva.FizzBuzz.Interface
{
    public interface IFizzBuzz
    {
        bool IsDivisible(int number);
        string Message { get; }
        string MessageColor { get; }
        void SetMessage(bool isSpecificDay);
    }
}