using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class Knight : MonoBehaviour
{
    SpriteRenderer sr;
    Animator animator;

    int speed = 5;

    public bool canRun = true;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        float direction = Input.GetAxis("Horizontal");
        sr.flipX = direction < 0;

        

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("attack");
            canRun = false;
        }


        if (canRun && direction != 0)
        {
            transform.position += transform.right * direction * speed * Time.deltaTime;
            animator.SetFloat("movement", Mathf.Abs(direction));
        }
        
        
    }

    public void AttackHasFinished()
    {
        canRun = true;
    }
}
