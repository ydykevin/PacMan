using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Superpill : MonoBehaviour
{

    public int index;
    private Renderer rend;
    private AudioManager am;

    // Start is called before the first frame update
    void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
        am = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Setup for superpill in different modes
        if (collision.tag == "Player"&&rend.enabled)
        {
            Global.super = true;
            if (!am.superpill.isPlaying)
            {
                am.playSuperpill();
            }
            StartCoroutine(Delay());
            gameObject.GetComponent<Renderer>().enabled = false;
        }else if (collision.tag == "Player1" && rend.enabled)
        {
            Global.super1 = true;
            if (!am.superpill.isPlaying)
            {
                am.playSuperpill();
            }
            StartCoroutine(Delay1());
            gameObject.GetComponent<Renderer>().enabled = false;
        }
        else if (collision.tag == "Player2" && rend.enabled)
        {
            Global.super2 = true;
            if (!am.superpill.isPlaying)
            {
                am.playSuperpill();
            }
            StartCoroutine(Delay2());
            gameObject.GetComponent<Renderer>().enabled = false;
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(6);
        Global.super = false;
        if (am.superpill.isPlaying)
        {
            am.superpill.Stop();
        }
    }

    IEnumerator Delay1()
    {
        yield return new WaitForSeconds(6);
        Global.super1 = false;
        if (am.superpill.isPlaying&&!Global.super2)
        {
            am.superpill.Stop();
        }
    }

    IEnumerator Delay2()
    {
        yield return new WaitForSeconds(6);
        Global.super2 = false;
        if (am.superpill.isPlaying && !Global.super1)
        {
            am.superpill.Stop();
        }
    }

}
