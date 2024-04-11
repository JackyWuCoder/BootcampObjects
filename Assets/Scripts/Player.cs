using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayableObject
{
    private string nickName;
    [SerializeField] private float speed;
    [SerializeField] Camera cam;
    Rigidbody2D playerRb;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
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
        //***************************************************************
        playerRb.velocity = direction * speed * Time.deltaTime;
        var playerScreenPos = cam.WorldToScreenPoint(transform.position);
        target.x -= playerScreenPos.x;
        target.y -= playerScreenPos.y;
        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public override void GetDamage(float damage)
    {
        throw new System.NotImplementedException();
    }
}
