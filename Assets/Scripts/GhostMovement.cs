using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, 0.45f,Vector2.up, 0.9f);
        if (hit.collider == null)
        {
           Debug.Log("up");
        }
        hit = Physics2D.CircleCast(transform.position, 0.45f, Vector2.down, 0.9f);
        if (hit.collider == null)
        {
            Debug.Log("down");
        }
        hit = Physics2D.CircleCast(transform.position, 0.45f, Vector2.left, 0.9f);
        if (hit.collider == null)
        {
            Debug.Log("left");
        }
        hit = Physics2D.CircleCast(transform.position, 0.45f, Vector2.right, 0.9f);
        if (hit.collider == null)
        {
            Debug.Log("right");
        }

    }
}
