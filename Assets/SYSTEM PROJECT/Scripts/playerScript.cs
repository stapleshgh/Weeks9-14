using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerScript : MonoBehaviour
{

    public Vector2 velocity;

    public physicsObject pScript;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            pScript.velocity.x = 10f * Time.deltaTime; ;
        } else if (Input.GetKey(KeyCode.A))
        {
            pScript.velocity.x = -10f * Time.deltaTime; ;
        } 
        

        if (Input.GetKeyDown(KeyCode.Space) && !pScript.isFalling)
        {
            pScript.isFalling = true;
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.5f);
            pScript.generateImpulse(pScript.velocity.x, 0.03f);
            
        }

        if (Input.GetMouseButtonDown(0)) { 
            animator.Play("punch");
        }

        

    }

    
}
