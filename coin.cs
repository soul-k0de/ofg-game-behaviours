using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    public AudioSource _audio;
    public AudioClip pickup;
    public Transform cointr;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(cointr.position, 0.085f);
    }
}
