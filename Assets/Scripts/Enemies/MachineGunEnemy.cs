using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunEnemy : Enemy
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private float attackRangeX = 5f;
    [SerializeField] private float attackRangeY = 5f;
    [SerializeField] private float fireCooldown = 0.5f; // Adjusts fire rate

    private float lastFireTime;

    protected override void Start()
    {
        base.Start();
        health = new Health(1, 0, 1);
        // weapon = new Weapon("MachineGun", 2, 1);
    }

    protected override void Update()
    {
        if (target != null)
        {
            if ((Mathf.Abs(transform.position.x - target.position.x) <= attackRangeX) &&
                (Mathf.Abs(transform.position.y - target.position.y) <= attackRangeY))
            {
                if (Time.time - lastFireTime >= fireCooldown)
                {
                    Shoot();
                    lastFireTime = Time.time;
                }
            }
            else
            {
                Move(target.position);
            }
        }
        else
        {
            Move(speed);
        }
    }

    public override void Shoot()
    {
        weapon.Shoot(bulletPrefab, this, "Player");
    }
}
