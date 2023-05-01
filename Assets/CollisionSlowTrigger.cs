using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSlowTrigger : MonoBehaviour
{

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerBehaviour playerBehaviour = collision.gameObject.GetComponent<PlayerBehaviour>();
            playerBehaviour.applySlow(3);

            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
}
