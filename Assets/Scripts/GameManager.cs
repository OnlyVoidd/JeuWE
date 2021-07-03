using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    private static GameManager instance;

    private Transform currentSpawnPoint;


    public static GameManager Instance
    {
        get
        {
            if (instance == null) instance = new GameManager();

            return instance;
        }
    }


    public void GameOver(Player player)
    {
        player.ResetLives();
    }

    public Transform SpawnPoint
    {
        get => currentSpawnPoint;
    }

    public void RegisterSpawnPoint(Transform newPoint)
    {
        currentSpawnPoint = newPoint;
    }

}
