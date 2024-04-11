using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : PlayableObject
{
    private string name;
    [SerializeField] protected float speed;

    private EnemyType enemyType;

    private enum TestEnum
    { 
        value1, value2, value3
    }

    private TestEnum testEnum;

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
        throw new System.NotImplementedException();
    }

    public override void Attack(float interval)
    {
        throw new System.NotImplementedException();
    }

    public override void Die()
    {
        Debug.Log("Enemy died");
    }

    public override void GetDamage(float damage)
    {
        throw new System.NotImplementedException();
    }

    public virtual void MethodToOverride()
    {
        Debug.Log("Method to override in Enemy");
    }
}
