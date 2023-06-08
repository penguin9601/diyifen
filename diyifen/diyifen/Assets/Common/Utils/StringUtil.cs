using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Common
{
    public class StringUtil
    {
        //获得当前年月日字符串
        public static string GetNowYMDStr()
        {
            int year = System.DateTime.Now.Year;
            int month = System.DateTime.Now.Month;
            int day = System.DateTime.Now.Day;
            string key = year + "-" + month + "-" + day;
            return key;
        }

        //单位化
        public static string MoneyFormatKMB(int num)
        {
            string ret = "";
            //int b = 100000000;
            //int m = 10000;
            //int k = 1000;

            Dictionary<string, int> unitsDict = new Dictionary<string, int>();
            unitsDict.Add("B", 100000000);
            unitsDict.Add("M", 10000);
            unitsDict.Add("K", 1000);

            foreach (string key in unitsDict.Keys)
            {
                int unit = unitsDict[key];
                if (num > unit)
                {
                    float fvalue1 = Mathf.Floor(num / (unit / 100));

                    float fvalue2 = fvalue1 / 100;
                    ret = fvalue2.ToString() + key;
                    break;
                }
            }

            if (ret.Length == 0)
            {
                ret = num.ToString();
            }


            return ret;
        }
    }
}

