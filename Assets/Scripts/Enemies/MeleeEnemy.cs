using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    [SerializeField] private float attackRange;
    [SerializeField] private float attackTime = 0;
    private float timer = 0;
    private float setSpeed = 0;

    public void SetMeleeEnemy(float _attackRange, float _attackTime)
    {
        attackRange = _attackRange;
        attackTime = _attackTime;
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        health = new Health(1, 0, 1);
        setSpeed = speed;
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
            speed = 0;
            Attack(attackTime);
        }
        else
        {
            speed = setSpeed;
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
            target.GetComponent<IDamageable>().GetDamage(weapon.GetDamage());
        }
    }

    /*
    public override void GetDamage(float damage)
    {
        health.DeductHealth(damage);
    }
    */

    public override void MethodToOverride()
    {
        Debug.Log("Method overridden in MeleeEnemy");
    }
}
