using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;


public class finish : MonoBehaviour
{
    public Transform finishPoint;
    public float finishRange;
    public LayerMask player;
    void Update()
    {
        NextLevel();
    }
    void NextLevel()
    {
        Collider2D[] collider2D = Physics2D.OverlapCircleAll(finishPoint.position, finishRange, player);
        foreach (Collider2D player in collider2D)
        {
            player.GetComponent<hero>().LoadNextLevel();
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        if (finishPoint == null)
            return;
        Gizmos.DrawWireSphere(finishPoint.position, finishRange);
    }
}
