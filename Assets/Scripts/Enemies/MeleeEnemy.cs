using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    [SerializeField] private float attackRange;
    [SerializeField] private float attackTime = 0;
    private float timer = 0;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        health = new Health(1, 0, 1);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (target == null)
            return;
        if (Vector2.Distance(transform.position, target.position) < attackRange)
        {
            // Enemy can Attack
            Attack(attackTime);
        }
    }

    public override void Attack(float interval)
    {
        if (timer <= interval)
        {
            timer += Time.deltaTime;
        }
        else 
        {
            timer = 0;
            target.GetComponent<IDamageable>().GetDamage(0);
        }
    }

    public override void GetDamage(float damage)
    {
        health.DeductHealth(damage);
    }

    public override void MethodToOverride()
    {
        Debug.Log("Method overridden in MeleeEnemy");
    }
}
