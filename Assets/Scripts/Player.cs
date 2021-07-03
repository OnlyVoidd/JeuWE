using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int nbLives = 3;

    [SerializeField]
    private float spawnCooldown = 1.5f;

    [SerializeField]
    private Behaviour[] componentsToDisable;

    private Rigidbody2D rb;

    private float gravity;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gravity = rb.gravityScale;
    }

    public IEnumerator Die()
    {
        nbLives--;
        if (nbLives == 0)
        {
            GameManager.Instance.GameOver(this);
        } 
        else
        {
            ToggleComponents();

            rb.velocity = Vector2.zero;

            rb.gravityScale = 0f;

            yield return new WaitForSeconds(spawnCooldown);
            GetComponent<Rigidbody2D>().MovePosition(GameManager.Instance.SpawnPoint.position);

            ToggleComponents(true);

            rb.gravityScale = gravity;
        }
    }

    public void ToggleComponents(bool value = false)
    {
        foreach(Behaviour c in componentsToDisable)
        {
            c.enabled = value;
        }
    }

    public void ResetLives() => nbLives = 3;
}
