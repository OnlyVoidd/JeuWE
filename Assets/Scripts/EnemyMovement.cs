using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float enemySpeed = 1f;
    [SerializeField]
    private Transform wp1, wp2;
    [SerializeField]
    private float margin = 0.1f;

    private Transform target;
    

    private void Start()
    {
        target = wp1;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (!WaypointReached(target))
        {
            int dir = target.position.x > transform.position.x ? 1 : -1;
            transform.Translate(new Vector2(enemySpeed * Time.deltaTime * dir, 0));
        }
        else target = target == wp1 ? wp2 : wp1;
    }

    internal string Die()
    {
        throw new NotImplementedException();
    }

    private bool WaypointReached(Transform target)
    {
        float pos = transform.position.x;
        float targetPos = target.position.x;

        return (pos <= targetPos + margin) && (pos >= targetPos - margin);
    }
}
