using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KitClock : MonoBehaviour
{
    public float timeAnHourTakes = 5;

    public Transform minuteHand;
    public Transform hourHand;

    public float t;
    public int hour = 0;

    public UnityEvent OnTheHour;

    public AudioSource chime;

    Coroutine ClockCoroutine;

    void Start()
    {
        ClockCoroutine = StartCoroutine(MoveClock());
    }

    private IEnumerator MoveClock()
    {

        while (true)
        {
            yield return StartCoroutine(MoveTheClockHandsOneHour());
        }
       

    }

    private IEnumerator MoveTheClockHandsOneHour()
    {
        t = 0;
        while(t < timeAnHourTakes)
        {
            t += Time.deltaTime;
            minuteHand.Rotate(0, 0,  -(360 / timeAnHourTakes) * Time.deltaTime);
            hourHand.Rotate(0, 0, -(30 / timeAnHourTakes) * Time.deltaTime);
            yield return null;

        }
        OnTheHour.Invoke();
        hour++;
    }

    private IEnumerator PlayChime()
    {
        while (true)
        {
            chime.Play();
            yield return null;
        }
    }
}
