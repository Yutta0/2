using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //public Joystick joystick;

    public Rigidbody2D rb;
    public Vector2 moveVector;
    public float speed = 2;
    public Animator anim;
    public SpriteRenderer sr;
    public bool faceRight = true;
    public float jumpForce = 7;
    public bool onGround;
    public Transform GroundCheck;
    public float checkRadius = 0.5f;
    public LayerMask Ground;
    public int lungeImpulse = 5000;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    void Reflect()
    {
        if ((moveVector.x > 0 && !faceRight) || (moveVector.x < 0 && faceRight))
        {
            Vector3 temp = transform.localScale;
            temp.x *= -1;
            transform.localScale = temp;
            faceRight = !faceRight;
        }
    }

    void Update()
    {
        walk();
        Reflect();
        jump();
        CheckingGround();
        Lunge();
    }
    void walk()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        anim.SetFloat("moveX", Mathf.Abs(moveVector.x));
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
    }
    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
    }
    void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, Ground);
    }
    void Lunge()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            //        anim.StopPlayback();
            //        anim.Play("lunge");

            rb.velocity = new Vector2(0, 0);

            if (!faceRight) { rb.AddForce(Vector2.left* lungeImpulse); }
            else { rb.AddForce(Vector2.right * lungeImpulse); }
        }
    }
}

