using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Witch : Enemy
{
    private float moveRate = 2.0f;
    private float moveTimer;
    private bool playerDetected;
    [SerializeField] private float minX, maxX, minZ, maxZ;
    
    protected override void Move()
    {
        if (Vector3.Distance(transform.position, target.position) < distance)
        {
            playerDetected = true;
            base.Move();
        }
        else
        {
            playerDetected = false;
        }

        if (!playerDetected)
        {
            RandomMove();
        }
        
    }

    private void RandomMove()
    {
        moveTimer += Time.deltaTime;

        if (moveTimer > moveRate)
        {
            transform.position = new Vector3(Random.Range(minX, maxX), 0.5f, Random.Range(minZ, maxZ));
            moveTimer = 0;
        }
    }
}
