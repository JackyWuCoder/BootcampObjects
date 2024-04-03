using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet
{
    private float speed;
    private float damage;

    void Move()
    {
        Debug.Log("Bullet is moving");
    }

    void Damage()
    {
        Debug.Log("Damaged something");
    }
}
