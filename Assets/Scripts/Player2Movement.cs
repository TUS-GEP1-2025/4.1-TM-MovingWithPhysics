using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    public Rigidbody2D myRigid2D;
    Vector2 myVector;

    public float moveSpeed = 5f;
    public float jumpForce = 10f;
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

        if (Input.GetKey(KeyCode.UpArrow))
        {
            myRigid2D.linearVelocityY = moveSpeed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            myRigid2D.linearVelocityY = -moveSpeed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigid2D.linearVelocityX = moveSpeed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigid2D.linearVelocityX = -moveSpeed;
        }
    }
    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            myRigid2D.AddForce(Vector2.up * jumpForce);
        }
    }
}
