using System.Net.Configuration;
using UnityEngine;

public class test_script : MonoBehaviour
{
    public float speed = 20f;
    private Rigidbody2D _rb;
    private bool faceRight = true;
    void Start ()
    {
        _rb = GetComponent<Rigidbody2D> ();
    }
	
	
    void Update ()
    {
        float moveX = Input.GetAxis("Horizontal");
        _rb.MovePosition (_rb.position + Vector2.right * moveX * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector2.up * 8000);
        }

        if (moveX > 0 && !faceRight)
        {
            flip();
        }
        else if (moveX < 0 && faceRight)
        {
            flip();
        }

        void flip();
        {
            faceRight = !faceRight;
            transform.localScale = new Vector3(transform.localScale.x * - 1, transform.localScale.y, transform.localScale.z);
        }
    }
}
