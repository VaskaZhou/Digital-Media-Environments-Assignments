using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Heart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DORotate(new Vector3(90, 2400f, 0f), 4f, RotateMode.FastBeyond360); 
        transform.DOMoveY(transform.position.y + 1.5f, 4.1f).OnComplete(onComplete); 
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
