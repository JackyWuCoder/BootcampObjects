using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon
{
    private string name;
    private float damage;
    private float bulletSpeed;

    public Weapon()
    { 
    
    }

    public Weapon(string name, float damage, float bulletSpeed) 
    {
        this.name = name;
        this.damage = damage;
        this.bulletSpeed = bulletSpeed;
    }

    public void Shoot(Bullet bullet, PlayableObject player, string targetTag, float timeToDie = 5)
    {
        Debug.Log("Shooting from gun");
        Bullet bulletObj = GameObject.Instantiate(bullet, player.transform.position, player.transform.rotation);
        bulletObj.SetBullet(damage, targetTag,bulletSpeed);
        GameObject.Destroy(bulletObj.gameObject, timeToDie);
    }

    public float GetDamage()
    {
        return damage;
    }
}
