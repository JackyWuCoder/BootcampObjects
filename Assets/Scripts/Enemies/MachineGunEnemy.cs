using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunEnemy : Enemy
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float attackRangeX = 3f;
    [SerializeField] private float attackRangeY = 3f;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        if (target != null)
        {
            if ((Mathf.Abs(transform.position.x - target.position.x) > attackRangeX) ||
                (Mathf.Abs(transform.position.y - target.position.y) > attackRangeY))
            {
                Move(target.position);
            }
            else
            {
                Shoot();
            }
        }
        else
        {
            Move(speed);
        }
    }

    public override void Shoot()
    {
        //Debug.Log("MachineGunEnemy is Shooting");
    }

    public override void MethodToOverride()
    {
        Debug.Log("Method overridden in MachineGunEnemy");
    }
}
