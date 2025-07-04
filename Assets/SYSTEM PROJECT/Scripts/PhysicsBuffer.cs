using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicsBuffer : MonoBehaviour
{
    //  arrays for physicsobjects to be simulated and for hurtboxes + enemies to be detected against

    physicsObject[] physicsObjects = null;

    hurtBox[] hurtboxes = null;

    enemyScript[] enemyScripts = null;

    [SerializeField] UnityEvent<physicsObject, physicsObject> onCollisionDetected = new UnityEvent<physicsObject, physicsObject>();
    [SerializeField] UnityEvent<enemyScript, hurtBox> onHurtboxEntered = new UnityEvent<enemyScript, hurtBox>();
    


    void Start()
    {
        physicsObjects = GetComponentsInChildren<physicsObject>();
        hurtboxes = GetComponentsInChildren<hurtBox>();
        enemyScripts = GetComponentsInChildren<enemyScript>();

        foreach (var child in physicsObjects)
        { 
            onCollisionDetected.AddListener(child.onCollision);
        }

        foreach (var child in enemyScripts)
        {
            onHurtboxEntered.AddListener(child.onEnemyHurt);
            child.unSubFromDamageEvent.AddListener(unsub);
            child.SubToDamageEvent.AddListener(sub);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        foreach (var po in physicsObjects)
        {
            checkCollision(po);
        }

        foreach (var h in hurtboxes)
        {
            checkCollisionHurtboxes(h);
        }
        
    }

    //check physics collisions
    void checkCollision(physicsObject s1)
    {
        foreach (physicsObject s2 in physicsObjects)
        {
            if (s1.transform.localPosition.x + (Mathf.Abs(s1.transform.localScale.x) / 2) > s2.transform.localPosition.x - (Mathf.Abs(s2.transform.localScale.x) / 2) &&     // r1 right edge past r2 left
                s1.transform.localPosition.x - (Mathf.Abs(s1.transform.localScale.x) / 2) < s2.transform.localPosition.x + (Mathf.Abs(s2.transform.localScale.x) / 2) &&
                s1.transform.localPosition.y + (Mathf.Abs(s1.transform.localScale.y) / 2) >= s2.transform.localPosition.y - (Mathf.Abs(s2.transform.localScale.y) / 2) &&
                s1.transform.localPosition.y - (Mathf.Abs(s1.transform.localScale.y) / 2) <= s2.transform.localPosition.y + (Mathf.Abs(s2.transform.localScale.y) / 2) && 
                s1.name != s2.name)
            {
                onCollisionDetected.Invoke(s1, s2);
            } 
        }
    }

    //checks collision between hurtboxes and enemies
    void checkCollisionHurtboxes(hurtBox s1)
    {
        foreach (enemyScript s2 in enemyScripts)
        {
            if (s1.transform.position.x + (s1.transform.localScale.x / 2) > s2.transform.position.x - (s2.transform.localScale.x / 2) &&     // r1 right edge past r2 left
                s1.transform.position.x - (s1.transform.localScale.x / 2) < s2.transform.position.x + (s2.transform.localScale.x / 2) &&
                s1.transform.position.y + (s1.transform.localScale.y / 2) >= s2.transform.position.y - (s2.transform.localScale.y / 2) &&
                s1.transform.position.y - (s1.transform.localScale.y / 2) <= s2.transform.position.y + (s2.transform.localScale.y / 2) &&
                s1.name != s2.name)
            {
                onHurtboxEntered.Invoke(s2, s1);
                //StartCoroutine(invincibility(s2));
            }
        }
    }

    

    public void unsub(enemyScript e)
    {
        onHurtboxEntered.RemoveListener(e.onEnemyHurt);

    }

    public void sub(enemyScript e)
    {
        onHurtboxEntered.AddListener(e.onEnemyHurt);
    }
}
