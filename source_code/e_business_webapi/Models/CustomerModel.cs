using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ML.Runtime.Api;
using Newtonsoft.Json;

namespace e_business_webapi.Models
{
    public class CustomerModel
    {
        public int Id;
        public string Name { get; set; }
        public int EducationId { get; set; }
        public string EducationName { get; set; }
        public int Gender { get; set; }
        public string GenderName { get; set; }
        public int MaritalStatus { get; set; }
        public string MaritalStatusName { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int Age;
        public string Label;
        public string LabelName;
    }

    public class CustomerDataMiningModel
    {
        public string Name;

        /// <summary>
        /// ElementarySchool = 6, HighSchool = 7, HigherSchool = 8, College = 9 
        /// </summary>
        public float EducationId;

        /// <summary>
        ///  Male = 1, Female = 2, 
        /// </summary>
        public float Gender;

        /// <summary>
        /// Single = 1, Married = 2, Widower = 3, Divorced = 4,
        /// </summary>
        public float MaritalStatus;

        public float Age;
        [JsonIgnore]
        public string Label;
    }

    public class CustomerPrediction
    {
        [ColumnName("PredictedLabel")]
        public bool IsGoodClient;


        [ColumnName("Score")]
        public float Score;
    }

}