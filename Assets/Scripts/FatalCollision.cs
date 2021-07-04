using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatalCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Mouvement playerMov = (Mouvement)collision.gameObject.GetComponent(typeof(Mouvement));

            if (playerMov.IsDashing)
            {
                Destroy(gameObject, 0.2f);
            } //StartCoroutine(GetComponent<EnemyMovement>().Die());
            else
            {
                Player player = (Player)collision.gameObject.GetComponent(typeof(Player));
                StartCoroutine(player.Die());
            } 
        }
    }
}
