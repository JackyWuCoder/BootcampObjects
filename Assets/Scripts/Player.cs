using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private string nickName;
    private float speed;

    public void Move()
    {
        Debug.Log("Player is moving");
    }

    public void Shoot()
    {
        Debug.Log("Player shoots");
    }

    public void Die()
    {
        Debug.Log("Player died");
    }
}
