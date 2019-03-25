using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace e_business_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        /// <summary>
        /// Core - Debug Health status...
        /// </summary>
        /// <returns></returns>
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
    }
}
