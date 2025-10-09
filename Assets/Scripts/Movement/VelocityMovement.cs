using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityMovement : MonoBehaviour
{
    public Rigidbody2D myRigid2D;
    Vector2 myVector;

    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    public bool isGrounded;
    public AudioSource theAudioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveLeftAndRight();
        Jump();
    }
    private void MoveLeftAndRight()
    {

       if (Input.GetKey(KeyCode.W))
        {
            myRigid2D.linearVelocityY = moveSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            myRigid2D.linearVelocityY =- moveSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            myRigid2D.linearVelocityX = moveSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            myRigid2D.linearVelocityX =- moveSpeed;
        } 
    }
    private void Jump()
    { 
        if (Input.GetKey(KeyCode.V))
        {
            myRigid2D.AddForce(Vector2.up * jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
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

