using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : Enemy
{
    public Transform wayPoint1, wayPoint2;
    private Transform wayPointTarget;

    private void Awake()
    {
        wayPointTarget = wayPoint1;
    }

    protected override void Introduction()
    {
        //base.Introduction();
        Debug.Log("Hiiii I´m a bat.. man..");
    }

    protected override void Move()
    {
        base.Move();
        
        if (Vector3.Distance(transform.position, target.position) > distance)
        {
            if (Vector3.Distance(transform.position, wayPoint1.position) < 0.01f)
            {
                wayPointTarget = wayPoint2;
            }        
        
            if (Vector3.Distance(transform.position, wayPoint2.position) < 0.01f)
            {
                wayPointTarget = wayPoint1;
            }
            
            transform.position = Vector3.MoveTowards(transform.position, wayPointTarget.position, moveSpeed * Time.deltaTime);
        }
    }
}
