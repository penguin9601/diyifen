using NUnit;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;

public class movetest : MonoBehaviour {

    public Vector3 endPos = new Vector3(50,50,0);
    private float t = 500f;
    private float currentTime;

    private void Update()
    {
        if (Vector2.Distance(transform.position, endPos) <= 0.2f)
        {
            transform.position = endPos;
            currentTime = 0;
        }
        currentTime += Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, endPos, currentTime/t);
    }

}
