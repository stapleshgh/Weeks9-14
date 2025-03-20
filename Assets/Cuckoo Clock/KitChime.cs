using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitChime : MonoBehaviour
{
    public AudioSource chime;
    public void Chime()
    {
        if (chime != null && !chime.isPlaying)
        {
            chime.Play();
        }
    }
}
