using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private Rigidbody2D _rb;
    public int enemyhealth = 50;
    public float enemySpeed = 0.01f;
    public int currentenemyhp;
    public int direction = -1;
    public Transform _tr;
    public GameObject coin;
    public SpriteRenderer _sprend;
    public Sprite killedslime;
    public Transform point1;
    public Transform point2;
    public Transform _herotransform;
    public string enemyclass;

    void Start()
    {
        currentenemyhp = enemyhealth;
        _rb = GetComponent<Rigidbody2D>();
        //_coll = GetComponent<Collider2D>();
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
        this.enabled = false;
        _sprend.sprite = killedslime;
        Debug.Log("Enemy died");
        Invoke("DestroyItself", 2);
        Instantiate(coin, _tr.position, coin.transform.rotation);
        Debug.Log("Enemy destroyed");
    }


    void FixedUpdate()
    {
        // Enemy movement point-to-point
        _rb.velocity = new Vector2(enemySpeed *  direction, _rb.velocity.y);
        if (transform.position.x < point1.transform.position.x)
        {
            direction = 1;
            transform.localRotation = Quaternion.Euler(0f, 180f,0f);
        }
        else if (transform.position.x > point2.transform.position.x)
        {
            direction = -1;
            transform.localRotation = Quaternion.Euler(0f, 0f,0f);
        }
    }
}