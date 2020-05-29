using UnityEngine;
using System.Treading

public class moveHero : MonoBehaviour
{
    public float speed = 4f;

    private Rigidbody2D rb; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        // Вот код для обычного движения
        //float moveX = Input.GetAxis("Horizontal");
        //rb.MovePosition(rb.position + Vector2.right * moveX * speed * Time.deltaTime);
        float moveX = Input.GetAxis("Horizontal");
        // Коэффициент
        float i = 50
        while (moveX != 0f, speed > 0f );
        {if (moveX == 0f, speed > 4) ;
            {
                // Экстренное торможение при высокой скорости    
                while (speed != 0f) ;
                {
                    // Время скольжения
                    time_sleep = i * speed
                    Tread.Sleep(time_sleep)
                    speed = speed - 1f
                }
            }
        if (moveX != 0, speed != 0)    
            { 
                // Обычное движение
                rb.MovePosition(rb.position + Vector2.right * moveX * speed * Time.deltaTime);
            }
        }
    }
}
