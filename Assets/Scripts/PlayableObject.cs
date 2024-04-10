using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableObject : MonoBehaviour
{
    // Why public? Why do we instantiate it here?
    public Health health = new Health();
    // Why do we not instantiate the weapon here?
    public Weapon weapon;
    public virtual void Move(Transform target)
    {
        Debug.Log("Base movement");
    }

    public virtual void Shoot(Vector3 direction, float speed)
    {
        Debug.Log($"Base is shooting with the speed {speed}");
    }

    public virtual void Attack(float interval)
    {
        Debug.Log("Base is attacking");
    }

    public virtual void Die()
    {
        Debug.Log($"Enemy died");
    }
}
