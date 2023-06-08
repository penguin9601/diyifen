using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

namespace Common
{
    public class LanguageTools : Singleton<LanguageTools>
    {
        //本地化消息 id
        public static int EVENT_ID = 0;

        private const string KEY = "LAN";

        private string _curLan;

        private string _configName;

        private bool _isInit = false;

        public void Init(string configName)
        {
            if(_isInit)
            {
                return;
            }

            _isInit = true;

            //初始化当前语言
            _curLan = PlayerPrefs.GetString(KEY, LanType.cn);
            _configName = configName;
        }

        //获取多语言
        public string GetLan(string id)
        {
            JsonData data = ConfigManager.Ins.GetConfigByKey<JsonData>(_configName, "id", id);

            if(data == null || data[_curLan] == null)
            {
                return id;
            }
            var ret = data[_curLan] + "";
            return ret;
        }

        //通过中文获取多语言
        public string GetLanByCN(string cn)
        {
            JsonData data = ConfigManager.Ins.GetConfigByKey<JsonData>(_configName, LanType.cn, cn);

            if (data == null || data[_curLan] == null)
            {
                return cn;
            }
            var ret = data[_curLan] + "";
            return ret;
        }

        public string GetLan(int id)
        {
            return GetLan(id.ToString());
        }

        //获得当前正在使用的语言
        public string CurLan
        {
            get {
                return _curLan;            
            }
            set {
                _curLan = value;
                PlayerPrefs.SetString(KEY, value);
            }
        }
    }

    public struct LanListData
    {
        public string key;
        public string value;
    }

    public struct LanType
    {
        //中文
        public static string cn = "cn";
        //英文
        public static string en = "en";
    }
}

