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
    void Start()
    {
        //onCollision();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFalling)
        {
            velocity.y += -0.01f * Time.deltaTime;
        } else
        {
            velocity.y = 0;
        }

        transform.position = new Vector2(transform.position.x + velocity.x, transform.position.y + velocity.y);
        

    }


    public void onCollision(GameObject s1)
    {
        //if the collided object is me, stop falling
        if (s1 == gameObject)
        {
            isFalling = false;
        }
        
    }

    IEnumerator generateImpulse()
    {
        velocity.y = 2;
        yield return Time.deltaTime;
        velocity.y = 0;
    }
}
