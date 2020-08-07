using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleecombat : MonoBehaviour
  {
    //public Animation _anim;
    private float timebtwAttack;
    //public float startTimeBtwAttack;
    //private Animator anim;
    //public float attackTime;
    //public float startTimeAttack;
    //public Transform attackLocation;
    public int attackDamage = 25;
    public Transform attackPoint;
    public LayerMask enemiesLayers;
    //public AudioSource _audio;
    //public AudioClip meleeattacksfx;
    public float attackRange = 1.8f;


    void Update()
    {
      MeleeAttack();
      //WeaponSwitch();
    }
    
    
    //void WeaponSwitch()
    //{
      //if (Input.GetKeyDown(KeyCode.Alpha1) && ismeleecombat == false)
      //{
        //ismeleecombat = true;
        //_sp.sprite = weapon1;
        //transform.localRotation = Quaternion.Euler(0f, 0f, -30.2f);
        //if (ismeleecombat = true)
        //{
          //MeleeAttack();
        //}
      //}
      //if (Input.GetKeyDown(KeyCode.Alpha2) && ismeleecombat == true)
      //{
        //ismeleecombat = false;
        //_sp.sprite = weapon2;
        //transform.localRotation = Quaternion.Euler(0f,0f, 0f);
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
          //_audio.PlayOneShot(rangeattacksfx);
        //}
      //}
    //}

    void MeleeAttack()
    {
      if (Input.GetKeyDown(KeyCode.Space))
      { 
      Collider2D[] hitcoll = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemiesLayers);
      foreach (Collider2D enemy in hitcoll)
      {
        enemy.GetComponent<enemy>().TakeDamage(attackDamage);
        //_audio.PlayOneShot(meleeattacksfx);
      }
      }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        if (attackPoint == null)
          return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
  }


  



