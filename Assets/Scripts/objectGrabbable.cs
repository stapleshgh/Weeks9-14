using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Unity.UI;
using System.Security.Cryptography;

public class objectGrabbable : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    Transform dragParent;

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        dragParent = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        Debug.Log("Star drag");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("end drag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.SetParent(dragParent);
        
    }


}
