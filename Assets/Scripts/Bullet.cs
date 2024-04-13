using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour 
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    private string targetTag;

    public void SetBullet(float damage, string targetTag, float speed = 10)
    {
        this.damage = damage;
        this.targetTag = targetTag;
        this.speed = speed;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void Damage(IDamageable damageable)
    {
        if (damageable != null)
        {
            damageable.GetDamage(damage);
            Debug.Log("Damaged something");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag(targetTag))
            return;
        Debug.Log($"Hit {collision.gameObject.name}");
        IDamageable damageable = collision.GetComponent<IDamageable>();
        Damage(damageable);
    }
}
