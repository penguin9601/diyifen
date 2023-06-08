using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

namespace Common
{
    public class ConfigManager
    {
        private static ConfigManager _ins;

        //配置json数据
        private JsonData _originJd;

        //解析后保存的数据   表格名            key值             value值    JsonData数据列表       
        private Dictionary<string,Dictionary<string,Dictionary<string, List<JsonData>>>> _configDict;

        //配置表列表字典
        private Dictionary<string, List<JsonData>> _configListMap;

        //是否初始化，避免重复初始化
        private bool _isInit = false;

        private ConfigManager()
        {

        }
        public static ConfigManager Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new ConfigManager();
                }

                return _ins;
            }
        }

        //初始化
        public void Init(string jsonPath)
        {
            if(_isInit)
            {
                return;
            }

            _isInit = true;

            //读取json源氏数据
            TextAsset json = Resources.Load(jsonPath) as TextAsset;
            _originJd = JsonMapper.ToObject<JsonData>(json.text);

            //_configMaps = JsonMapper.ToObject("{}");
            _configDict = new Dictionary<string, Dictionary<string, Dictionary<string, List<JsonData>>>>();

            _configListMap = new Dictionary<string, List<JsonData>>();

            IDictionary allDict = _originJd as IDictionary;
            //解析数据
            foreach (string key in allDict.Keys)
            {
                //[configName][keyName][value] = 
                _configDict.Add(key, new Dictionary<string, Dictionary<string, List<JsonData>>>());

                _configListMap.Add(key, new List<JsonData>());

                //key = "LanguageTypeSetting"
                //configDict = {"1":{"id":1,"type":"en","desc":"English"},"2":{"id":2,"type":"cn","desc":"中文"}}
                IDictionary configDict = allDict[key] as IDictionary;
                foreach (string indexStr in configDict.Keys)
                {
                    //indexStr = "1"
                    //objDict = {"id":1,"type":"en","desc":"English"}
                    IDictionary objDict = configDict[indexStr] as IDictionary;

                    _configListMap[key].Add(objDict as JsonData);

                    foreach (string objKey in objDict.Keys)
                    {

                        //objKey = "id"
                        //value = 1
                        var value = objDict[objKey];

                        var configTier = _configDict[key];
                        if (!configTier.ContainsKey(objKey))
                        {
                            configTier.Add(objKey, new Dictionary<string, List<JsonData>>());
                        }

                        var keyTier = configTier[objKey];
                        try
                        {
                            var valueStr = value.ToString();
                            if (!keyTier.ContainsKey(valueStr))
                            {
                                keyTier.Add(valueStr, new List<JsonData>());
                            }

                            var list = keyTier[valueStr];
                            list.Add(objDict as JsonData);
                        }
                        catch
                        {
                            Debug.Log("表格初始化错误:" + key + "." + indexStr + "." + objKey + "." + value);
                        }
                    }
                }

            }

        }


        //获得某行配置
        public T GetConfigByKey<T>(string configName,string keyName,string value)
        {
            T ret = default(T);

            if (_configDict == null)
            {
                return ret;
            }

            if (_configDict.ContainsKey(configName) &&
                _configDict[configName].ContainsKey(keyName) &&
                _configDict[configName][keyName].ContainsKey(value) &&
                _configDict[configName][keyName][value].Count > 0)
            {
                ret = JsonMapper.ToObject<T>(JsonMapper.ToJson(_configDict[configName][keyName][value][0]));
            }

            return ret;
        }

        //根据值，获取一组相同值的配置
        public List<T> GetConfigGroupByKey<T>(string configName, string keyName, string value)
        {
            List<T> ret = new List<T>();

            if (_configDict != null && 
                _configDict.ContainsKey(configName) &&
                _configDict[configName].ContainsKey(keyName) &&
                _configDict[configName][keyName].ContainsKey(value))
            {
                List<JsonData> jsonList = _configDict[configName][keyName][value];
                for (int i = 0; i < jsonList.Count; i++)
                {
                    var lo = JsonMapper.ToObject<T>(JsonMapper.ToJson(_configDict[configName][keyName][value][i]));
                    ret.Add(lo);
                }
            }

            return ret;
        }

        //通过id获得配置
        public T GetConfigById<T>(string configName, string value)
        {
            return this.GetConfigByKey<T>(configName, "id", value);
        }

        //通过id获得配置
        public T GetConfigById<T>(string configName, int value)
        {
            return this.GetConfigByKey<T>(configName, "id", value.ToString());
        }

        //获得整个配置表
        public List<T> GetConfig<T>(string configName)
        {
            var ret = new List<T>();

            if (_configListMap == null || !_configListMap.ContainsKey(configName))
            {
                return ret;
            }

            var list = _configListMap[configName];
            for (int i = 0; i < list.Count; i++)
            {
                ret.Add(JsonMapper.ToObject<T>(JsonMapper.ToJson(list[i])));
            }

            return ret;
        }
    }
}

