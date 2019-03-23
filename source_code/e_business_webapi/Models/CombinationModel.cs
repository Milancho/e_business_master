using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_business_webapi.Models
{
    public class CombinationModel
    {
        public string Group { get; set; }
        public string Weight { get; set; }
        public string Score { get; set; }
    }

    public class PersonalDataModel : CombinationModel
    {
        public string Education { get; set; }
        public string Age { get; set; }
    }

    public class FamilyDataModel : CombinationModel
    {
        public string Gender  { get; set; }
        public string MaritalStatus  { get; set; }
    }

}