using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private Rigidbody2D _rb;
    public int enemyhealth = 50;
    public float enemySpeed = 2f;
    public float direction = 1f; 
    int currentenemyhp;
    public Transform _tr;
    public GameObject coin;
    private Collider2D _coll;
    public SpriteRenderer _sprend;
    public Sprite killedslime;
    public Transform point1;
    public Transform point2;
    public string enemyclass;
    public bool gotToThePoint1;

    void Start()
    {
        currentenemyhp = enemyhealth;
        _rb = GetComponent<Rigidbody2D>();
        _coll = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (currentenemyhp <= 0)
        {
            Die();
        }
    }

    void DestroyItself()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        currentenemyhp -= damage;
    }

    void Die()
    {
        _coll.enabled = false;
        this.enabled = false;
        _sprend.sprite = killedslime;
        Debug.Log("Enemy died");
        Invoke("DestroyItself", 2);
        Instantiate(coin, _tr.position, coin.transform.rotation);
        Debug.Log("Enemy destroyed");
    }


    void FixedUpdate()
    {
        _rb.velocity = new Vector2(enemySpeed * Time.deltaTime * direction, _rb.velocity.y);
        if (!Mathf.Approximately(transform.position.x, point1.transform.position.x))
        {
            direction = 1f;
        }

        if (!Mathf.Approximately(transform.position.x, point2.transform.position.x))
        {
            direction = -1f;
        }
    }
}