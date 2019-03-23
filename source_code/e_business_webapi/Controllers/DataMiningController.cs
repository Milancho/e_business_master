using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Schema;
using e_business_webapi.Models;
using e_business_webapi.Shared;
using e_business_master_code;
using e_business_master_code.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_business_webapi.Controllers
{
    [Route("api/dm")]
    [ApiController]
    public class DataMiningController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<CustomerModel>> Get()
        {
            var values = System.IO.File.ReadAllLines(@"customer-data-2.txt")
                .Skip(1)
                .Select(v => v.CustomerValues())
                .ToList();

            var count = 1;
            foreach (var value in values)
            {
                value.Name = "Person_" + count;
                value.EducationName = Functions.GetEnumKeyValuePair<Education>(value.EducationId).Value.GetByKey();
                value.GenderName = Functions.GetEnumKeyValuePair<Gender>(value.Gender).Value.GetByKey();
                value.MaritalStatusName = Functions.GetEnumKeyValuePair<MaritalStatus>(value.MaritalStatus).Value.GetByKey();
                value.LabelName = value.Label == "1" ? "Добар" : "Лош";
            }

            return values;
        }

        [HttpPost]
        public IActionResult Post(CustomerModel model)
        {
            var birthDate = new DateTime(model.Year, model.Month, model.Day);
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;
            if (birthDate > today.AddYears(-age)) age--;

            var customerDataMiningModel = new CustomerDataMiningModel()
            {
                Name = model.Name,
                EducationId = model.EducationId,
                Gender = model.Gender,
                MaritalStatus = model.MaritalStatus,
                Age = age
            };

            var prediction = BinaryClassification.MakePrediction(customerDataMiningModel);
            return Ok(prediction);
        }

    }
}