using System.Collections;
using System.Collections.Generic;

//游戏常用配置接口
public class GameConfig : Common.Singleton<GameConfig>
{
    //配置名
    private string _configName;

	//值字典
	private Dictionary<string, string> _valueDict;

    private bool _isInit = false;

    //初始化
	public void Init(string configName)
    {
        if(_isInit)
        {
            return;
        }

        _isInit = true;

        _valueDict = new Dictionary<string, string>();
        _configName = configName;
    }


    //获得配置值
	public string GetGameConfigValue(string key)
    {

        if(_valueDict.ContainsKey(key))
        {
            return _valueDict[key];
        }

        var ret = "";

        var lo = Common.ConfigManager.Ins.GetConfigByKey<GameConfigSettingLO>(_configName, "key", key);
        if (lo != null)
        {
            ret = lo.value;
            _valueDict.Add(key, ret);
        }

        return ret;
    }

    //胜利奖励金币
    public int WIN_REWARD_GOLD
    {
        get
        {
            return int.Parse(this.GetGameConfigValue("WIN_REWARD_GOLD"));
        }
    }

    //胜利双倍奖励金币
    public int WIN_REWARD_GOLD_DOUBLE
    {
        get
        {
            return int.Parse(this.GetGameConfigValue("WIN_REWARD_GOLD_DOUBLE"));
        }
    }

    //主页金币广告按钮奖励金币数
    public int MAIN_AD_REWARD_GOLD
    {
        get
        {
            return int.Parse(this.GetGameConfigValue("MAIN_AD_REWARD_GOLD"));
        }
    }
}
