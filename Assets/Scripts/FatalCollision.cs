using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatalCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            Player player = (Player)collision.gameObject.GetComponent(typeof(Player));
            StartCoroutine(player.Die());
        }
    }
}
