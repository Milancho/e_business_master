using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_business_master_code
{
    [Serializable]
    public enum Education
    {
        ElementarySchool = 6,
        HighSchool = 7,
        HigherSchool = 8,
        College = 9
    }

    public enum Gender
    {
        Male = 1,
        Female = 2,
    }

    public enum MaritalStatus
    {
        Single = 1,
        Married = 2,
        Widower = 3,
        Divorced = 4,
    }
}
