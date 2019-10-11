using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Superpill : MonoBehaviour
{

    public int index;
    private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player"&&rend.enabled)
        {
            Global.super = true;
            StartCoroutine(Delay());
            gameObject.GetComponent<Renderer>().enabled = false;
        }else if (collision.tag == "Player1" && rend.enabled)
        {
            Global.super1 = true;
            StartCoroutine(Delay1());
            gameObject.GetComponent<Renderer>().enabled = false;
        }
        else if (collision.tag == "Player2" && rend.enabled)
        {
            Global.super2 = true;
            StartCoroutine(Delay2());
            gameObject.GetComponent<Renderer>().enabled = false;
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(6);
        Global.super = false;
    }

    IEnumerator Delay1()
    {
        yield return new WaitForSeconds(6);
        Global.super1 = false;
    }

    IEnumerator Delay2()
    {
        yield return new WaitForSeconds(6);
        Global.super2 = false;
    }

}
