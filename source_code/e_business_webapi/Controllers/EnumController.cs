using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using e_business_webapi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_business_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnumController : ControllerBase
    {
        public ActionResult<Dictionary<string, List< KeyValuePair<int, string>>>> Get()
        {
            var ret = new Dictionary<string, List<KeyValuePair<int, string>>>
            {
                { "education", Data.EducationList },
                { "gender", Data.GenderList },
                { "maritalStatus", Data.MaritalStatusList }
            };
            return ret;
        }
    }
}