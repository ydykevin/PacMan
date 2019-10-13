using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pill : MonoBehaviour
{
    public Text score;

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
            score.text = (int.Parse(score.text) + 10) + "";
            gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>().playEat();
        }
        else if (collision.tag == "Player1"|| collision.tag == "Player2")
        {
            gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>().playEat();
        }
    }
    
}
