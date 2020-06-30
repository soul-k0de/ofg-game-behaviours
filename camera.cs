using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform hero;
    Vector3 position;
    void Start()
    {
        transform.position = hero.position;
    }

    // Update is called once per frame
    void Update()
    {
        position.x = hero.position.x ;
        position.y = hero.position.y;
        position.z = -10f ;
        transform.position = Vector3.Lerp(transform.position, position, 1f * Time.deltaTime);
    }
}
