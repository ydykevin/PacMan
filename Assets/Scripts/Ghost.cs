using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public int ghost; // 1=Green(Random), 2=Pink(Clockwise), 3=Blue(Run), 4=Red(Chase)
    private int direction = 0; // 0=idle, 1=up, 2=down, 3=left, 4=right
    private bool up;
    private bool down;
    private bool left;
    private bool right;
    private List<GhostMovement> arr = new List<GhostMovement>();
    private float movement;
    private float detectRad;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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

        }
        else if (ghost == 3)
        {

        }
        else if (ghost == 4)
        {

        }

    }

    public void resetDirection()
    {
        Debug.Log("reset");
        direction = 0;
    }

    void detectOpenArea()
    {
        arr = new List<GhostMovement>();
        detectRad = (1 - Time.deltaTime * Global.ghostSpeed) / 2 - 0.01f;

        RaycastHit2D hit = Physics2D.CircleCast(transform.position, detectRad, Vector2.up, 1f);
        //up = hit.collider == null ? true : false;
        if (hit.collider == null)
        {
            arr.Add(new GhostMovement(Quaternion.Euler(0f, 0f, 0f), new Vector2(transform.position.x, transform.position.y + movement), 1, Vector2.up, 2));
            //Debug.Log("up");
        }

        hit = Physics2D.CircleCast(transform.position, detectRad, Vector2.down, 1f);
        //down = hit.collider == null ? true : false;
        if (hit.collider == null)
        {
            arr.Add(new GhostMovement(Quaternion.Euler(0f, 0f, 0f), new Vector2(transform.position.x, transform.position.y - movement), 2, Vector2.down, 1));
            //Debug.Log("down");
        }

        hit = Physics2D.CircleCast(transform.position, detectRad, Vector2.left, 1f);
        //left = hit.collider == null ? true : false;
        if (hit.collider == null)
        {
            arr.Add(new GhostMovement(Quaternion.Euler(0f, 0f, 0f), new Vector2(transform.position.x - movement, transform.position.y), 3, Vector2.left, 4));
            //Debug.Log("left");
        }

        hit = Physics2D.CircleCast(transform.position, detectRad, Vector2.right, 1f);
        //right = hit.collider == null ? true : false;
        if (hit.collider == null)
        {
            arr.Add(new GhostMovement(Quaternion.Euler(0f, 0f, 0f), new Vector2(transform.position.x + movement, transform.position.y), 4, Vector2.right, 3));
            //Debug.Log("right");
        }
    }

    void movePattern1()
    {

        //int i = Random.Range(0, arr.Count);
        //if (direction == 0)
        //{
        //    transform.position = arr[i].v;
        //    direction = arr[i].d;
        //}
        //else
        //{
        //    //Only one open direction or two open opposite directions, keep moving
        //    if (arr.Count == 1 || (arr.Count == 2 && arr[0].dv == -arr[1].dv))
        //    {
        //        //if (direction == arr[0].d)
        //        //{
        //        //    transform.position = arr[0].v;
        //        //}
        //        //else
        //        //{
        //        //    transform.position = arr[1].v;
        //        //}
        //        move();
        //    }

        //}

        //Only one open direction or two open opposite directions, keep moving
        if ((arr.Count == 0) || (arr.Count == 1 && direction != 0) || (arr.Count == 2 && arr[0].dv == -arr[1].dv))
        {
            move();
            return;
        }

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

    void move()
    {
        if (direction == 1)
        {
            //transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            transform.position = new Vector2(transform.position.x, transform.position.y + movement);
        }
        else if (direction == 2)
        {
            //transform.rotation = Quaternion.Euler(0f, 0f, -90f);
            transform.position = new Vector2(transform.position.x, transform.position.y - movement);
        }
        else if (direction == 3)
        {
            //transform.rotation = Quaternion.Euler(0f, 0f, 180f);
            transform.position = new Vector2(transform.position.x - movement, transform.position.y);
        }
        else if (direction == 4)
        {
            //transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            transform.position = new Vector2(transform.position.x + movement, transform.position.y);
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