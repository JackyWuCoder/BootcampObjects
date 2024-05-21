using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploderEnemy : Enemy
{
    private float explodeDamage = 50f;

    protected override void Start()
    {
        base.Start();
        health = new Health(1, 0, 1);
    }

    protected override void Update()
    {
        base.Update();
        // Check if the enemy is directly above the player
        if (target != null && IsAboveTarget())
        {
            Explode();
        }
    }

    private bool IsAboveTarget()
    {
        // Check if the exploder enemy is directly above the target within a certain threshold (e.g., 0.1 unit)
        return Mathf.Abs(transform.position.x - target.position.x) < 0.1f &&
               Mathf.Abs(transform.position.y - target.position.y) < 0.1f;
    }

    private void Explode()
    {
        // Destroy the ExploderEnemy
        Destroy(gameObject);
        Debug.Log("Exploded on the Target");
        target.gameObject.GetComponent<Player>().GetDamage(explodeDamage);
    }
}
