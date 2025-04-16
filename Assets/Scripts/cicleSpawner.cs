using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class cicleSpawner : MonoBehaviour
{
    public GameObject prefab;

    public List<GameObject> prefabs = new List<GameObject>();

    public Scrollbar sb;
    void Start()
    {
        sb.onValueChanged.AddListener(shrinkGrowCircle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnCircle()
    {
        var p = Instantiate(prefab, new Vector2(Random.Range(-8.3f, 8.3f), Random.Range(-4.4f, 4.4f)), Quaternion.identity);
        prefabs.Add(p);
    }

    public void shrinkGrowCircle(float val)
    {
        Debug.Log(val);
        foreach (GameObject circle in prefabs)
        {
            circle.transform.localScale = new Vector2(val, val);
            Debug.Log(circle);
        }
    }
}
