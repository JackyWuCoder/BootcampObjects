using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    public override void MethodToOverride()
    {
        Debug.Log("Method overridden in MeleeEnemy");
    }
}
