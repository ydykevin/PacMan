using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public bool isLeft;
    private float anglePerSecond = -180;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, transform.rotation.z + anglePerSecond * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Player1" || collision.tag == "Player2")
        {
            collision.gameObject.GetComponent<Player>().setPortalPosition(isLeft);
        }
        else if (collision.tag == "Ghost" || collision.tag == "Ghost1" || collision.tag == "Ghost2")
        {
            collision.gameObject.GetComponent<Ghost>().setPortalPosition(isLeft);
        }
    }
}
