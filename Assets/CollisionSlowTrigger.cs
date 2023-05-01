using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSlowTrigger : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerBehaviour playerBehaviour = collision.gameObject.GetComponent<PlayerBehaviour>();
            playerBehaviour.applySlow(3);
        }
    }
}
