using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class UIController : MonoBehaviour
{
	[SerializeField, Tooltip("免费道具面板预制体")]
	GameObject FreeItemPanelPrefab;

	[SerializeField, Tooltip("成就界面预制件")]
	public GameObject TaskPanelPrefab;

	[SerializeField, Tooltip("通用领网赚余额界面")]
	public GameObject CashClaimPanelPrefab;

	[SerializeField, Tooltip("点击票金币文本")]
	public GameObject ClickMoneyTipsPrefab;

	private static UIController _ins;

	//是否DontDestroyOnLoad处理
	private static bool isNoDestroy = false;

	public static UIController Ins
    {
        get{
			return _ins;
        }
    }

	void Awake()
    {
		UIController._ins = this;
	}

	// Use this for initialization
	void Start () {
		//放置销毁此对象
		if(!isNoDestroy)
		{
			DontDestroyOnLoad(gameObject);
			isNoDestroy = true;
		}

		SignManager.Ins.PanelParent = this.PanelLayer;
	}

    // Update is called once per frame
    void Update () {
	}

	//打开预制件panel
	public GameObject OpenPrefabPanel(GameObject prefab)
    {
		if(prefab == null)
        {
			return null;
        }

		return Instantiate(prefab, this.PanelLayer.transform);
    }


	//打开成就界面 
	public void OpenTaskPanel()
	{
		this.OpenPrefabPanel(TaskPanelPrefab);
	}


	//切换场景
	public void ChangeScene(string path)
	{
		SceneManager.LoadScene(path);

		//this.InitLayer();
	}

	public Vector3 Center
    {
		get
		{
            var canvasRect = Canvas.GetComponent<RectTransform>();
            var center = canvasRect.position;
			return new Vector3(center.x, center.y);
        }
	}

	//主画布
	public GameObject Canvas
    {
        get
        {
			GameObject ret = null;
			var canvas = GameObject.FindObjectOfType<Canvas>();
			if(canvas)
            {
				ret = canvas.gameObject;

			}
			return ret;
		}
	}

	//获得panel层
	public GameObject PanelLayer
    {
        get
        {
			var canvas = this.Canvas;
			var layer = canvas.transform.Find("PanelLayer");

			if(layer != null)
            {
				return layer.gameObject;
            }

			return canvas;
        }
    }

	//获得导航层
	public GameObject NavigationLayer
	{
        get
        {
			var canvas = this.Canvas;
			var layer = canvas.transform.Find("NavigationLayer");

			if(layer != null)
            {
				return layer.gameObject;
            }

			return canvas;
        }
    }
}
