using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploderEnemy : Enemy
{
    private float explodeDamage = 50f;

    protected override void Update()
    {
        base.Update();
        // Check if the enemy is directly above the player
        if (IsAbovePlayer())
        {
            Explode();
        }
    }

    private bool IsAbovePlayer()
    {
        // Get the player's position
        Vector2 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;

        // Check if the enemy is directly above the player within a certain threshold (e.g., 1 unit)
        return Mathf.Abs(transform.position.x - playerPosition.x) < 0.1f &&
               Mathf.Abs(transform.position.y - playerPosition.y) < 0.1f;
    }

    private void Explode()
    {
        // Destroy the ExploderEnemy
        Destroy(gameObject);
        Debug.Log("Exploded on the Player");
    }

    private void DamagePlayer()
    {
        // Find the player GameObject
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        // Get the Player script attached to the player GameObject
        Player player = playerObject.GetComponent<Player>();

        player.health.DeductHealth(explodeDamage);
    }

    public override void MethodToOverride()
    {
        Debug.Log("Method overridden in ExploderEnemy");
    }
}
