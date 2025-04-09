using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UIElements;

public class physicsObject : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector2 velocity;
    void Start()
    {
        onCollision();
    }

    // Update is called once per frame
    void Update()
    {
        
        

        if (transform.position.y - transform.localScale.y / 2 < -4)
        {
            velocity.y = 0;
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.01f);
        } else
        {
            velocity.y += -0.01f;
        }

        transform.position = new Vector2(transform.position.x + velocity.x, transform.position.y + velocity.y);
    }


    public void onCollision()
    {
        StartCoroutine(generateImpulse());
    }

    IEnumerator generateImpulse()
    {
        velocity.y = 2;
        yield return Time.deltaTime;
        velocity.y = 0;
    }
}
