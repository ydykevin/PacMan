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
        if (collision.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().stopMoving();
        }
        else if (collision.tag == "Ghost")
        {
            collision.gameObject.GetComponent<Ghost>().stopMoving();
        }
    }

}
