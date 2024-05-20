using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using System;

public class Player : PlayableObject
{
    private string nickName;
    [SerializeField] private float speed;
    [SerializeField] Camera cam;
    [SerializeField] private float weaponDamage = 1;
    [SerializeField] private float bulletSpeed = 10;
    [SerializeField] private Bullet bulletPrefab;
    //public Action<float> OnHealthUpdate;
    Rigidbody2D playerRb;
    private TextMeshProUGUI healthText;

    private void Awake()
    {
        health = new Health(100f, 0.5f, 50f);
        playerRb = GetComponent<Rigidbody2D>();
        weapon = new Weapon("Player Weapon", weaponDamage, bulletSpeed);
        healthText = GameObject.Find("/Canvas/PlayerHealth").GetComponent<TextMeshProUGUI>();
        UpdateHealthText();
        //OnHealthUpdate?.Invoke(health.GetHealth());
    }

    private void Update()
    {
        if (health.GetHealth() == 0)
        {
            Die();
        }
        else
        {
            health.RegenHealth();
            UpdateHealthText();
        }
    }

    public override void Shoot()
    {
        Debug.Log("Player shooting a bullet");
        weapon.Shoot(bulletPrefab, this, "Enemy");
    }

    public override void Die()
    {
        Debug.Log("Player died!");
        Destroy(gameObject);
    }

    public override void Attack(float interval)
    {
        throw new System.NotImplementedException();
    }

    public override void Move(Vector2 direction, Vector2 target)
    {
        //***************************************************************
        playerRb.velocity = direction * speed * Time.deltaTime;
        var playerScreenPos = cam.WorldToScreenPoint(transform.position);
        target.x -= playerScreenPos.x;
        target.y -= playerScreenPos.y;
        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public override void GetDamage(float damage)
    {
        Debug.Log(health.GetHealth());
        health.DeductHealth(damage);
        //OnHealthUpdate?.Invoke(health.GetHealth());
        if (health.GetHealth() <= 0)
        {
            Die();
        }

        healthText.text = $"Health : {health.GetHealth()}";
    }

    private void UpdateHealthText()
    {
        healthText.text = $"Health : {health.GetHealth()}";
    }
}
