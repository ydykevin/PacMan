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
            Debug.Log("start");
            Global.super = true;
            StartCoroutine(Delay());
            gameObject.GetComponent<Renderer>().enabled = false;
            //gameObject.SetActive(false);
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(6);
        Global.super = false;
        Debug.Log("end");
    }

}
