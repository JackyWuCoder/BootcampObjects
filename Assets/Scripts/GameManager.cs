using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform[] spawnPositions;

    [SerializeField] private float enemySpawnRate;

    private GameObject tempEnemy;
    [HideInInspector] public bool isEnemySpawning;

    public ScoreManager scoreManager;
    public PickupSpawner pickupSpawner;

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
    void Start()
    {
        isEnemySpawning = true;
        StartCoroutine(EnemySpawner());
    }

    private void CreateEnemy()
    {
        tempEnemy = Instantiate(enemyPrefab);
        tempEnemy.transform.position = spawnPositions[UnityEngine.Random.Range(0, spawnPositions.Length)].position;
        tempEnemy.GetComponent<Enemy>().weapon = meleeWeapon;
        tempEnemy.GetComponent<MeleeEnemy>().SetMeleeEnemy(2, 0.25f);
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

    public Player GetPlayer()
    {
        return player;
    }

    public void FindPlayer()
    {
        try
        {
            player = GameObject.FindWithTag("Player").GetComponent<Player>();
        }
        catch (NullReferenceException e)
        {
            Debug.Log("Player not found");
        }
    }

    public void NotifyDeath(Enemy enemy)
    {
        pickupSpawner.SpawnPickup(enemy.transform.position);
    }
}
