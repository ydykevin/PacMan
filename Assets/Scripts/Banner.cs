using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Banner : MonoBehaviour
{
    private float currTime=0;
    private Image img;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        //Banner flashing every 0.5 second
        if (Time.time - currTime >= 0.5f)
        {
            currTime = Time.time;
            img.enabled = !img.enabled;
        }
    }
}
