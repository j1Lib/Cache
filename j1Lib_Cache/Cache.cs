using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace j1Lib
{
    public static class Cache
    {
        private static Dictionary<string, object> cache = new Dictionary<string, object>();

        private static string getKey(object target, object key)
        {
            return target.ToString() + "_" + key + "_" + target.ToString();
        }

        public static void setCache(this object target, string key, object value)
        {
            if (cache.ContainsKey(getKey(target, key)))
            {
                cache[getKey(target, key)] = value;
            }
            else
            {
                cache.Add(getKey(target, key), value);
            }
        }

        public static object getCache(this object target, string key, object defaults)
        {
            if (cache.ContainsKey(getKey(target, key)))
            {
                return cache[getKey(target, key)];
            }
            else
            {
                return defaults;
            }
        }
    }
}