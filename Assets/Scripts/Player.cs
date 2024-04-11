using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayableObject
{
    private string nickName;
    private float speed;

    private void Start()
    {
        
    }

    public override void Shoot()
    {
        Debug.Log("Player shooting a bullet");
    }

    public override void Die()
    {
        throw new System.NotImplementedException();
    }

    public override void Attack(float interval)
    {
        throw new System.NotImplementedException();
    }

    public override void Move(Vector2 direction, Vector2 target)
    {
        throw new System.NotImplementedException();
    }

    public override void GetDamage(float damage)
    {
        throw new System.NotImplementedException();
    }
}
