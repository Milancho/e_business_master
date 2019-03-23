using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_business_webapi
{
    public static class Translation
    {
        public static Dictionary<string, string> Data = new Dictionary<string, string>()
            {
                {

                    "ElementarySchool", "Основно"
                },
                {
                    "HighSchool", "Средно"
                },
                {
                    "HigherSchool", "Вишо"
                },
                {
                    "College", "Факултет"
                },
                {
                    "Male", "Машко"
                },
                {
                    "Female", "Женско"
                },
                {
                    "Single", "Неженет/Немажена"
                },
                {
                    "Married", "Во брак"
                },
                {
                    "Widower", "Вдовец/Вдовица"
                },
                {
                    "Divorced", "Разведен/Разведенa"
                },
            };
        
    }
}
