using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected string enemyName;
    [SerializeField] protected int maxHealth;
    private int health;
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected float distance;

    [SerializeField] protected Color32 enemyColor;
    protected Transform target;


    
    // Start is called before the first frame update
    protected  virtual void Start()
    {
        var colorEnemy = GetComponent<Renderer>().material;
        colorEnemy.SetColor("_BaseColor", enemyColor);

        health = maxHealth;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Introduction();
    }

    protected virtual void Introduction()
    {
        Debug.Log("My name is " + enemyName + ", HP: " + health + ", moveSpeed: " + moveSpeed);
    }

    // Update is called once per frame
    protected  virtual void Update()
    {
        Move();

        if (health <= 0)
        {
            Death();
        }
    }

    protected virtual void Move()
    {
        if (Vector3.Distance(transform.position, target.position) < distance)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.transform.position.x, 0.5f, target.transform.position.z), moveSpeed * Time.deltaTime);
        }
    }

    protected virtual void Attack()
    {
        health--;
        Debug.Log(this.name + " health is: " + health);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Attack();
        }
    }

    protected virtual void Death()
    {
        Destroy(this.gameObject);
    }
}
