using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Common
{
	public class LocalizationText : MonoBehaviour
	{
		[SerializeField, Tooltip("多语言id")]
		private string LanID = "";

		[SerializeField, Tooltip("中文id")]
		private string CN = "";

		private Text _text;

		void Awake()
		{
			_text = this.GetComponent<Text>();
		}

		// Use this for initialization
		void Start()
		{
			GameMsg.Instance.AddMessage(LanguageTools.EVENT_ID, this, new EventHandler<EventArgs>(OnChangeLanguageEventCallBack));

			this.ChangeLanguage();
		}

		void OnDestroy()
		{
			GameMsg.Instance.RemoveMessage(LanguageTools.EVENT_ID, this, new EventHandler<EventArgs>(OnChangeLanguageEventCallBack));
		}

		private void OnChangeLanguageEventCallBack(object sender, EventArgs e)
		{
			this.ChangeLanguage();

		}

		//多语言切换
		protected void ChangeLanguage() 
		{
			if(_text == null)
            {
				return;
            }

			if(LanID.Length > 0)
			{
				_text.text = LanguageTools.Instance.GetLan(LanID);
			}
			else if(CN.Length > 0)
			{
				_text.text = LanguageTools.Instance.GetLanByCN(CN);
			}
		}

		//设置多语言id
		public void SetLanId(string id)
		{
			LanID = id;
			this.ChangeLanguage();
		}

		//设置中文
		public void SetCN(string cn)
		{
			CN = cn;
			LanID = "";
			this.ChangeLanguage();
		}

		//直接设置文本
		public void SetText(string str)
        {
			_text.text = str;
        }
	}
}

