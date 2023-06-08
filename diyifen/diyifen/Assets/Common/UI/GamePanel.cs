using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Common
{
	public class GamePanel : BaseUI
	{
		//当前弹窗数量
		public static int _curPanelAmount = 0;

		//初始化
		protected void PanelInit()
        {
			_curPanelAmount++;
			//Debug.Log("当前弹窗:" + _curPanelAmount);
			this.UIInit();
		}

		protected void PanelDestroy()
        {
			_curPanelAmount--;
			//Debug.Log("当前弹窗:" + _curPanelAmount);
			this.UIDestroy();
		}

		public void ClosePanel()
        {
			GameObject.Destroy(this.gameObject);
        }

		public static int CurPanelAmount
        {
			get
            {
				return _curPanelAmount;
            }
        }
	}
}

