using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : Enemy
{
    public override void MethodToOverride()
    {
        Debug.Log("Method overridden in ShooterEnemy");
    }
}
