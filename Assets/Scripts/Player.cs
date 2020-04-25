using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Transform player;
    public Rigidbody2D cannonball;

    public BallMovement ball;

    public string controllerName;

    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
           // Debug.Log("Pressed Space");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(2);
        }
    }
    private void Fire()
    {
        var bomb = Instantiate(cannonball, new Vector2(player.position.x, player.position.y), Quaternion.identity);
        bomb.AddForce(new Vector2(0,300));
        //Debug.Log("Fire!");
    }
    private void Move()
    {
        float moveAxis = Input.GetAxis(controllerName) * 10;
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveAxis, 0);
    }
}
