using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private Rigidbody2D _rb;
    public int enemyhealth = 50;
    int currentenemyhp;
    public Transform _tr;
    public Transform _herotransform;
    private Collider2D _coll;
    public SpriteRenderer _sprend;
    public Sprite killedslime;

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
        Debug.Log("Enemy destroyed");
    }
    

    void FixedUpdate()
    {
        if (_herotransform.position.x > _tr.position.x)
        {
            _tr.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

        if (_herotransform.position.x < _tr.position.x)
        {
            _tr.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
