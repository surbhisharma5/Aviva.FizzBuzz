namespace Aviva.FizzBuzz.BusinessLayer
{
    using Interface;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BusinessRules : IBusinessRules
    {
        public List<IFizzBuzz> GetData(int number, IList<IFizzBuzz> listFizzBuzz)
        {
            List<IFizzBuzz> list = new List<IFizzBuzz>();
            for (var counter = 1; counter <= number; counter++)
            {
                //Get the class instance if num is divisiable
                var inputnumber = counter;
                IEnumerable<IFizzBuzz> data = listFizzBuzz.Where(x => x.IsDivisible(inputnumber));
                if (data.ToList().Count > 0)
                {
                    var objData = data.ToList()[0];
                    objData.SetMessage(IsSpecificDay());
                    list.Add(objData);
                }
                else
                {
                    list.Add(new Number(counter));
                }
            }
            return list;
        }
       
        public bool IsSpecificDay()
        {
            return DateTime.Today.DayOfWeek == DayOfWeek.Wednesday;
        }
    }
}