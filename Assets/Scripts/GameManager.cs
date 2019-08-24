﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject over;
    public GameObject win;
    public GameObject pArr;

    // Start is called before the first frame update
    void Start()
    {
        //QualitySettings.vSyncCount = 0;
        //Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        bool done = true;
        foreach (Transform child in pArr.transform)
        {
            if (child.gameObject.activeSelf)
            {
                done = false;
                break;
            }
        }
        if (done)
        {
            win.SetActive(true);
            Global.finish = true;
        }
    }
    
}
