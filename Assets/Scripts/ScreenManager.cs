using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
{
    public GameObject pArr;
    public GameObject spArr;
    public GameObject over;
    public GameObject win;
    public Text score;
    public GameObject life3;
    public GameObject life2;

    // Start is called before the first frame update
    void Start()
    {
        
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

    void resetGame()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("Die", false);

        foreach (Transform child in pArr.transform)
        {
            child.gameObject.SetActive(true);
        }
        foreach (Transform child in spArr.transform)
        {
            child.gameObject.SetActive(true);
        }
        
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().resetPosition();
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().stopMoving();
        
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Ghost"))
        {
            g.GetComponent<Ghost>().resetPosition();
        }

        over.SetActive(false);
        win.SetActive(false);
        Global.finish = false;
    }

}
