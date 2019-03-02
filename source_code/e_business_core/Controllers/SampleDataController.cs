using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using e_business_master_code;
using e_business_master_code.Shared;
using Microsoft.AspNetCore.Mvc;

namespace client_app.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public string[] GetSummaries()
        {
            return Summaries;
        }

        [HttpGet("[action]")]
        public List<KeyValuePair<int, string>> GetEducations()
        {
            return EducationList;
        }

        [HttpGet("[action]")]
        public List<KeyValuePair<int, string>> GetGender()
        {
            return GenderList;
        }

        [HttpGet("[action]")]
        public List<KeyValuePair<int, string>> GetMaritalStatus()
        {
            return MaritalStatusList;
        }
        
        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }


        #region data

        private static readonly List<KeyValuePair<int, string>> EducationList = new List<KeyValuePair<int, string>>()
        {
            new KeyValuePair<int, string>( 6, Education.ElementarySchool.ToString().GetByKey() ),
            new KeyValuePair<int, string>( 7, Education.HighSchool.ToString().GetByKey() ),
            new KeyValuePair<int, string>( 8, Education.HigherSchool.ToString().GetByKey()),
            new KeyValuePair<int, string>( 9,  Education.College.ToString().GetByKey())
        };

        private static readonly List<KeyValuePair<int, string>> GenderList = new List<KeyValuePair<int, string>>()
        {
            new KeyValuePair<int, string>( 1, Gender.Male.ToString().GetByKey()),
            new KeyValuePair<int, string>( 2, Gender.Female.ToString().GetByKey())
        };

        private static readonly List<KeyValuePair<int, string>> MaritalStatusList = new List<KeyValuePair<int, string>>()
        {
            new KeyValuePair<int, string>(1, MaritalStatus.Single.ToString().GetByKey() ),
            new KeyValuePair<int, string>(2, MaritalStatus.Married.ToString().GetByKey()),
            new KeyValuePair<int, string>(3,  MaritalStatus.Widower.ToString().GetByKey()),
            new KeyValuePair<int, string>(4,  MaritalStatus.Divorced.ToString().GetByKey())
        };


        #endregion

    }
}


public class KeyValue
{
    public int Id { get; set; }
    public string Value { get; set; }
}

