using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public bool toRight;
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
        if (collision.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().setPortalPosition(toRight);
        }
        else if (collision.tag == "Ghost")
        {
            collision.gameObject.GetComponent<Ghost>().setPortalPosition(toRight);
        }
    }
}
