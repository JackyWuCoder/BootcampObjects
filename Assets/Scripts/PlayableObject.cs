using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayableObject : MonoBehaviour, IDamageable
{
    // Why public? Why do we instantiate it here?
    public Health health;
    // Why do we not instantiate the weapon here?
    public Weapon weapon;

    public abstract void Move(Vector2 direction, Vector2 target);

    // Polymorphism/method overloads
    public virtual void Move(Vector2 direction)
    { 
        
    }

    public virtual void Move(float speed)
    { 
    
    }

    public abstract void Shoot();
    public abstract void Attack(float interval);
    public abstract void Die();
    // Implemented from IDamageable interface
    public abstract void GetDamage(float damage);
}
