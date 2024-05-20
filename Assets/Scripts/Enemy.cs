using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : PlayableObject
{
    private string enemyName;
    [SerializeField] protected float speed;
    protected Transform target;

    private EnemyType enemyType;

    private enum TestEnum
    { 
        value1, value2, value3
    }

    private TestEnum testEnum;

    protected virtual void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    protected virtual void Update()
    {
        if (target != null)
        {
            Move(target.position);
        }
        else
        {
            Move(speed);
        }
    }

    public override void Move(Vector2 direction, Vector2 target)
    {
        throw new System.NotImplementedException();
    }

    public override void Move(float speed)
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    public override void Move(Vector2 direction)
    {
        direction.x -= transform.position.x;
        direction.y -= transform.position.y;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    public override void Shoot()
    {
        
    }

    public override void Attack(float interval)
    {
        
    }

    public override void Die()
    {
        Debug.Log("Enemy died");
        Destroy(gameObject);
    }

    public override void GetDamage(float damage)
    {
        Debug.Log("Enemy damaged");
        health.DeductHealth(damage);
        if (health.GetHealth() <= 0)
        {
            Die();
        }
    }

    public virtual void MethodToOverride()
    {
        Debug.Log("Method to override in Enemy");
    }
}
