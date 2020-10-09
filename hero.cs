using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class hero : MonoBehaviour
{
    // Максимальное кол-во прыжков 
    private int maxJumps = 2; 
    //public int plusbullets = 1; 
    // Кол-во прыжков
    private int jumpCount = 0;
    // Скорость
    public float speed = 12f;
    // Высота прыжка
    public float jumpHeight = 10f;
    // Проверка прыжка
    private bool checkjump = false;
    // Булевая переменная для показания приземнелия
    public bool grounded = true;
    // Булевая переменная для проверки звука 
    private bool checksound = true;
    private bool checkdash = false;
    private bool checkaxis;
    // Риджидбоди (Физические свой-ва)
    private Rigidbody2D _rb;
    
    // Метод Start
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    
//______________________________________________________
    
    // Загрузка следующего уровня
    public void LoadNextLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
    
    // Передвижение и развороты в методе Update
    void Update()
    {
        // Рывок вниз
        PushDown();
        // Разворот
        Flip();
        // Прыжок
        Jump();
    }

 
 //Рывок вниз
 void PushDown()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && grounded == false)
        {
            _rb.AddForce(transform.up * -30f , ForceMode2D.Impulse);
            checkdash = true;
            //checksound = false;
        }
    }
//______________________________________________________
    
    // Столкновение с колизией
    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Ground")
        {
            grounded = true;
            jumpCount = 0;
            checkjump = false;
        }
    }
//______________________________________________________
    
    //Передвижение по оси X
    void FixedUpdate()
    {
        _rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, _rb.velocity.y);
    }
//______________________________________________________
    
    // Прыжок
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && jumpCount < maxJumps)
        {
            _rb.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
            jumpCount = jumpCount + 1;
            // Показатель кол-ва прыжков
            Debug.Log(jumpCount);
            grounded = false;
            checksound = true;
            checkjump = true;
        }
        if (grounded == true) 
        {
            //
            jumpCount = 0;
        }
    }
//______________________________________________________

    //Разворот
    void Flip()
    {
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localRotation = Quaternion.Euler(0f, 180f,0f);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localRotation = Quaternion.Euler(0f, 0f,0f);
        }
    }
}
