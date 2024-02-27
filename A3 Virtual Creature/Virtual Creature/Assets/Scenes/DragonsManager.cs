using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonsManager : MonoBehaviour
{
    public List<Dragon> Dragons;
    public GameObject[] DragonPrefab;
    public static DragonsManager instance;
    public bool PreventExtinctionMode = true;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        float k = Random.Range(7, 12);
        for (int i= 0; i < k; i++)
        {
            CreateDragon();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(PreventExtinctionMode) if (Dragons.Count < 5) { if (Random.Range(0, 100) > 98f) CreateDragon(); }
    }

    public void CreateDragon()
    {
        if (Random.Range(0, 100) > 50f)
        {
            Instantiate(DragonPrefab[0]).GetComponent<Dragon>().dragonInfo.gender = true;
        }
        else
        {
            Instantiate(DragonPrefab[1]).GetComponent<Dragon>().dragonInfo.gender = false;
        }
    }
}
