using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Global
{
    public static float playerSpeed = 3f; //Unit per second
    public static float ghostSpeed = 2.8f; //Unit per second

    //Position vector for portals
    public static Vector2 goLeft = new Vector2(-9, 0.5f);
    public static Vector2 goRight = new Vector2(9, 0.5f);
    public static Vector2 goLeft1 = new Vector2(-19,9.5f);
    public static Vector2 goRight1 = new Vector2(-1,9.5f);
    public static Vector2 goLeft2 = new Vector2(1, 9.5f);
    public static Vector2 goRight2 = new Vector2(19, 9.5f);

    //Position vector for single player
    public static Vector2 pPosition = new Vector2(0, -5.5f);
    public static Vector2 g1Position = new Vector2(0, -0.5f);
    public static Vector2 g2Position = new Vector2(0, 0.5f);
    public static Vector2 g3Position = new Vector2(-1, 0.5f);
    public static Vector2 g4Position = new Vector2(1, 0.5f);

    //Position vector for P1
    public static Vector2 pPosition1 = new Vector2(-10, 3.5f);
    public static Vector2 g1Position1 = new Vector2(-10, 8.5f);
    public static Vector2 g2Position1 = new Vector2(-10, 9.5f);
    public static Vector2 g3Position1 = new Vector2(-11, 9.5f);
    public static Vector2 g4Position1 = new Vector2(-9, 9.5f);

    //Position vector for P2
    public static Vector2 pPosition2 = new Vector2(10, 3.5f);
    public static Vector2 g1Position2 = new Vector2(10, 8.5f);
    public static Vector2 g2Position2 = new Vector2(10, 9.5f);
    public static Vector2 g3Position2 = new Vector2(11, 9.5f);
    public static Vector2 g4Position2 = new Vector2(9, 9.5f);

    public static bool finish = false; //Game state
    public static int life = 3;

    public static bool super = false;
    public static bool super1 = false;
    public static bool super2 = false;

    public static int score1 = 0;
    public static int score2 = 0;
    public static int toWin = 3;

}
