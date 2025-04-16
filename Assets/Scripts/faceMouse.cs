using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class faceMouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var mousePos =  (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.up = ((Vector2)transform.position - mousePos) * -1;


        transform.position = Vector2.MoveTowards(transform.position, mousePos, Time.deltaTime);
    }
}
