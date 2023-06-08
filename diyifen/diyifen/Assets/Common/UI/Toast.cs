using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Toast : MonoBehaviour {
	[SerializeField]
	private Common.LocalizationText LanText;

	[SerializeField]
	private CanvasGroup CanvasGroup;

	private Sequence _seq;

	// Use this for initialization
	void OnEnable () 
	{

	}

	void Start()
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnDestroy()
    {
		
    }

	//设置多语言id
	public void SetLanId(string id)
	{
		LanText.SetLanId(id);
	}

	//设置中文
	public void SetCN(string cn)
	{
		LanText.SetCN(cn);
	}

	//直接设置文本
	public void SetText(string str)
	{
		LanText.SetText(str);
	}

	public void Run()
	{
		//检测父节点
		gameObject.transform.SetAsLastSibling();

		this.gameObject.SetActive(true);

		CanvasGroup.alpha = 0;
		transform.localPosition = Vector3.zero;

		if(_seq != null)
		{
			_seq.Kill();
		}

		_seq = DOTween.Sequence();
		_seq.Append(CanvasGroup.DOFade(1, 0.5f));
		_seq.Join(transform.DOLocalMoveY(30, 0.5f));

		_seq.AppendInterval(3);

		_seq.Append(CanvasGroup.DOFade(0, 0.5f));

		_seq.AppendCallback(HideSelf);
	}

	void HideSelf()
	{
		_seq.Kill();
		_seq = null;
		this.gameObject.SetActive(false);
    }
}
