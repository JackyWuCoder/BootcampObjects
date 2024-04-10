using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : PlayableObject
{
    private string name;
    private float speed;

    private EnemyType enemyType;

    private enum TestEnum
    { 
        value1, value2, value3
    }

    private TestEnum testEnum;

    public override void Move(Transform target) 
    { 
    
    }

    public override void Shoot(Vector3 direction, float speed)
    { 
    
    }

    public override void Attack(float interval)
    { 
        
    }

    public override void Die(string message)
    {
        Debug.Log($"Enemy died with a message {message}");
    }
}
