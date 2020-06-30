using System;
using UnityEngine.SceneManagement;
using UnityEngine;

public class hero : MonoBehaviour
{
    // Start is called before the first frame update
    private bool move = true;
    private int _checkforjump = 0; 
    private Rigidbody2D _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PushDown();
        Flip(); 
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
            //Restart();
        }
    }
    //void Restart()
    //{
      //  if (Input.GetKeyDown(KeyCode.R))
        //{
        //}
    //}
    void PushDown()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _rb.AddForce(transform.up * -30f , ForceMode2D.Impulse);
        }
    }
    void FixedUpdate()
    {
        _rb.velocity = new Vector2(Input.GetAxis("Horizontal") * 12f, _rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.E))
        {
            _rb.AddForce(transform.right * 100f, ForceMode2D.Force);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            _rb.AddForce(transform.right * -100f, ForceMode2D.Force);
        }
    }

    //void RightLeftDash();
    //{
      //  if (Input.GetKeyDown(KeyCode.Q))
        //{
            //_rb.AddForce(transform.right * 100f, ForceMode2D.Impulse); 
        //}
    //}

    void Jump()
    {
        //if (_checkforjump <= 2 && move == true)
        //{
            _rb.AddForce(transform.up * 10f, ForceMode2D.Impulse);
            //_checkforjump += 1;
        //}
        //if (_checkforjump > 2)
        //{
          //  move = false;
        //}
        
    }

    //void OnTriggerEnter(Collision other)
    //{
      //  if (other.gameObject.tag == "Ground")
        //{
          //  ReloadJump();
        //}
    //}

    //void ReloadJump()
    //{
      //  move = true;
        //_checkforjump = 0;
   // }
    void Flip()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0 );
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);   
        }
    }
}
