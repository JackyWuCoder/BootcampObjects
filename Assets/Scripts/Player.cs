using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private string nickName;
    private float speed;
    // Why public?
    public Health health = new Health();
    // Why do we not instantiate the weapon here?
    public Weapon weapon;

    public void Move(Vector3 direction)
    {
        Debug.Log("Player is moving");
    }

    public void Shoot(Vector3 direction, float speed)
    {
        Debug.Log("Player shoots");
    }

    public void Die()
    {
        Debug.Log("Player died");
    }
}
