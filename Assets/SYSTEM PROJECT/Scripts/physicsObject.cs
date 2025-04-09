using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UIElements;

public class physicsObject : MonoBehaviour
{
    public bool isFalling = true;

    public Vector2 velocity;

    public bool isFloor;
    void Start()
    {
        //onCollision();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFalling)
        {
            velocity.y += -0.1f * Time.deltaTime;
        } else
        {
            velocity.y = 0;
        }

        //decay
        if (velocity.x > 0)
        {
            velocity.x -= 0.5f * Time.deltaTime;
        } else if (velocity.x < 0)
        {
            velocity.x += 0.5f * Time.deltaTime;
        }
        

        if (isFloor)
        {
            velocity.x = 0;
            velocity.y = 0;
        }

        transform.position = new Vector2(transform.position.x + velocity.x, transform.position.y + velocity.y);
        
        
    }


    public void onCollision(GameObject s1, GameObject s2)
    {
        //if the collided object is me, stop falling
        if (s1 == gameObject)
        {
            if (s2.name == "floor")
            {
                isFalling = false;
            } else
            {
                physicsObject script = s2.GetComponent<physicsObject>();
                velocity.x += script.velocity.x;
                velocity.y += script.velocity.y;
            }
            

        }
        
    }

    IEnumerator generateImpulse()
    {
        velocity.y = 2;
        yield return Time.deltaTime;
        velocity.y = 0;
    }
}
