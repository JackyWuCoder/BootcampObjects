using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Creating an object of player
        Player myPlayer = new Player();

        // Enemy object
        Enemy meleeEnemy = new Enemy();
        Enemy shooterEnemy = new Enemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
