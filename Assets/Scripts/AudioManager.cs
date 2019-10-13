using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioSource bgm;
    public AudioSource eat;
    public AudioSource eatGhost;
    public AudioSource kill;
    public AudioSource lose;
    public AudioSource ready;
    public AudioSource superpill;
    public AudioSource win;
    public AudioSource multiScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playBGM()
    {
        bgm.Play();
    }

    public void playEat()
    {
        eat.Play();
    }

    public void playEatGhost()
    {
        eatGhost.Play();
    }

    public void playKill()
    {
        kill.Play();
    }

    public void playLose()
    {
        lose.Play();
    }

    public void playReady()
    {
        ready.Play();
    }

    public void playSuperpill()
    {
        superpill.Play();
    }

    public void playWin()
    {
        win.Play();
    }

    public void playMultiScore()
    {
        multiScore.Play();
    }

}
