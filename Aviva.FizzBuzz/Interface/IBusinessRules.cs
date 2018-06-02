namespace Aviva.FizzBuzz.Interface
{
    using System.Collections.Generic;

    public interface IBusinessRules
    {
        List<IFizzBuzz> GetData(int nNumber, IList<IFizzBuzz> listFizzBuzz);
    }
}