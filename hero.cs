using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class hero : MonoBehaviour
{
    private int maxJumps = 2;
    private int jumpCount = 0;
    public float speed = 12f;
    public float jumpHeight = 10f;
    //public float normalMass;
    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;
    public AudioClip sound4;
    private bool checkjump = false;
    public bool grounded = true;
    private bool checksound = true;
    private bool checkdash = false;
    private bool checkaxis;
    // private Transform _transform;
    private Rigidbody2D _rb;
    private AudioSource _audiosrc;
    public float normalspeed;
    //public GameObject restart;
    //public float currentposY;
    //public float currentposX; 
    //private BoxCollider2D _boxcol2d;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _audiosrc = GetComponent<AudioSource>();
        normalspeed = speed;
    }

    // Update is called once per frame
//______________________________________________________
    //void FreeFall()
    //{
      //  while (grounded != true)
        //{
          //  _rb.mass += 0.5f;
            //Debug.Log(_rb.mass);
        //}
        //if (grounded == true)
        //{
          //  _rb.mass = normalMass;
            //Debug.Log(_rb.mass);
        //}
    //}
//______________________________________________________
    void Update()
    {
        // Рывок вниз
        PushDown();
        // Разворот
        Flip();
        // Прыжок
        Jump();
        // Свободное падение
        //FreeFall();
    }
   //void Restart()
   //{
        //currentposX = _transform.localPosition.x;
        //currentposY = _transform.localPosition.y;
        //if (currentposY < -11f)
        //{ 
            //currentposX = restart.transform.localPosition.x;
            //currentposY = restart.transform.localPosition.y;
        //}
    //}
 //______________________________________________________
    void PushDown()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && grounded == false)
        {
            _rb.AddForce(transform.up * -30f , ForceMode2D.Impulse);
            _audiosrc.PlayOneShot(sound2);
            checkdash = true;
            //checksound = false;
        }
    }
//______________________________________________________

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Ground")
        {
            grounded = true;
            jumpCount = 0;
            checkjump = false;
            //_rb.mass = normalMass;
            if (checksound == true)
            {
                _audiosrc.PlayOneShot(sound3);
            }
            checksound = false;
            if (checkdash == true)
            {
                _audiosrc.PlayOneShot(sound4);
                checkdash = false;
            }
        }

        //if (collider.gameObject.tag == "Respawn")
        //{
        //}
    }
//______________________________________________________
    void FixedUpdate()
    {
        _rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, _rb.velocity.y);
    }
//______________________________________________________

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && jumpCount < maxJumps)
        {
            _rb.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
            _audiosrc.PlayOneShot(sound1);
            jumpCount = jumpCount + 1;
            Debug.Log(jumpCount);
            grounded = false;
            checksound = true;
            checkjump = true;
        }
        if (grounded == true) 
        {
            jumpCount = 0;
        }
    }
//______________________________________________________
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

    //void Dash()
    //{
      //  if (Input.GetKeyDown(KeyCode.A))
        //{
          //  _rb.AddForce(transform.right * -20f, ForceMode2D.Impulse);
        //}

        //if (Input.GetKeyDown(KeyCode.D))
        //{
          //  _rb.AddForce(transform.right * 20f, ForceMode2D.Impulse);
        //}
    //}
}
