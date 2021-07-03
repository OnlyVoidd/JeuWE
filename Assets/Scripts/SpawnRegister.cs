using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRegister : MonoBehaviour
{
    private void Awake()
    {
        GameManager.Instance.RegisterSpawnPoint(transform);
    }
}
