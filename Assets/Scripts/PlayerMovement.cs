using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private int direction = 0;
    private float movement = 0.05f;
    public Animator ani;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = 1;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = 2;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = 3;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = 4;
        }

        if (direction != 0)
        {
            ani.SetBool("Moving", true);
        }
        else
        {
            ani.SetBool("Moving", false);
        }

        if (direction == 1)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            transform.position = new Vector2(transform.position.x, transform.position.y + movement);
        }
        else if (direction == 2)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, -90f);
            transform.position = new Vector2(transform.position.x, transform.position.y - movement);
        }
        else if (direction == 3)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 180f);
            transform.position = new Vector2(transform.position.x - movement, transform.position.y);
        }
        else if (direction == 4)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            transform.position = new Vector2(transform.position.x + movement, transform.position.y);
        }

    }

    public void stopMoving()
    {
        direction = 0;
    }

}
