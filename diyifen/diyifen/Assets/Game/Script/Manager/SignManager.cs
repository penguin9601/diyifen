using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignManager : MonoBehaviour
{
    [SerializeField, Tooltip("签到界面预制件")]
    private GameObject SignPanelPrefab;

    private GameObject _panelParent;

	private static SignManager _ins = null;

    public static SignManager Ins
    {
        get
        {
            //if (_ins == null)
            //{
            //    _ins = new SignManager();
            //}

            return _ins;
        }
    }

    void Awake()
    {
        _ins = this;
    }

    void Start()
    {

    }

    //记录签到
    public void MarkSign()
    {
        //签天数+1
        SignData.Ins.SignDay += 1;

        //签到日期记录
        string todayStr = Common.StringUtil.GetNowYMDStr();
        SignData.Ins.LastSignDate = todayStr;
    }

    //检测重置
    public void CheckReSet()
    {
        //如果已经全部签到完毕
        if(SignData.Ins.SignDay == SignData.Ins.Los.Count)
        {
            //并且已经是新的一天
            var today = Common.StringUtil.GetNowYMDStr();
            var lastDay = SignData.Ins.LastSignDate;

            if (today != lastDay)
            {
                //重置
                SignData.Ins.SignDay = 0;
            }
        }
    }

    //登录弹出
    public void CheckLoginPop()
    {
        if(SignData.Ins.IsPop)
        {
            return;
        }

        //如果之前没打开过签到,那么就不要登录时候打开,要在就算时候打开
        if (!SignData.Ins.FristOpenSign)
        {
            return;
        }

        //今天已经领过就不弹了
        if (!IsNewDay)
        {
            return;
        }

        this.OpenSignPanel();
    }

    //结算时候检测
    public void CheckCloseGameResultPop()
    {
        if(SignData.Ins.FristOpenSign)
        {
            return;
        }

        SignData.Ins.FristOpenSign = true;

        //今天已经领过就不弹了
        if (!IsNewDay)
        {
            return;
        }

        this.OpenSignPanel();
    }

    //打开签到界面
    public void OpenSignPanel(Transform parent = null)
    {
        if(parent == null)
        {
            if(_panelParent == null)
            {
                parent = GameObject.FindObjectOfType<Canvas>().transform;
            }
            else
            {
                parent = _panelParent.transform;
            }
        }
        SignData.Ins.IsPop = true;
        Instantiate(SignPanelPrefab, parent);
    }

    //是否新的一天
    public bool IsNewDay
    {
        get
        {
            bool ret = false;

            var today = Common.StringUtil.GetNowYMDStr();
            var lastDay = SignData.Ins.LastSignDate;
            if(today != lastDay)
            {
                ret = true;
            }

            return ret;
        }
    }

    //弹窗父节点
    public GameObject PanelParent
    {
        set
        {
            _panelParent = value;
        }
    }
}
