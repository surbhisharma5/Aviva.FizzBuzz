namespace Aviva.FizzBuzz.BusinessLayer
{
    using Interface;

    public class FizzBuzz : IFizzBuzz
    {
       
        public bool IsDivisible(int number)
        {
            return ((number % 3) == 0 && (number % 5) == 0);
        }

        string _sMessage;
        public string Message => _sMessage;

        public string MessageColor => string.Empty;

        public void SetMessage(bool isSpecificDay)
        {
            _sMessage = isSpecificDay ? "Wizz Wuzz" : "Fizz Buzz";
        }
    }

 
    public class Fizz : IFizzBuzz
    {
        public bool IsDivisible(int number)
        {
            return (number % 3) == 0;
        }

        string _sMessage;
        public string Message => _sMessage;

        public string MessageColor => "blue";

        public void SetMessage(bool isSpecificDay)
        {
            _sMessage = isSpecificDay ? "Wizz" : "Fizz";
        }
    }

   
    public class Buzz : IFizzBuzz
    {
        
        public bool IsDivisible(int number)
        {
            return (number % 5) == 0;
        }

        string _sMessage;
        public string Message => _sMessage;

        public string MessageColor => "green";

        public void SetMessage(bool isSpecificDay)
        {
            _sMessage = isSpecificDay ? "Wuzz" : "Buzz";
        }
    }
}