using System.Collections.Generic;
using System.Web.Mvc;
using Aviva.FizzBuzz.Interface;
using Aviva.FizzBuzz.Models;

namespace Aviva.FizzBuzz.Controllers
{
    public class FizzBuzzController : Controller
    {
        private readonly IBusinessRules _businessrules;
        private readonly IList<IFizzBuzz> _fizzbuzz;

        public FizzBuzzController(IBusinessRules businessRules, IList<IFizzBuzz> fizzBuzz)
        {
            _businessrules = businessRules;
            _fizzbuzz = fizzBuzz;
        }


        // GET: FizzBuzz
        public ActionResult FizzBuzzView()
        {
            return View("FizzBuzzView", new FizzBuzzModel());
        }

        [HttpPost]
        public ActionResult GetData(FizzBuzzModel postModel)
        {
            var objData = new FizzBuzzModel {Number = postModel.Number};
            if (ModelState.IsValid) FillFizzBuzzList(objData);

            return View("FizzBuzzView", objData);
        }

        private void FillFizzBuzzList(FizzBuzzModel objData)
        {
            if (objData.Number != null) objData.FizzBuzzList = _businessrules.GetData(objData.Number.Value, _fizzbuzz);
        }
    }
}