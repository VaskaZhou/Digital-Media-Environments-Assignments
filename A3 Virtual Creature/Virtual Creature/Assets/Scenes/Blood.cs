using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Blood : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Color c= new Color(GetComponent<Renderer>().material.color.r, GetComponent<Renderer>().material.color.g, GetComponent<Renderer>().material.color.b,0);
        GetComponent<Renderer>().material.DOColor(new Color(), 4f).OnComplete(onComplete); // 2√Îƒ⁄ÕÍ≥…Tween
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void onComplete()
    {
        Destroy(gameObject);
    }
}
