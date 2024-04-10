using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayableObject
{
    private string nickName;
    private float speed;

    private void Start()
    {
        Move();
    }
    public override void Move()
    {
        base.Move();
        Debug.Log("Local player movement");
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
