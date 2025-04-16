using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triangleSpawner : MonoBehaviour
{
    public Object prefab;
    public CinemachineImpulseSource impulse;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

        

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(prefab, mousePos, Quaternion.identity);
            impulse.GenerateImpulse();
            
        }

    }
}
