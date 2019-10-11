using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player"|| collision.tag == "Player1"|| collision.tag == "Player2")
        {
            collision.gameObject.GetComponent<Player>().stopMoving();
        }
        else if (collision.tag == "Ghost"|| collision.tag == "Ghost1"|| collision.tag == "Ghost2")
        {
            collision.gameObject.GetComponent<Ghost>().stopMoving();
        }
    }

}
