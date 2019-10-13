using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private int direction = 0; // 0=idle, 1=up, 2=down, 3=left, 4=right
    private Vector3 lastPosition;
    public Animator ani;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().isKinematic = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Global.finish)
        {
            //Player input in different modes
            if (tag=="Player"||tag=="Player2")
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
            }else if (tag == "Player1")
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    direction = 1;
                }
                else if (Input.GetKeyDown(KeyCode.S))
                {
                    direction = 2;
                }
                else if (Input.GetKeyDown(KeyCode.A))
                {
                    direction = 3;
                }
                else if (Input.GetKeyDown(KeyCode.D))
                {
                    direction = 4;
                }
            }
            

            if (direction != 0)
            {
                ani.SetBool("Moving", true);
            }
            else
            {
                ani.SetBool("Moving", false);
            }

            float movement = Global.playerSpeed * Time.deltaTime;

            if (direction == 1)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                lastPosition = transform.position;
                transform.position = new Vector2(transform.position.x, transform.position.y + movement);
            }
            else if (direction == 2)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, -90f);
                lastPosition = transform.position;
                transform.position = new Vector2(transform.position.x, transform.position.y - movement);
            }
            else if (direction == 3)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 180f);
                lastPosition = transform.position;
                transform.position = new Vector2(transform.position.x - movement, transform.position.y);
            }
            else if (direction == 4)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                lastPosition = transform.position;
                transform.position = new Vector2(transform.position.x + movement, transform.position.y);
            }
        }
    }

    public void stopMoving()
    {
        direction = 0;
        //transform.position = 2 * (lastPosition - transform.position) + lastPosition;
    }

    public void setPortalPosition(bool isLeft)
    {
        if (tag == "Player")
        {
            if (isLeft)
            {
                transform.position = Global.goRight;
            }
            else
            {
                transform.position = Global.goLeft;
            }
        }
        else if (tag == "Player1")
        {
            if (isLeft)
            {
                transform.position = Global.goRight1;
            }
            else
            {
                transform.position = Global.goLeft1;
            }
        }
        else if (tag == "Player2")
        {
            if (isLeft)
            {
                transform.position = Global.goRight2;
            }
            else
            {
                transform.position = Global.goLeft2;
            }
        }
    }

    public void resetPosition()
    {
        if (tag == "Player")
        {
            transform.position = Global.pPosition;
        }else if (tag == "Player1")
        {
            transform.position = Global.pPosition1;
        }
        else if (tag == "Player2")
        {
            transform.position = Global.pPosition2;
        }
    }

}
