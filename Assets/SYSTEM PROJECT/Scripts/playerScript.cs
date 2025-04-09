using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{

    public Vector2 velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) && velocity.x < 0.3f)
        {
            velocity.x += 0.1f * Time.deltaTime; ;
        } else if (Input.GetKey(KeyCode.A) && velocity.x > -0.3f)
        {
            velocity.x += -0.1f * Time.deltaTime; ;
        } else
        {
            if (velocity.x > 0)
            {
                velocity.x -= 0.1f * Time.deltaTime;
            } else if (velocity.x < 0)
            {
                velocity.x += 0.1f * Time.deltaTime;
            }
        }


        transform.position = new Vector2(transform.position.x + velocity.x, transform.position.y + velocity.y);

    }
}
