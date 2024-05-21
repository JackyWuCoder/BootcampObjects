using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject explodingEnemyPrefab;
    [SerializeField] private GameObject machineGunEnemyPrefab;
    [SerializeField] private GameObject shooterEnemyPrefab;

    private int numberOfEnemies = 3;

    [SerializeField] private Transform[] spawnPositions;

    [SerializeField] private float enemySpawnRate;
    [SerializeField] private GameObject playerPrefab;

    private GameObject tempEnemy;
    private bool isPlaying = false;

    [HideInInspector] public bool isEnemySpawning;

    public ScoreManager scoreManager;
    public PickupSpawner pickupSpawner;

    public Action OnGameStart;
    public Action OnGameOver;

    private Weapon meleeWeapon = new Weapon("Melee", 1, 0);

    private static GameManager instance;

    private Player player;

    public static GameManager GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        instance = this;
    }

    // Start is called before the first frame update
    /*
    void Start()
    {
        FindPlayer();
        isEnemySpawning = true;
        StartCoroutine(EnemySpawner());
    }
    */

    private void CreateEnemy()
    {
        //int randomNumber = UnityEngine.Random.Range(0, numberOfEnemies);
        int randomNumber = 1;


        /*tempEnemy = Instantiate(enemyPrefab);
        tempEnemy.transform.position = spawnPositions[UnityEngine.Random.Range(0, spawnPositions.Length)].position;
        tempEnemy.GetComponent<Enemy>().weapon = meleeWeapon;
        tempEnemy.GetComponent<MeleeEnemy>().SetMeleeEnemy(2, 0.25f);*/

        
        // Create exploding enemy
        /*
        if (randomNumber == 0)
        {
            tempEnemy = Instantiate(explodingEnemyPrefab);
            tempEnemy.transform.position = spawnPositions[UnityEngine.Random.Range(0, spawnPositions.Length)].position;
        }
        */
        
        // Create machinegun enemy
        if (randomNumber == 1)
        {
            tempEnemy = Instantiate(machineGunEnemyPrefab);
            tempEnemy.transform.position = spawnPositions[UnityEngine.Random.Range(0, spawnPositions.Length)].position;
            Weapon machineGunWeapon = new Weapon("MachineGun", 1, 10);
            tempEnemy.GetComponent<Enemy>().weapon = machineGunWeapon;
            tempEnemy.GetComponent<MachineGunEnemy>().Shoot();
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            CreateEnemy();
        }
    }

    IEnumerator EnemySpawner()
    {
        while (isEnemySpawning)
        {
            yield return new WaitForSeconds(1.0f / enemySpawnRate);
            CreateEnemy();
        }
    }

    public void NotifyDeath(Enemy enemy)
    {
        pickupSpawner.SpawnPickup(enemy.transform.position);
    }

    public Player GetPlayer()
    {
        return player;
    }

    public bool IsPlaying()
    {
        return isPlaying;
    }

    public void StartGame()
    {
        player = Instantiate(playerPrefab, Vector2.zero, Quaternion.identity).GetComponent<Player>();
        player.OnDeath += StopGame;
        isPlaying = true;

        OnGameStart?.Invoke();
        StartCoroutine(GameStarter());
    }

    IEnumerator GameStarter()
    {
        yield return new WaitForSeconds(2.0f);
        isEnemySpawning = true;
        StartCoroutine(EnemySpawner());
    }

    public void StopGame()
    {
        scoreManager.SetHighScore();
        StartCoroutine(GameStopper());
    }

    IEnumerator GameStopper()
    {
        isEnemySpawning = false;
        yield return new WaitForSeconds(2.0f);
        isPlaying = false;

        // Delete all the enemies
        foreach (Enemy item in FindObjectsOfType(typeof(Enemy)))
        {
            Destroy(item.gameObject);
        }

        // Delete all pickups
        foreach (Pickup item in FindObjectsOfType(typeof(Pickup)))
        {
            Destroy(item.gameObject);
        }

        OnGameOver?.Invoke();
    }
}
