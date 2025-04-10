using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class hurtBox : MonoBehaviour
{
    [SerializeField] UnityEvent<physicsObject> hurtBoxEntered = new UnityEvent<physicsObject>();

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        


        

        
    }


    public void onCollision(physicsObject s1, physicsObject s2)
    {
        //if the collided object is me, pay attention
        if (s1.gameObject == gameObject)
        {
            


        }


    }

    

   
}
