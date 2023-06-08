using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//图片数字
public class ImageNumber : MonoBehaviour 
{
    [SerializeField, Tooltip("字符串key")]
    private string StringKey;
    [SerializeField, Tooltip("路径")]
    private string Path;
    [SerializeField, Tooltip("路径")]
    private float Width;


    private List<GameObject> _objects;

    private ObjectPool<GameObject> _pool;

    void Awake()
    {
        _objects = new List<GameObject>();
        _pool = new ObjectPool<GameObject>();
    }

    void Start()
    {


        //SetString("$123");
    }

    public void SetString(string str)
    {
        for(int i = 0; i < _objects.Count; i++)
        {
            var obj = _objects[i];
            obj.SetActive(false);
            //obj.transform.parent = null;
            _pool.Add(obj);
        }
        _objects.Clear();

        char[] chars = str.ToString().ToCharArray();

        char[] keys = StringKey.ToCharArray();

        float imgX = chars.Length * -Width / 2;
        //遍历字符数组
        foreach (char c in chars)
        {
            var obj = _pool.Get();
            obj.SetActive(true);
            _objects.Add(obj);

            var img = obj.GetComponent<Image>();
            if(img == null)
            {
                img = obj.AddComponent<Image>();
                var rect = obj.GetComponent<RectTransform>();
                rect.anchorMin = new Vector2(0, 0.5f);
                rect.anchorMax = new Vector2(0, 0.5f);
                obj.name = c.ToString();
                obj.transform.SetParent(gameObject.transform);
            }

            //初始化位置
            var pos = new Vector3(imgX, 0);
            obj.transform.localPosition = pos;
            imgX += Width;

            for (int i = 0; i < keys.Length; i++)
            {
                var key = keys[i];

                if(key == c)
                {
                    var sprite = Resources.Load<Sprite>(Path + "/" + key);
                    img.sprite = sprite;
                    img.SetNativeSize();
                    break;
                }
            }
        }
    }
}
