using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGame : BallMovement
{
    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        hitWall = GetComponent<AudioSource>();
        Invoke("StartBouncing", 2f);

        lastScore = SaveLoadManager.Load("playerdata.txt").LastScore;
        lastYcoor = SaveLoadManager.Load("playerdata.txt").lastYcoor;

    }
}
