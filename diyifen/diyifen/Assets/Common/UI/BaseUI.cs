using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Common
{
	public class BaseUI : MonoBehaviour
	{

		// Use this for initialization
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{

		}

		//初始化
		protected void UIInit()
		{
			this.ChangeLanguage();
			GameMsg.Instance.AddMessage(LanguageTools.EVENT_ID, this, new EventHandler<EventArgs>(OnChangeLanguageEventCallBack));
		}

		protected void UIDestroy()
		{
			GameMsg.Instance.RemoveMessage(LanguageTools.EVENT_ID, this, new EventHandler<EventArgs>(OnChangeLanguageEventCallBack));
		}

		private void OnChangeLanguageEventCallBack(object sender, EventArgs e)
		{
			this.ChangeLanguage();

		}

		//多语言切换
		protected virtual void ChangeLanguage() { }

		//按钮点击回调
		public virtual void OnClickBtn(Button btn) { }

		//消息监听
		protected virtual void OnMsg(object sender, EventArgs e){ }

		//列表按钮点击回调
		public virtual void OnClickListBtn(Button btn,int index) { }

		//添加按钮监听
		protected void AddButtonListener(Button btn)
		{
			btn.onClick.AddListener(delegate {
				this.OnClickBtn(btn);
			});
		}

		//添加列表按钮监听
		protected void AddListButtonListener(Button btn, int index)
		{
			btn.onClick.AddListener(delegate {
				this.OnClickListBtn(btn, index);
			});
		}
	}
}

