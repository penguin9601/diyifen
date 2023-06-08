﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

[DisallowMultipleComponent]
public class UIGray : MonoBehaviour
{
	private bool _isGray = false;
	public bool isGray
	{
		get { return _isGray; }
		set
		{
			if (_isGray != value)
			{
				_isGray = value;
				SetGray(isGray);
			}
		}
	}

	static private Material _defaultGrayMaterial;
	static private Material grayMaterial
	{
		get
		{
			if (_defaultGrayMaterial == null)
			{
				_defaultGrayMaterial = new Material(Shader.Find("UI/Gray"));
			}
			return _defaultGrayMaterial;
		}
	}
	/// <summary>
	/// 置灰，遍历节点所有图片设置灰色材质。
	/// </summary>
	/// <param name="isGray">If set to <c>true</c> is gray.</param>
	void SetGray(bool isGray)
	{
		int i = 0, count = 0;
		Image[] images = transform.GetComponentsInChildren<Image>();
		count = images.Length;
		for (i = 0; i < count; i++)
		{
			Image g = images[i];
			if (isGray)
			{
				g.material = grayMaterial;
			}
			else
			{
				g.material = null;
			}
		}
	}
}
#if UNITY_EDITOR
[CustomEditor(typeof(UIGray))]
public class UIGrayInspector : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		UIGray gray = target as UIGray;
		gray.isGray = GUILayout.Toggle(gray.isGray, " isGray");
		if (GUI.changed)
		{
			EditorUtility.SetDirty(target);
		}
	}
}
#endif