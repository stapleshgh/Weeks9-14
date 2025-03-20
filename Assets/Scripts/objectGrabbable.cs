using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Unity.UI;
using System.Security.Cryptography;

public class objectGrabbable : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    

    

    public void OnBeginDrag(PointerEventData eventData)
    {
        
        Debug.Log("Start drag");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("end drag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        
        
    }


}
