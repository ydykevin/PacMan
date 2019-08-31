using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Global
{
    public static float playerSpeed = 3f; //Unit per second
    public static float ghostSpeed = 3.01f; //Unit per second
    public static Vector2 leftPortal = new Vector2(-9, 0.5f);
    public static Vector2 rightPortal = new Vector2(9, 0.5f);
    public static Vector2 pPosition = new Vector2(0, -5.5f);
    public static Vector2 g1Position = new Vector2(0, 1.5f);
    public static Vector2 g2Position = new Vector2(0, 0.5f);
    public static Vector2 g3Position = new Vector2(-1, 0.5f);
    public static Vector2 g4Position = new Vector2(1, 0.5f);
    public static bool finish = false; //Game state
    public static int life = 3;
    public static List<bool> sArr;

    public static void resetSArr()
    {
        sArr = new List<bool>();
        sArr.Add(false);
        sArr.Add(false);
        sArr.Add(false);
        sArr.Add(false);
    }
}
