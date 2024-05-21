using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : Enemy
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private float attackRangeX = 5f;
    [SerializeField] private float attackRangeY = 5f;
    [SerializeField] private float fireCooldown = 5f; // Adjusts fire rate
    [SerializeField] private LineRenderer lineRenderer;

    private float lastFireTime;

    protected override void Start()
    {
        base.Start();
        health = new Health(1, 0, 1);
        lastFireTime = Time.time;
        // weapon = new Weapon("Shooter", 2, 50);
        if (lineRenderer != null)
        {
            lineRenderer.positionCount = 2;
            lineRenderer.enabled = false;
            lineRenderer.startWidth = 0.1f; // Set the start width
            lineRenderer.endWidth = 0.1f; // Set the end width
        }
    }

    protected override void Update()
    {
        if (target != null)
        {
            if ((Mathf.Abs(transform.position.x - target.position.x) <= attackRangeX) &&
                (Mathf.Abs(transform.position.y - target.position.y) <= attackRangeY))
            {
                UpdateLineRenderer();
                if (Time.time - lastFireTime >= fireCooldown)
                {
                    Shoot();
                    lastFireTime = Time.time;
                }
            }
            else
            {
                Move(target.position);
                if (lineRenderer != null)
                {
                    lineRenderer.enabled = false; // Disable the line renderer.
                }
            }
        }
        else
        {
            Move(speed);
            if (lineRenderer != null)
            {
                lineRenderer.enabled = false; // Disable the line renderer.
            }
        }
    }

    private void UpdateLineRenderer()
    {
        if (lineRenderer != null)
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, target.position);
        }
    }

    public override void Shoot()
    {
        weapon.Shoot(bulletPrefab, this, "Player");
    }
}
