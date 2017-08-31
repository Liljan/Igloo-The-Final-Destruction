using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1.0f;

    private Rigidbody2D rb2d;
    private Animator animator;

    // jumping
    public float jumpVelocity = 1.0f;

    public float JUMP_HOLD_TIME = 0.3f;
    private float currentJumpHoldTimer;

    public int MAX_JUMPS = 2;
    private int currentJumps;

    public Transform groundCheckPoint;
    public LayerMask groundLayer;
    private bool isGrounded;


    public void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start()
    {
        currentJumpHoldTimer = 0.0f;
        currentJumps = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
    }

    private void Movement()
    {
        float x = Input.GetAxis("Horizontal");

        rb2d.velocity = new Vector2(speed * x, rb2d.velocity.y);

        SetFacingDirection(x);

        animator.SetBool("Run", Mathf.Abs(x) > 0.1f);
    }

    private void SetFacingDirection(float xAxis)
    {
        if (xAxis <= -0.1f)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        else if (xAxis >= 0.1f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }

    private void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, 0.1f, groundLayer);
        if (isGrounded)
        {
            currentJumps = 0;
            currentJumpHoldTimer = 0.0f;
        }

        animator.SetBool("Grounded", isGrounded);

        /*if (Input.GetButtonDown("Jump") && currentJumps < MAX_JUMPS - 1)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpVelocity);
            currentJumps++;
        }*/

        if(Input.GetButtonDown("Jump") && currentJumps < MAX_JUMPS)
        {
            currentJumps++;
        }

        if (Input.GetButton("Jump") && currentJumps < MAX_JUMPS)
        {
            if (currentJumpHoldTimer < JUMP_HOLD_TIME)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpVelocity);
                currentJumpHoldTimer += Time.deltaTime;
            }
        }

    }

}
