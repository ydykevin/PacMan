using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public int ghost; // 1=Green(Random), 2=Pink(Clockwise), 3=Blue(Run), 4=Red(Chase)
    public GameObject over;
    public Animator ani;
    public GameObject life3;
    public GameObject life2;
    private int direction = 0; // 0=idle, 1=up, 2=down, 3=left, 4=right
    private List<GhostMovement> arr = new List<GhostMovement>();
    private float movement;
    private float detectRad;
    private bool up;
    private bool down;
    private bool left;
    private bool right;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] gArr = GameObject.FindGameObjectsWithTag("Ghost");
        foreach (GameObject g in gArr)
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), g.GetComponent<Collider2D>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!Global.finish)
        {
            movement = Global.ghostSpeed * Time.deltaTime;
            detectOpenArea();
            //Select moving pattern
            if (ghost == 1)
            {
                movePattern1();
            }
            else if (ghost == 2)
            {
                movePattern2();
            }
            else if (ghost == 3)
            {
                movePattern3();
            }
            else if (ghost == 4)
            {
                movePattern4();
            }
        }
    }

    void detectOpenArea()
    {
        arr = new List<GhostMovement>();
        detectRad = (1 - Time.deltaTime * Global.ghostSpeed) / 2 - 0.01f;

        up = false;
        down = false;
        left = false;
        right = false;

        RaycastHit2D hit = Physics2D.CircleCast(transform.position, detectRad, Vector2.up, 1f);
        if (hit.collider == null)
        {
            up = true;
            arr.Add(new GhostMovement(Quaternion.Euler(0f, 0f, 0f), new Vector2(transform.position.x, transform.position.y + movement), 1, Vector2.up, 2));
            //Debug.Log("up");
        }

        hit = Physics2D.CircleCast(transform.position, detectRad, Vector2.down, 1f);
        if (hit.collider == null)
        {
            down = true;
            arr.Add(new GhostMovement(Quaternion.Euler(0f, 0f, 0f), new Vector2(transform.position.x, transform.position.y - movement), 2, Vector2.down, 1));
            //Debug.Log("down");
        }

        hit = Physics2D.CircleCast(transform.position, detectRad, Vector2.left, 1f);
        if (hit.collider == null)
        {
            left = true;
            arr.Add(new GhostMovement(Quaternion.Euler(0f, 0f, 0f), new Vector2(transform.position.x - movement, transform.position.y), 3, Vector2.left, 4));
            //Debug.Log("left");
        }

        hit = Physics2D.CircleCast(transform.position, detectRad, Vector2.right, 1f);
        if (hit.collider == null)
        {
            right = true;
            arr.Add(new GhostMovement(Quaternion.Euler(0f, 0f, 0f), new Vector2(transform.position.x + movement, transform.position.y), 4, Vector2.right, 3));
            //Debug.Log("right");
        }
    }

    void movePattern1()
    {
        if (atJunction())
        {
            //Do not allow go back at junction
            for (int index = 0; index < arr.Count; index++)
            {
                if (direction == arr[index].od)
                {
                    arr.RemoveAt(index);
                    index--;
                }
            }

            int i = Random.Range(0, arr.Count);
            transform.position = arr[i].v;
            direction = arr[i].d;
        }
    }

    void movePattern2()
    {
        //If idle, select random direction for start
        if (direction == 0)
        {
            movePattern1();
            return;
        }

        if (atJunction())
        {
            if (direction == 1)
            {
                selectClockwisePath(up, right, left, 1, 4, 3);
            }
            else if (direction == 2)
            {
                selectClockwisePath(down, left, right, 2, 3, 4);
            }
            else if (direction == 3)
            {
                selectClockwisePath(left, up, down, 3, 1, 2);
            }
            else if (direction == 4)
            {
                selectClockwisePath(right, down, up, 4, 2, 1);
            }
        }

    }

    //r1: best direction, r2: second best direction, r3: bad direction
    void selectClockwisePath(bool r1, bool r2, bool r3, int d1, int d2, int d3)
    {

        List<int> dArr = new List<int>();
        if (r1)
        {
            dArr.Add(d1);
        }
        if (r2)
        {
            dArr.Add(d2);
        }
        if (r3)
        {
            dArr.Add(d3);
        }

        if (dArr.Count == 1)
        {
            direction = dArr[0];
            move();
            return;
        }

        int i = Random.Range(1, 101);
        if (r3)
        {
            //Best direction: 60%, second best direction: 35%, bad direction: 5%
            if (i <= 5)
            {
                direction = d3;
                Debug.Log("5%");
            }
            else if ((i >= 6 && i <= 65 && r1))
            {
                direction = d1;
            }
            else if (i > 65 && r2)
            {
                direction = d2;
            }

        }
        else
        {
            //Best direction: 50%, second best direction: 50%
            if (i <= 50 && r1)
            {
                direction = d1;
            }
            else if (i > 50 && r2)
            {
                direction = d2;
            }
        }
        move();
    }

    void movePattern3()
    {
        if (atJunction())
        {
            float x = GameObject.FindGameObjectWithTag("Player").transform.position.x - transform.position.x;
            float y = GameObject.FindGameObjectWithTag("Player").transform.position.y - transform.position.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                if (x < 0)
                {
                    if (y < 0)
                    {
                        selectChaseRunPath(right, up, down, left, 4, 1, 2, 3);
                    }
                    else
                    {
                        selectChaseRunPath(right, down, up, left, 4, 2, 1, 3);
                    }
                }
                else
                {
                    if (y < 0)
                    {
                        selectChaseRunPath(left, up, down, right, 3, 1, 2, 4);
                    }
                    else
                    {
                        selectChaseRunPath(left, down, up, right, 3, 2, 1, 4);
                    }
                }
            }
            else
            {
                if (x < 0)
                {
                    if (y < 0)
                    {
                        selectChaseRunPath(right, up, left, down, 4, 1, 3, 2);
                    }
                    else
                    {
                        selectChaseRunPath(right, down, left, up, 4, 2, 3, 1);
                    }
                }
                else
                {
                    if (y < 0)
                    {
                        selectChaseRunPath(left, up, right, down, 3, 1, 4, 2);
                    }
                    else
                    {
                        selectChaseRunPath(left, down, right, up, 3, 2, 4, 1);
                    }
                }
            }
        }
    }

    void movePattern4()
    {
        if (atJunction())
        {
            float x = GameObject.FindGameObjectWithTag("Player").transform.position.x - transform.position.x;
            float y = GameObject.FindGameObjectWithTag("Player").transform.position.y - transform.position.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                if (x < 0)
                {
                    if (y < 0)
                    {
                        selectChaseRunPath(left, down, up, right, 3, 2, 1, 4);
                    }
                    else
                    {
                        selectChaseRunPath(left, up, down, right, 3, 1, 2, 4);
                    }
                }
                else
                {
                    if (y < 0)
                    {
                        selectChaseRunPath(right, down, up, left, 4, 2, 1, 3);
                    }
                    else
                    {
                        selectChaseRunPath(right, up, down, left, 4, 1, 2, 3);
                    }
                }
            }
            else
            {
                if (x < 0)
                {
                    if (y < 0)
                    {
                        selectChaseRunPath(down, left, up, right, 2, 3, 1, 4);
                    }
                    else
                    {
                        selectChaseRunPath(up, left, down, right, 1, 3, 2, 4);
                    }
                }
                else
                {
                    if (y < 0)
                    {
                        selectChaseRunPath(down, right, up, left, 2, 4, 1, 3);
                    }
                    else
                    {
                        selectChaseRunPath(up, right, down, left, 1, 4, 2, 3);
                    }
                }
            }
        }
    }

    void selectChaseRunPath(bool r1, bool r2, bool r3, bool r4, int d1, int d2, int d3, int d4)
    {
        int i = Random.Range(1, 101);
        bool done = false;

        while (!done)
        {
            i = Random.Range(1, 101);
            //Best direction: 75%, second best direction: 15%, third best direction: 5%, bad direction: 5%
            if (i <= 75 && r1)
            {
                direction = d1;
                done = true;
            }
            else if (i > 75 && i <= 90 && r2)
            {
                direction = d2;
                done = true;
            }
            else if (i > 90 && i <= 95 && r3)
            {
                direction = d3;
                done = true;
            }
            else if (i > 95 && r4)
            {
                direction = d4;
                done = true;
            }
            if (done)
            {
                move();
            }
        }
    }

    bool atJunction()
    {
        //Only one open direction or two open opposite directions, keep moving
        if ((arr.Count == 0) || (arr.Count == 1 && direction != 0) || (arr.Count == 2 && arr[0].dv == -arr[1].dv && direction != 0))
        {
            move();
            return false;
        }

        return true;
    }

    void move()
    {
        if (direction == 1)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + movement);
        }
        else if (direction == 2)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - movement);
        }
        else if (direction == 3)
        {
            transform.position = new Vector2(transform.position.x - movement, transform.position.y);
        }
        else if (direction == 4)
        {
            transform.position = new Vector2(transform.position.x + movement, transform.position.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ani.SetBool("Die", true);
            Global.finish = true;
            if (Global.life != 1)
            {
                StartCoroutine(Delay1());
                Global.life--;
            }
            else
            {
                StartCoroutine(Delay2());
            }
        }
    }

    IEnumerator Delay1()
    {
        yield return new WaitForSeconds(5);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Animator>().SetBool("Die", false);
        player.GetComponent<Player>().resetPosition();
        player.GetComponent<Player>().stopMoving();
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Ghost"))
        {
            g.GetComponent<Ghost>().resetPosition();
        }
        if (Global.life == 2)
        {
            life3.SetActive(false);
        }
        else if (Global.life == 1)
        {
            life2.SetActive(false);
        }
        Global.finish = false;
    }

    IEnumerator Delay2()
    {
        yield return new WaitForSeconds(5);
        over.SetActive(true);
    }

    public void resetPosition()
    {
        if (ghost == 1)
        {
            transform.position = Global.g1Position;
        }
        else if (ghost == 2)
        {
            transform.position = Global.g2Position;
        }
        else if (ghost == 3)
        {
            transform.position = Global.g3Position;
        }
        else if (ghost == 4)
        {
            transform.position = Global.g4Position;
        }
    }

    public void stopMoving()
    {
        Debug.Log("reset");
        direction = 0;
    }

    public void setPortalPosition(bool toRight)
    {
        if (toRight)
        {
            transform.position = Global.rightPortal;
        }
        else
        {
            transform.position = Global.leftPortal;
        }
    }

}

public class GhostMovement
{
    public Quaternion q;
    public Vector2 v;
    public int d;
    public Vector2 dv;
    public int od;

    public GhostMovement(Quaternion q, Vector2 v, int d, Vector2 dv, int od)
    {
        this.q = q;
        this.v = v;
        this.d = d;
        this.dv = dv;
        this.od = od;
    }
}