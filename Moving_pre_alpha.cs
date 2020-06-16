// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Moving_pre_alpha : MonoBehaviour {
    public float speed = 4f;
    private int time_sleep;
    public int moveX;
    private Rigidbody2D _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void Update() 
    {
        // Вот код для обычного движения
        //float moveX = Input.GetAxis("Horizontal"); 
        //_rb.MovePosition(_rb.position + Vector2.right * moveX * speed * Time.deltaTime);
        float moveX = Input.GetAxis("Horizontal");
        // Коэффициент
        float i = 50;
        while (moveX != 0f && speed > 0f );
        {if (moveX == 0f && speed > 4);
            {
                 //Экстренное торможение при высокой скорости    
                while (speed != 0f) ;
                {
                    // Время скольжения
                    time_sleep = i * speed;
                    Thread.Sleep(time_sleep);
                    speed -= 1f;
                }
            }
			if (moveX != 0 && speed != 0);    
            { 
                // Обычное движение
               _rb.MovePosition(_rb.position + Vector2.right * moveX * speed * Time.deltaTime);
            }
        }
    }

}
