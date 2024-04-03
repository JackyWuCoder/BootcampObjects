using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    private string name;
    private float speed;
    // Why public?
    public Health health = new Health();
    // Why do we not instantiate the weapon here?
    public Weapon weapon;
}
