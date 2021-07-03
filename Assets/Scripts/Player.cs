using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int nbLives = 3;


    public void Die()
    {
        if (--nbLives == 0) 
            GameManager.Instance.GameOver();
    }
}
