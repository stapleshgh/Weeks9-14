using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicsBuffer : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject[] physicsObjects = null;

    [SerializeField] UnityEvent<GameObject> onCollisionDetected = new UnityEvent<GameObject>();

    void Start()
    {
        physicsObjects = GameObject.FindGameObjectsWithTag("physicsObject");

        foreach (var po in physicsObjects)
        {

            physicsObject script = po.GetComponent<physicsObject>();
            onCollisionDetected.AddListener(script.onCollision);
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

    void checkCollision(GameObject s1)
    {
        foreach (GameObject s2 in physicsObjects)
        {
            if (s1.transform.localPosition.x + (s1.transform.localScale.x / 2) > s2.transform.localPosition.x - (s2.transform.localScale.x / 2) &&     // r1 right edge past r2 left
                s1.transform.localPosition.x - (s1.transform.localScale.x / 2) < s2.transform.localPosition.x + (s2.transform.localScale.x / 2) &&
                s1.transform.localPosition.y + (s1.transform.localScale.y / 2) >= s2.transform.localPosition.y - (s2.transform.localScale.y/ 2) &&
                s1.transform.localPosition.y - (s1.transform.localScale.y / 2) <= s2.transform.localPosition.y + (s2.transform.localScale.y / 2) && 
                s1.name != s2.name)
            {
                Debug.Log("colliding");
                onCollisionDetected.Invoke(s1);
            } else
            {
                
            }
            
        }
    }
}
