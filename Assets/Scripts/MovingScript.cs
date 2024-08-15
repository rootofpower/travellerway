using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingScript : MonoBehaviour
{
    public float speed;
    public float jumpRate = 10;
    public Rigidbody2D rbody;
    private bool isFacingRight = true;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        rbody.velocity = new Vector2(speed * Input.GetAxis("Horizontal"), transform.position.y);
        if (Input.GetAxis("Horizontal") < 0 && isFacingRight || Input.GetAxis("Horizontal") > 0 && !isFacingRight)
        {
            Flip();
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) { rbody.velocity = Vector2.up * jumpRate * 10; }

    }
    public void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector2 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
