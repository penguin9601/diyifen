﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextContentSizeFitter : MonoBehaviour 
{
    public Text m_targetText;

    private string m_old;

    void Update()
    {
        if (null == m_targetText) return;

        if (m_old != m_targetText.text)
        {
            m_old = m_targetText.text;
            UpdateSize();
        }
    }

    public void UpdateSize()
    {
        if (null == m_targetText) return;

        var rtf = transform as RectTransform;
        var old = rtf.sizeDelta;
        old.x = m_targetText.preferredWidth;
        rtf.sizeDelta = old;
    }
}
