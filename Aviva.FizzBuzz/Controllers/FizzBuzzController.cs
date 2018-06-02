namespace Aviva.FizzBuzz.Controllers
{
    using Interface;
    using Models;
    using System.Collections.Generic;
    using System.Web.Mvc;

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

            FizzBuzzModel objData = new FizzBuzzModel()
            { Number = postModel.Number };
            if (ModelState.IsValid)
            {
                FillFizzBuzzList(objData);
            }

            return View("FizzBuzzView", objData);
        }

        private void FillFizzBuzzList(FizzBuzzModel objData)
        {
            if (objData.Number != null) objData.FizzBuzzList = _businessrules.GetData(nNumber: objData.Number.Value, listFizzBuzz: _fizzbuzz);
        }

    }
}