using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;


namespace Common
{
    public class LocalData : Singleton<LocalData>
    {
        //用户表示
        private string _uid = "";

        public void Init(string uid)
        {
            _uid = uid;
        }

        //设置字符串
        public void SetString(string key, string value)
        {
            PlayerPrefs.SetString(GetKey(key), value);
            PlayerPrefs.Save();
        }

        //获得字符串
        public string GetString(string key, string defaultValue = "")
        {
            var ret = PlayerPrefs.GetString(GetKey(key), defaultValue);
            return ret;
        }

        //设置整形
        public void SetInt(string key, int value)
        {
            PlayerPrefs.SetInt(GetKey(key), value);
            PlayerPrefs.Save();
        }

        //获得整形
        public int GetInt(string key, int defaultValue = 0)
        {
            var ret = PlayerPrefs.GetInt(GetKey(key), defaultValue);
            return ret;
        }

        //设置浮点型
        public void SetFloat(string key, float value)
        {
            PlayerPrefs.SetFloat(GetKey(key), value);
            PlayerPrefs.Save();
        }

        //获得浮点型
        public float GetFloat(string key, float defaultValue = 0.0f)
        {
            var ret = PlayerPrefs.GetFloat(GetKey(key), defaultValue);
            return ret;
        }

        //设置布尔
        public void SetBool(string key, bool value)
        {
            this.SetInt(GetKey("BOOL_" + key), value ? 1 : 0);
            PlayerPrefs.Save();
        }

        //获得布尔
        public bool GetBool(string key, bool defaultValue = false)
        {
            var ret = this.GetInt(GetKey("BOOL_" + key), defaultValue ? 1 : 0);
            return ret == 1;
        }

        public string GetKey(string key)
        {
            var ret = _uid + "_" + key;
            return ret;
        }

        //保存对象
        public void SetObject<T>(string key, T obj)
        {
            var str = JsonMapper.ToJson(obj);
            this.SetString(GetKey("OBJECT_" + key), str);
            PlayerPrefs.Save();
        }

        //获得对象
        public T GetObject<T>(string key)
        {
            T ret = default(T);
            var str = this.GetString(GetKey("OBJECT_" + key));
            if(str.Length > 0)
            {
                ret = JsonMapper.ToObject<T>(str);
            }

            return ret;
        }
    }
}

