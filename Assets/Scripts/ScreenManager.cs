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

    // Start is called before the first frame update
    void Start()
    {
        Global.finish = true;
        StartCoroutine(delay());
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "PacMan")
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
            if (done1)
            {
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
            if (done2)
            {
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

    public void nextLevel()
    {
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

        StartCoroutine(delay());
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
        yield return new WaitForSeconds(3);
        win1.gameObject.SetActive(true);
    }

    IEnumerator p2Win()
    {
        yield return new WaitForSeconds(3);
        win2.gameObject.SetActive(true);
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(3);
        Global.finish = false;
    }

}
