using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using e_business_webapi;
using e_business_webapi.Models;

namespace e_business_master_code.Shared
{
    public static class ExtensionMethods
    {
        public static CustomerModel CustomerValues(this string line)
        {
            var values = line.Split(',');
            var customer = new CustomerModel
            {
                EducationId = Convert.ToInt32(values[0]),
                Gender = Convert.ToInt16(values[1]),
                MaritalStatus = Convert.ToInt32(values[2]),
                Age = Convert.ToInt32(values[3]),
                Label = Convert.ToString(values[4]),
            };
            return customer;
        }

        public static CardStatusModel CardStatusValues(this string line)
        {
            var values = line.Split(',');
            var cardStatus = new CardStatusModel
            {
                Score = Convert.ToDecimal(values[0]),
                Decision = values[1],
            };
            return cardStatus;
        }

        public static PersonalDataModel PersonalDataValues(this string line)
        {
            var values = line.Split(',');
            var personalData = new PersonalDataModel
            {
                Group = values[0],
                Education = values[1],
                Age = values[2],
                Weight = values[3],
                Score = values[4],
            };
            return personalData;
        }

        public static FamilyDataModel FamilyDataValues(this string line)
        {
            var values = line.Split(',');
            var familyData = new FamilyDataModel()
            {
                Group = values[0],
                Gender = values[1],
                MaritalStatus = values[2],
                Weight = values[3],
                Score = values[4],
            };
            return familyData;
        }
        public static string GetByKey(this string key)
        {
            return Translation.Data[key];
        }

    }
}
