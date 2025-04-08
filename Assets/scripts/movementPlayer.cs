using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class movementPlayer : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public Animator anim;
    public KeyCode Right=KeyCode.RightArrow;
    public KeyCode Up=KeyCode.UpArrow;
    public KeyCode Down=KeyCode.DownArrow;
    public KeyCode Left=KeyCode.LeftArrow;
    Vector2 direction;
    public bool canmove;
    public float speed = 1;

    private void Start()
    {
        canmove = true;
    Right = KeyCode.RightArrow;
    Up = KeyCode.UpArrow;
    Down = KeyCode.DownArrow;
    Left = KeyCode.LeftArrow;
    rb2d=GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (canmove)
        { MoveDirection(); }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    private void FixedUpdate()
    {
        if (canmove)
        {
            Move();
        }
    }
    void Move()
    {
        if (direction != Vector2.zero)
        {
            //anim.SetBool("IsMove", true);
        }
        else
        {
            //anim.SetBool("IsMove", false);
        }
        rb2d.velocity = direction * speed;
        direction = Vector2.zero;
    }

    private void MoveDirection()
    {
        leftMove(Left);
        rightMove(Right);
        upMove(Up);
        downMove(Down);
        direction = direction.normalized;
    }

    private void downMove(KeyCode down)
    {
        if (Input.GetKey(down))
        {
            Vector2 velocity = new Vector3(0, -1);
            direction += velocity;
        }
    }

    private void upMove(KeyCode up)
    {
        if (Input.GetKey(up))
        {
            Vector2 velocity = new Vector3(0, 1);
            direction += velocity;
        }
    }

    private void rightMove(KeyCode right)
    {
        if (Input.GetKey(right))
        {
            Vector2 velocity = new Vector3(1, 0);
            direction += velocity;
        }
    }

    private void leftMove(KeyCode left)
    {
        if (Input.GetKey(left))
        {
            Vector2 velocity = new Vector3(-1, 0);
            direction += velocity;
        }
    }
    public void StopPlayer()
    {
        rb2d.velocity = Vector3.zero;
    }

    /*public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 movementInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    void FixedUpdate()
    {
        rb.velocity = movementInput * speed;
    }*/
}
