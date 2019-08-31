using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Superpill : MonoBehaviour
{

    public int index;

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
            //Global.super = true;
            StartCoroutine(Delay());
            gameObject.SetActive(false);
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(5);
        //Global.super = false;
    }

}
