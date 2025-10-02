using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorMovement : MonoBehaviour
{
    public float direction = 1.0f; // variable to control direction of movement for left to right movement
    public float movementSpeed = 0.025f; // variable to control speed of movement for auto movement

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update  called once per frame
    void Update()
    {
        // RightToLeftMovement();
        FullMovement();
    }

    void RightToLeftMovement()
    {
        Vector3 thePosition = transform.position;
        thePosition.x += 0.01f * direction;
        transform.position = thePosition;

        if (thePosition.x >= 7.0f)
        {
            direction = -1.0f;
        }
        else if (thePosition.x <= -7.0f)
        {
            direction = 1.0f;
        }
    }

    void FullMovement()
    {
        Vector3 move = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            move.y += movementSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            move.y -= movementSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            move.x += movementSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            move.x -= movementSpeed;
        }

        transform.position += move;
    }
}
