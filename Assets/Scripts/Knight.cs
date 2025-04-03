using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class Knight : MonoBehaviour
{
    SpriteRenderer sr;
    Animator animator;
    public AudioSource audioSource;
    public AudioClip[] footsteps;

    private CinemachineImpulseSource impulse;

    [SerializeField] private UnityEvent stomp;

    int speed = 5;

    public bool canRun = true;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        float direction = Input.GetAxis("Horizontal");
        sr.flipX = direction < 0;

        

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("attack");
            canRun = false;
        }

        animator.SetFloat("movement", Mathf.Abs(direction));

        if (canRun)
        {
            transform.position += transform.right * direction * speed * Time.deltaTime;
            
        }
        
        
    }

    public void AttackHasFinished()
    {
        canRun = true;
    }

    public void PlayFoostep()
    {
        int footstep = Random.Range(0, footsteps.Length);

        if (audioSource.isPlaying == false)
        {
            audioSource.clip = footsteps[footstep];
            audioSource.Play();
            stomp.Invoke();

        }
        
    }
}
