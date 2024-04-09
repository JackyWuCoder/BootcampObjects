using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon
{
    private string name;
    private float damage;

    public Weapon()
    { 
    
    }

    public Weapon(string name, float damage) 
    {
        this.name = name;
        this.damage = damage;
    }

    public void Shoot()
    {
        Debug.Log("Shooting from gun");
    }
}
