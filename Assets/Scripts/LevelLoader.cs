using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    private RandomCalculations randCalc;

    // Start is called before the first frame update
    private void Start()
    {
        // Creating an object of player
        Player myPlayer = new Player();

        // Enemy object
        Enemy meleeEnemy = new Enemy();
        Enemy shooterEnemy = new Enemy();

        // Create weapon objects
        Weapon gun1 = new Weapon();
        Weapon machineGun = new Weapon();
        //Weapon meleeWeapon = new Weapon("Melee Weapon", 5f);

        myPlayer.weapon = gun1;
        shooterEnemy.weapon = machineGun;
        //meleeEnemy.weapon = meleeWeapon;

        RandomCalculations.randNum = 5;
        randCalc.length = 5f;
        RandomCalculations.CalcRandNum();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
