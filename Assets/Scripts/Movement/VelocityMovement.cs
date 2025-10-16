using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityMovement : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody2D myRigid2D;

    [Header("Movement Parameters")]
    public float moveSpeed = 5f;
    public float runSpeed = 8f;
    public float jumpForce = 70f;
    public bool isGrounded;

    [Header("Audio & Animation")]
    public AudioSource theAudioSource;
    public Animator theAnimator;

    private void Start()
    {
        myRigid2D.freezeRotation = true;
    }

    private void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float speed = moveSpeed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
            theAnimator.SetBool("IsRunningStill", speed == runSpeed);
        }

        float moveDirection = 0f;

        if (Input.GetKey(KeyCode.D)) 
        {
            moveDirection = 1f;
            transform.localScale = new Vector3(1, 1, 1); 
        }
        else if (Input.GetKey(KeyCode.A)) 
        {
            moveDirection = -1f;
            transform.localScale = new Vector3(-1, 1, 1); 
        }

        myRigid2D.linearVelocity = new Vector2(moveDirection * speed, myRigid2D.linearVelocity.y);

        theAnimator.SetFloat("WalkSpeed", Mathf.Abs(moveDirection));
        theAnimator.SetBool("IsRunningStill", speed == runSpeed && moveDirection != 0);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            myRigid2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;

            theAnimator.Play("Jump");
        }
    }

    public void FlipSwitch()
    {
        theAnimator.SetTrigger("Switch");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Groundplatform"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            theAudioSource.Play();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Groundplatform"))
        {
            isGrounded = false;
        }
    }
}

