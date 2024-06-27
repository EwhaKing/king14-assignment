using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        // Player movement
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(new Vector2(moveX, moveY));

        // Raycast
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right);
        if (hit.collider != null)
        {
            Debug.Log("Hit: " + hit.collider.name);
        }
    }
}
