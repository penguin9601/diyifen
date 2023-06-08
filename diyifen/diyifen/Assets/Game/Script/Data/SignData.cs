using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignData
{
    private static SignData _ins = null;

    //已签到天数key
    private const string SIGN_DAY_KEY = "SIGN_DAY_KEY";
    //最后签到日期标识
    private const string LAST_SIGN_DATE_KEY = "LAST_SIGN_DATE_KEY";

    //首次打开
    private const string FRIST_OPEN_SIGN = "FRIST_OPEN_SIGN";

    //lo数据
    private List<SignSettingLO> _los;

    //已签到天数
    private int _signDay = 0;

    //最后签到日期
    private string _lastSignDate;

    //记录是否打开过签到界面
    private bool _fristOpenSign;

    //这次是否弹过
    private bool _isPop = false;

	public static SignData Ins
    {
        get
        {
            if(_ins == null)
            {
                _ins = new SignData();
            }

            return _ins;
        }
    }

    private SignData()
    {
        //已签到天数
        _signDay = Common.LocalData.Instance.GetInt(SIGN_DAY_KEY, 0);
        _lastSignDate = Common.LocalData.Instance.GetString(LAST_SIGN_DATE_KEY, "2021-1-1");
        _fristOpenSign = Common.LocalData.Instance.GetBool(FRIST_OPEN_SIGN, false);
        _isPop = false;
        //_lastSignDate = "2021-1-1";
    }

    //已签到天数
    public int SignDay
    {
        get
        {
            return _signDay;
        }
        set
        {
            _signDay = value;
            Common.LocalData.Instance.SetInt(SIGN_DAY_KEY, _signDay);
        }
    }

    //最后签到日期
    public string LastSignDate
    {
        get
        {
            return _lastSignDate;
        }
        set
        {
            _lastSignDate = value;
            Common.LocalData.Instance.SetString(LAST_SIGN_DATE_KEY, _lastSignDate);
        }
    }

    //获得los
    public List<SignSettingLO> Los
    {
        get
        {
            if(_los == null)
            {
                _los = Common.ConfigManager.Ins.GetConfig<SignSettingLO>("SignSetting");
            }

            return _los;
        }
    }

    //是否打开过签到界面,如果未打开过,首次需要在游戏结束后再打开
    public bool FristOpenSign
    {
        get
        {
            return _fristOpenSign;
        }
        set
        {
            _fristOpenSign = value;
            Common.LocalData.Instance.SetBool(FRIST_OPEN_SIGN, true);
        }
    }

    //是否弹出过
    public bool IsPop
    {
        get
        {
            return _isPop;
        }
        set
        {
            _isPop = value;
        }
    }
}
