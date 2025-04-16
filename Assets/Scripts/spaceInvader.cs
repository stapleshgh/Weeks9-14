using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceInvader : MonoBehaviour
{

    public SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKey(KeyCode.Space)) 
        {
            sr.color = Color.blue;
        }
       
    }
}
