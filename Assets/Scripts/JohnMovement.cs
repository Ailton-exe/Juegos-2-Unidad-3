using UnityEngine;

public class JohnMovement : MonoBehaviour
{
    public float JumpForce = 5f;
    public float Speed = 5f;

    private Rigidbody2D rb;
    private float Horizontal;
    private bool Grounded;
    private Animator Animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Movimiento lateral
        Horizontal = Input.GetAxis("Horizontal");

        // Girar el sprite
        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f); 

        // Animación de correr true/false
        Animator.SetBool("running", Horizontal != 0.0f);

        // Detectar si está en el suelo
        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);

        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f)) 
        {
            Grounded = true;
        }
        else
        {
            Grounded = false;
        }

        // Salto con W
        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
        } 
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, JumpForce);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(Horizontal * Speed, rb.linearVelocity.y);
    }
}

/*
using UnityEngine;

public class JohnMovement : MonoBehaviour
{
    public float JumpForce;
    public float Speed;

    private Rigidbody2D Rigidbody2D;
    private float Horizontal;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        } 
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.Velocity = new Vector2(Horizontal, Rigidbody2D.linearVelocity.y);
    }

    
}
*/