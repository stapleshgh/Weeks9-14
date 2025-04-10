using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicsBuffer : MonoBehaviour
{
    // Start is called before the first frame update

    physicsObject[] physicsObjects = null;

    [SerializeField] UnityEvent<physicsObject, physicsObject> onCollisionDetected = new UnityEvent<physicsObject, physicsObject>();

    void Start()
    {
        physicsObjects = GetComponentsInChildren<physicsObject>();

        foreach (var child in physicsObjects)
        {

            
            onCollisionDetected.AddListener(child.onCollision);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
        foreach (var po in physicsObjects)
        {
            checkCollision(po);
            //Debug.Log(po.name + " " + (po.transform.localPosition.y + (po.transform.localScale.y / 2)));
            
        }
    }

    void checkCollision(physicsObject s1)
    {
        foreach (physicsObject s2 in physicsObjects)
        {
            if (s1.transform.localPosition.x + (s1.transform.localScale.x / 2) > s2.transform.localPosition.x - (s2.transform.localScale.x / 2) &&     // r1 right edge past r2 left
                s1.transform.localPosition.x - (s1.transform.localScale.x / 2) < s2.transform.localPosition.x + (s2.transform.localScale.x / 2) &&
                s1.transform.localPosition.y + (s1.transform.localScale.y / 2) >= s2.transform.localPosition.y - (s2.transform.localScale.y/ 2) &&
                s1.transform.localPosition.y - (s1.transform.localScale.y / 2) <= s2.transform.localPosition.y + (s2.transform.localScale.y / 2) && 
                s1.name != s2.name)
            {
                Debug.Log("colliding");
                onCollisionDetected.Invoke(s1, s2);
            } else
            {
                
            }
            
        }
    }
}
