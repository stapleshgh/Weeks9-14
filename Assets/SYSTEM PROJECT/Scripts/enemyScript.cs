using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{

    [SerializeField] physicsObject pScript;

    public bool invincible = false;



    public Animator animator;


    Coroutine idlem;
    // Start is called before the first frame update
    void Start()
    {
        idlem = StartCoroutine(idleMovement());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onEnemyHurt(enemyScript target, hurtBox source)
    {
        if (target.gameObject == gameObject)
        {
            StartCoroutine(invincibilityCoroutine());
            //if hurtbox is to the left, apply impulse to the right, and vice versa
            if (source.transform.position.x > target.transform.position.x)
            {
                pScript.isFalling = true;
                pScript.generateImpulse(-0.01f, 0.03f);
            } else
            {
                pScript.generateImpulse(0.01f, 0.03f);
                pScript.isFalling = true;
            }
           
        }
        
    }

    IEnumerator idleMovementLeft()
    {
        pScript.velocity.x = -0.01f;
        yield return new WaitForSeconds(2);
    }

    IEnumerator idleMovementRight()
    {
        pScript.velocity.x = 0.01f;
        yield return new WaitForSeconds(2);
    }

    IEnumerator idleMovement()
    {
        while (true)
        {
            animator.Play("idleEnemy");
            var left = StartCoroutine(idleMovementLeft());
            yield return left;
            var right = StartCoroutine(idleMovementRight());
            yield return right;
        }
        
    }

    IEnumerator invincibilityCoroutine()
    {
        if (!invincible)
        {
            
            animator.Play("jump");
            StopCoroutine(idlem);
            yield return new WaitForSeconds(3);
            idlem = StartCoroutine(idleMovement());
           

        }
        
    }
}
