using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    public Transform _checkpoint;
    public Transform hero;
    public Transform deathY;
    
    void Update()
    {
        if (hero.position.y < deathY.position.y)
        {
            hero.transform.position = _checkpoint.position;
            hero.transform.rotation = _checkpoint.rotation;
            Debug.Log("Respawned");
        }
    }
}
