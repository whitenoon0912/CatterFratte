using System.Collections;
using UnityEngine;

public class textManager : MonoBehaviour
{
    public GameObject textobj;
    public bool isClickActive = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(textPos(new Vector2(392f, 180f), 1.5f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator textPos(Vector2 target, float delay)
    {
        if (textobj == null) yield break;
        RectTransform rect = textobj.GetComponent<RectTransform>();
        Vector2 startpos = rect.anchoredPosition;
        Vector2 endpos = target;

        float t = 0;
        while(t < 1f)
        {
            t += Time.deltaTime / delay;
            rect.anchoredPosition = Vector2.Lerp(startpos, endpos, Mathf.Clamp01(t));
            yield return null;
        }
        rect.anchoredPosition = endpos;
    }
}
