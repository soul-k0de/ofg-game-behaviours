// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine.Monetization;
using UnityEngine;
using System.Threading;

public class Moving_pre_alpha : MonoBehaviour {
    public float speed = 4f;
    public int moveX;
    private Rigidbody2D _rb;
    // Переменная для проверки, в какую сторону движется игрок
    private bool faceRight = true;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void Update() 
    {
        // Вот код для обычного движения
        //float moveX = Input    .GetAxis("Horizontal"); 
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
                    // Время скольжения будет равно 0,25 секунды
                    Thread.Sleep(250);
                    speed -= 1f;
                }
            }
			if (moveX != 0 && speed != 0);    
            { 
                // Обычное движение
               _rb.MovePosition(_rb.position + Vector2.right * moveX * speed * Time.deltaTime);
            }
        }
        // Движение в правую сторону
        if (moveX > 0 && !faceRight)
        {
            flip();
        }
        // Движение в левую сторону
        else if (moveX < 0 && faceRight)
        {
            flip();
        }
        // Сама функция разворота
        void flip();
        {
            // Разворот игрока
            faceRight = !faceRight;
            transform.localScale = new Vector3(transform.localScale.x * - 1, transform.localScale.y, transform.localScale.z);
        }    
    }

}
