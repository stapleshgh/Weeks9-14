using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class physicsObject : MonoBehaviour
{
    public bool isFalling = true;

    public Vector2 velocity;

    public Sprite sprite;

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


        //if the object is marked as static, it stays in place
        if (isFloor)
        {
            velocity.x = 0;
            velocity.y = 0;
        }

        //decay
        velocity = Vector2.Lerp(velocity, new Vector2(0, velocity.y), Time.deltaTime * 4);

        //applying the velocity to the position
        transform.position = new Vector2(transform.position.x + velocity.x, transform.position.y + velocity.y);
        
        if (transform.position.x > 9)
        {
            transform.position = new Vector2(9, transform.position.y + velocity.y);
        }

        checkBounds();
    }


    public void onCollision(physicsObject s1, physicsObject s2)
    {
        //if the collided object is me, pay attention
        if (s1.gameObject == gameObject)
        {
            if (s2.name == "floor")
            {
                isFalling = false;
            } else
            {
                // if x is greater, apply positive repulsion. if x is lower, apply negative repulsion
                if (s1.transform.position.x > s2.transform.position.x)
                {
                    s1.transform.position = new Vector2(s2.transform.position.x + s2.transform.localScale.x, s1.transform.position.y);
                    
                } else if (s1.transform.position.x < s2.transform.position.x)
                {
                    s1.transform.position = new Vector2(s2.transform.position.x - s2.transform.localScale.x, s1.transform.position.y);
                }

                

                
            }
            
            
        }
        
        
    }

    public void generateImpulse(float powerX, float powerY)
    {
        velocity.x = powerX;
        velocity.y = powerY;
        
    }

    public void checkBounds()
    {
        if ( transform.position.x > Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x)
        {
            transform.position = new Vector2(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x, transform.position.y);
        }
        if (transform.position.x < Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x)
        {
            transform.position = new Vector2(Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x, transform.position.y);
        }

        if (transform.position.y < Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y)
        {
            transform.position = new Vector2(transform.position.x, Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y + transform.localScale.y / 2);
            isFalling = false;
        }
    }
}
