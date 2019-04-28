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

    public enum RepaymentFrequencyEnum
    {
        Monthly = 1,
        BiMonthly = 2,
        Quarterly = 3,
        SemiYearly = 6,
        Yearly = 12,
        Weekly = 7,
        BiWeekly = 14,
        SemiMonthly = 15,
        Daily = 44
    }

    public enum PeriodicInterestRateEnum
    {
        Yearly = 1,
        Monthly = 2,
        Daily = 3
    }

    public enum CalculationInterestRateEnum
    {
        MethodActualActual = 11,
        Method30360 = 12,
        Method30Actual = 13,
        Method31360 = 14,
        Method31Actual = 15,
        MethodActual360 = 16
    }

}
