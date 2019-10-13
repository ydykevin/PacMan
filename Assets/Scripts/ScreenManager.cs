using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    public GameObject pArr;
    public GameObject pArr2;
    public GameObject spArr;
    public GameObject spArr2;
    public GameObject over;
    public GameObject win;
    public Text score;
    public GameObject life3;
    public GameObject life2;
    public Text win1;
    public Text win2;
    
    public Text mScore1;
    public Text mScore2;
    public Image tut;
    private AudioManager am;

    // Start is called before the first frame update
    void Start()
    {
        am = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        Global.finish = true;
        StartCoroutine(delay());
    }

    void Update()
    {
        //Check if all pills are consumed and set game state
        if (SceneManager.GetActiveScene().name == "PacMan" && !Global.finish)
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
                am.playWin();
                Global.finish = true;
                StartCoroutine(singleWin());
            }
        }
        else if (SceneManager.GetActiveScene().name == "Multi"&&!Global.finish)
        {
            bool done1 = true;
            foreach (Transform child in pArr.transform)
            {
                if (child.gameObject.activeSelf)
                {
                    done1 = false;
                    break;
                }
            }
            //P1 consumed all pills
            if (done1)
            {
                am.superpill.Stop();
                am.playMultiScore();
                Global.finish = true;
                Global.score1++;
                mScore1.text = Global.score1 + "          ";
                if (Global.score1 != Global.toWin)
                {
                    StartCoroutine(multiScore());
                }
                else
                {
                    StartCoroutine(p1Win());
                }
            }

            bool done2 = true;
            foreach (Transform child in pArr2.transform)
            {
                if (child.gameObject.activeSelf)
                {
                    done2 = false;
                    break;
                }
            }
            //P2 consumed all pills
            if (done2)
            {
                am.superpill.Stop();
                am.playMultiScore();
                Global.finish = true;
                Global.score2++;
                mScore2.text = "          "+Global.score2 ;
                if (Global.score2 != Global.toWin)
                {
                    StartCoroutine(multiScore());
                }
                else
                {
                    StartCoroutine(p2Win());
                }
            }

        }
        
    }

    public void menu()
    {
        resetValue();
        SceneManager.LoadScene("Menu");
    }

    public void newLevel()
    {
        score.text = "0";
        Global.life = 3;
        life3.SetActive(true);
        life2.SetActive(true);
        resetGame();
    }

    public void showTutorial()
    {
        tut.gameObject.SetActive(true);
    }

    public void closeTutorial()
    {
        tut.gameObject.SetActive(false);
    }

    public void nextLevel()
    {
        if (am.win.isPlaying)
        {
            am.win.Stop();
        }
        resetGame();
    }

    public void single()
    {
        SceneManager.LoadScene("Pacman");
    }

    public void multi()
    {
        SceneManager.LoadScene("Multi");
    }

    public void restart()
    {
        resetValue();
        SceneManager.LoadScene("Multi");
    }

    public void exit()
    {
        if (UnityEditor.EditorApplication.isPlaying)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }

    void resetValue()
    {
        Global.score1 = 0;
        Global.score2 = 0;
        if (SceneManager.GetActiveScene().name == "Multi")
        {
            mScore1.text = "0          ";
            mScore1.text = "          0";
        }
    }

    void resetGame()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("Die", false);

        foreach (Transform child in pArr.transform)
        {
            child.gameObject.SetActive(true);
        }
        foreach (Transform child in spArr.transform)
        {
            child.gameObject.GetComponent<Renderer>().enabled = true;
        }
        
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().resetPosition();
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().stopMoving();
        
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Ghost"))
        {
            g.GetComponent<Ghost>().resetPosition();
        }

        over.SetActive(false);
        win.SetActive(false);
        am.playReady();
        StartCoroutine(delay());
    }

    void resetPill2()
    {
        foreach (Transform child in pArr.transform)
        {
            child.gameObject.SetActive(true);
        }
        foreach (Transform child in spArr.transform)
        {
            child.gameObject.GetComponent<Renderer>().enabled = true;
        }
        foreach (Transform child in pArr2.transform)
        {
            child.gameObject.SetActive(true);
        }
        foreach (Transform child in spArr2.transform)
        {
            child.gameObject.GetComponent<Renderer>().enabled = true;
        }
        am.playReady();
        StartCoroutine(delay());
    }

    IEnumerator singleWin()
    {
        yield return new WaitForSeconds(5);
        win.SetActive(true);
    }

    IEnumerator multiScore()
    {
        yield return new WaitForSeconds(5);
        GameObject player = GameObject.FindGameObjectWithTag("Player1");
        player.GetComponent<Animator>().SetBool("Die", false);
        player.GetComponent<Player>().stopMoving();
        player.GetComponent<Player>().resetPosition();
        player = GameObject.FindGameObjectWithTag("Player2");
        player.GetComponent<Animator>().SetBool("Die", false);
        player.GetComponent<Player>().stopMoving();
        player.GetComponent<Player>().resetPosition();
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Ghost1"))
        {
            g.GetComponent<Ghost>().resetPosition();
            g.GetComponent<Ghost>().resetColor();
        }
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Ghost2"))
        {
            g.GetComponent<Ghost>().resetPosition();
            g.GetComponent<Ghost>().resetColor();
        }
        resetPill2();
    }

    IEnumerator p1Win()
    {
        win1.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
    }

    IEnumerator p2Win()
    {
        win2.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(3);
        Global.finish = false;
        if (SceneManager.GetActiveScene().name != "Menu"&& !am.bgm.isPlaying)
        {
            am.playBGM();
        }
    }

}
