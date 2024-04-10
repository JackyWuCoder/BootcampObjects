using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : PlayableObject
{
    private string name;
    private float speed;
    // Why public? Why do we instantiate it here?
    public Health health = new Health();
    // Why do we not instantiate the weapon here?
    public Weapon weapon;

    private EnemyType enemyType;

    private enum TestEnum
    { 
        value1, value2, value3
    }

    private TestEnum testEnum;

    public void Move(Transform target) 
    { 
    
    }

    public void Shoot(Vector3 direction, float speed)
    { 
    
    }

    public void Attack(float interval)
    { 
        
    }

    public void Die(string message)
    {
        Debug.Log($"Enemy died with a message {message}");
    }
}
