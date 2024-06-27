using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    private float moveSpeed = 5.0f; 
    private Rigidbody2D rigid2D;

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>(); 
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal"); 
        float y = Input.GetAxisRaw("Vertical"); 


        rigid2D.velocity = new Vector2(x, y) * moveSpeed;
    }

   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("box"))
        {
            Debug.Log("Trigger Entered: " + other.name);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("box"))
        {
            Debug.Log("Trigger Staying: " + other.name);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("box"))
        {
            Debug.Log("Trigger Exited: " + other.name);
        }
    }
}

