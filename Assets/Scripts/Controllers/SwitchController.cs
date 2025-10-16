using System.Collections;
using System.Collections.Generic;
using UnityEditor.Networking.PlayerConnection;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    
    public bool switchActive;

    public SpriteRenderer switchColor;

    [Header("Connected Scripts")]
    public RadioController2 radioController2;
    public VelocityMovement theVelocityMovement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && switchActive == true)
        {          
            switchColor.color = Color.green;
            theVelocityMovement.FlipSwitch();
            radioController2.PlayNextSong();
        }
        else if (switchActive == false)
        {
            switchColor.color = Color.red;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switchActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switchActive = false;
            radioController2.StopSong();
        }
    }
}

