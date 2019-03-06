using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace client_app.Shared
{
    public static class Functions
    {
        public static List<KeyValuePair<int, string>> GetEnumList<T>()
        {
            var list = new List<KeyValuePair<int, string>>();
            foreach (var e in Enum.GetValues(typeof(T)))
            {
                list.Add(new KeyValuePair<int, string>((int)e, e.ToString()));
            }
            return list;
        }

        public static KeyValuePair<int, string> GetEnumKeyValuePair<T>(int value)
        {
            var stringValue = Enum.GetName(typeof(T), value);
            return new KeyValuePair<int, string>(value, stringValue);
        }
    }
}


