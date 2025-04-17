using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class mouseOverOutline : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Outline outline;
    public ParticleSystem ps;

    public void OnPointerEnter(PointerEventData eventData)
    {
        outline.enabled = true;
        ps.Play();
        Debug.Log("entered");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        outline.enabled = false;
        Debug.Log("exited");
        ps.Stop();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
