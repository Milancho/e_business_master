using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace e_business_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<dynamic> Get()
        {
            var asm = System.Reflection.Assembly.GetExecutingAssembly();
            var version = asm.GetName().Version;
            var product = asm.GetCustomAttributes(typeof(System.Reflection.AssemblyProductAttribute), true).FirstOrDefault() as System.Reflection.AssemblyProductAttribute;
            var description = asm.GetCustomAttributes(typeof(System.Reflection.AssemblyDescriptionAttribute), true).FirstOrDefault() as System.Reflection.AssemblyDescriptionAttribute;
            var company = asm.GetCustomAttributes(typeof(System.Reflection.AssemblyCompanyAttribute), true).FirstOrDefault() as System.Reflection.AssemblyCompanyAttribute;

            if (company == null) return null;
            if (description == null) return null;

            var healthInfo = new
            {
                company.Company,
                description.Description,
                Version = version.Major + "." + version.Minor + "." + version.Build + "." + version.Revision
            };

            return healthInfo;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
