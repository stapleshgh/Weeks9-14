using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{

    [SerializeField] physicsObject pScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onEnemyHurt(enemyScript target, hurtBox source)
    {
        if (target.gameObject == gameObject)
        {
            //if hurtbox is to the left, apply impulse to the right, and vice versa
            if (source.transform.position.x > target.transform.position.x)
            {
                pScript.generateImpulse(-0.01f, 0.03f);
            } else
            {
                pScript.generateImpulse(0.01f, 0.03f);
            }
           
        }
        
    }
}
