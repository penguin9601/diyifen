using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelController : MonoBehaviour {

	private static ModelController _ins;

	public static ModelController Ins
	{
		get
		{
			return _ins;
		}
	}

	void Awake()
    {
		_ins = this;

		//初始化配置表
		Common.ConfigManager.Ins.Init("Config/GameConfig");
		//初始化语言工具
		Common.LanguageTools.Instance.Init("LanguageSetting");
		//初始化本地缓存工具
		Common.LocalData.Instance.Init("DefUser15");
		//游戏配置初始化
		GameConfig.Instance.Init("GameConfigSetting");

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		Common.GameMsg.Instance.update();
	}
}
