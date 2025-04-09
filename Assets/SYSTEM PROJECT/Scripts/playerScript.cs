using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{

    public Vector2 velocity;

    public physicsObject pScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            pScript.velocity.x = 4f * Time.deltaTime; ;
        } else if (Input.GetKey(KeyCode.A))
        {
            pScript.velocity.x = -4f * Time.deltaTime; ;
        } else
        {
            pScript.velocity.x = 0;
        }

        if (Input.GetKey(KeyCode.Space) && !pScript.isFalling)
        {
            pScript.isFalling = true;
            pScript.velocity.y = 5f * Time.deltaTime;
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.5f);
            
        }

        

    }
}
