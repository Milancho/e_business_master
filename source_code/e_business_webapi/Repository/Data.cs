using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using e_business_master_code;
using e_business_master_code.Shared;

namespace e_business_webapi.Repository
{
    public static class Data
    {

        public static readonly List<KeyValuePair<int, string>> EducationList = new List<KeyValuePair<int, string>>()
        {
            new KeyValuePair<int, string>( 6, Education.ElementarySchool.ToString().GetByKey() ),
            new KeyValuePair<int, string>( 7, Education.HighSchool.ToString().GetByKey() ),
            new KeyValuePair<int, string>( 8, Education.HigherSchool.ToString().GetByKey()),
            new KeyValuePair<int, string>( 9, Education.College.ToString().GetByKey())
        };

        public static readonly List<KeyValuePair<int, string>> GenderList = new List<KeyValuePair<int, string>>()
        {
            new KeyValuePair<int, string>( 1, Gender.Male.ToString().GetByKey()),
            new KeyValuePair<int, string>( 2, Gender.Female.ToString().GetByKey())
        };

        public static readonly List<KeyValuePair<int, string>> MaritalStatusList = new List<KeyValuePair<int, string>>()
        {
            new KeyValuePair<int, string>(1, MaritalStatus.Single.ToString().GetByKey() ),
            new KeyValuePair<int, string>(2, MaritalStatus.Married.ToString().GetByKey()),
            new KeyValuePair<int, string>(3,  MaritalStatus.Widower.ToString().GetByKey()),
            new KeyValuePair<int, string>(4,  MaritalStatus.Divorced.ToString().GetByKey())
        };

    }
}
