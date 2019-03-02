using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using client_app.Models;
using e_business_master_code.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace client_app.Controllers
{
    [Route("api/cs")]
    [ApiController]
    public class CreditScoringController : ControllerBase
    {
        [HttpGet]
        [HttpGet("[action]")]
        public ActionResult<IEnumerable<CardStatusModel>> CardStatus()
        {
            var file = @"cs_CardStatus.txt";
            var values = System.IO.File.ReadAllLines(file)
                .Skip(1)
                .Select(v => v.CardStatusValues())
                .ToList();
            return values;
        }

        [HttpGet]
        [HttpGet("[action]")]
        public ActionResult<IEnumerable<PersonalDataModel>> PersonalData()
        {
            var file = @"cs_LicniPodatoci.txt";
            var values = System.IO.File.ReadAllLines(file)
                .Skip(1)
                .Select(v => v.PersonalDataValues())
                .ToList();
            return values;
        }

        [HttpGet]
        [HttpGet("[action]")]
        public ActionResult<IEnumerable<FamilyDataModel>> FamilyData()
        {
            var file = @"cs_PodatociZaSemejstvo.txt";
            var values = System.IO.File.ReadAllLines(file)
                .Skip(1)
                .Select(v => v.FamilyDataValues())
                .ToList();
            return values;
        }        
    }
}