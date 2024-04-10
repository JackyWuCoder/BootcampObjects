using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayableObject
{
    private string nickName;
    private float speed;

    public override void Move()
    {
        base.Move();
    }

    public override void Shoot(Vector3 direction, float speed)
    {
        Debug.Log("Player shooting a bullet");
    }

    public override void Die()
    {
        base.Die();
    }
}
